using System.Collections;
using UnityEngine;

//Renaissence Coders
//UNITY 2020 ADVANCED AUDIO MANAGER, Game Essentials (3/5)
//https://www.youtube.com/watch?v=3hsBFxrIgQI&t=1214s

namespace UnityCore {

    namespace Audio {

        public class AudioController : MonoBehaviour
        {

            //members
            public static AudioController instance;

            public bool debug;

            public AudioTrack[] tracks;       //Aray of audio tracks

            private Hashtable m_AudioTable;  //relationship between audio types(key) and audio tracks(value)
            private Hashtable m_JobTable;   //relationship between audio types(key) and jobs(value)(Coroutine, IEnumerator)

            [System.Serializable]
            public class AudioObject 
            {
                public AudioType type;
                public AudioClip clip;
            }

            [System.Serializable]
            public class AudioTrack 
            {
                public AudioSource source;
                public AudioObject[] audio; //Aray of 
            }

            private class AudioJob 
            {
                public AudioAction action;
                public AudioType type;
                public bool fade;
                public float delay;

                public AudioJob(AudioAction _action, AudioType _type, bool _fade, float _delay ) 
                {
                    action = _action;
                    type = _type;
                    fade = _fade;
                    delay = _delay;
                }
            }

            public enum AudioAction 
            { 
                START,
                STOP,
                RESTART,
                //RECORD
            }

            #region Unity Functions

            //Single instances
            private void Awake() 
            {
                if (!instance) 
                {
                    //Call everything needed to initialise this object
                    Configure();
                    
                }
            }

            private void OnDisable() 
            {
                //Prevents bugs or audio running in the background
                Dispose();
            }
            #endregion

            #region Public Functions

            public void PlayAudio(AudioType _type, bool _fade = false, float _delay = 0.0f) 
            {
                AddJob(new AudioJob(AudioAction.START, _type, _fade, _delay));
            }

            public void StopAudio(AudioType _type, bool _fade = false, float _delay = 0.0f)
            {
                AddJob(new AudioJob(AudioAction.STOP, _type, _fade, _delay));
            }

            public void RestartAudio(AudioType _type, bool _fade = false, float _delay = 0.0f)
            {
                AddJob( new AudioJob(AudioAction.RESTART, _type, _fade, _delay));
            }
            /// <summary>
            /// TODO
            /// </summary>
            //public void RecordAudio(AudioType _type, bool _fade = false, float _delay = 0.0f)
            //{
            //AddJob( new AudioJob(AudioAction.RECORD._type, _fade, _delay));
            //}

            public AudioClip GetAudioClipFromAudioTrack(AudioType _type, AudioTrack _track)
            {
                foreach (AudioObject _obj in _track.audio)
                {
                    if (_obj.type == _type)
                    {
                        return _obj.clip;
                    }
                }
                return null;
            }
            #endregion

            #region Private Functions
            private void Configure() 
            {
                instance = this;
                m_AudioTable = new Hashtable();
                m_JobTable = new Hashtable();
                PopulateAudioTable();
            }

            private void Dispose() 
            {
                foreach (DictionaryEntry _entry in m_JobTable) 
                {
                    IEnumerator _job = (IEnumerator) _entry.Value;
                    StopCoroutine (_job);
                }
            }

            private void PopulateAudioTable() 
            { 
                foreach (AudioTrack _track in tracks)
                {
                    foreach (AudioObject _obj in _track.audio) 
                    {
                        //Do not duplicate keys
                        //_obj refers to the type and clip fields
                        if (m_AudioTable.ContainsKey(_obj.type))
                        {
                            LogWarning("You are trying to play same audio type [" + _obj.type + "]");
                        }
                        else {
                            m_AudioTable.Add(_obj.type, _track);
                            Log("Registering Audio [" + _obj.type + "].");
                        }
                    }
                }
            }

            private IEnumerator RunAudioJob(AudioJob _job) 
            {
                yield return new WaitForSeconds(_job.delay);

                AudioTrack _track = (AudioTrack)m_AudioTable[_job.type];
                _track.source.clip = GetAudioClipFromAudioTrack(_job.type, _track);

                switch (_job.action) 
                {
                    case AudioAction.START:
                        _track.source.Play();
                        break;
                    case AudioAction.STOP:
                        if (!_job.fade) 
                        {
                            //_track.source;
                            _track.source.Stop();
                        }
                        
                        break;
                    case AudioAction.RESTART:
                        _track.source.Stop();
                        _track.source.Play();

                        break;
                        ///TODO
                        //case AudioAction.RECORD:
                }

                if (_job.fade)
                {
                    float _initial = _job.action == AudioAction.START || _job.action == AudioAction.RESTART ? 0.0f : 1.0f;
                    float _target = _initial == 0 ? 1.0f : 0.0f;
                    float _duration = 1.0f;
                    float _timer = 0.0f;

                    //Moves timer from 0-1 or 1-0 depending on duration.
                    //Volume always starts at 0
                    while (_timer <= _duration)
                    {
                        _track.source.volume = Mathf.Lerp(_initial, _target, _timer / _duration);
                        _timer += Time.deltaTime;
                        yield return null;
                    }

                    if (_job.action == AudioAction.STOP) 
                    {
                        _track.source.Stop();
                    }
                }

                m_JobTable.Remove(_job.type);
                Log("Job count" + m_JobTable.Count);
                yield return null;
            }

            private void AddJob(AudioJob _job)
            {
                //Remove conflicting jobs
                RemoveConflictingJobs(_job.type);

                //Start Job
                IEnumerator _jobRunner = RunAudioJob(_job);
                m_JobTable.Add(_job.type, _jobRunner);
                StartCoroutine(_jobRunner);
                Log("Starting job on [" + _job.type + "] with operation:" + _job.action);
            }

            private void RemoveJob(AudioType _type) 
            {
                if (!m_JobTable.ContainsKey(_type)) 
                {
                    LogWarning("Trying to stop a job [" + _type + "] that is not running");
                    return;
                }
                IEnumerator _runningJob = (IEnumerator) m_JobTable [_type];
                StopCoroutine (_runningJob);
                m_JobTable.Remove(_type);
               
            }

            private void RemoveConflictingJobs(AudioType _type)
            {
                if (m_JobTable.ContainsKey(_type))
                {
                    RemoveJob(_type);
                }
                AudioType _conflictAudio = AudioType.None;
                foreach (DictionaryEntry _entry in m_JobTable) 
                {
                    AudioType _audioType = (AudioType) _entry.Key;
                    AudioTrack _audioTrackInUse = (AudioTrack)m_AudioTable[_audioType];
                    AudioTrack _audioTrackNeeded = (AudioTrack)m_AudioTable[_type];

                    if (_audioTrackNeeded.source == _audioTrackInUse.source) 
                    {
                        //Conflict
                        _conflictAudio = _audioType;
                    }
                }

                if (_conflictAudio != AudioType.None) 
                {
                    RemoveJob(_conflictAudio);
                }
            }                   

            private void Log(string _msg) 
            {
                if (!debug) return;
                Log("[Audio Controller]:" + _msg);
            }
            private void LogWarning(string _msg)
            {
                if (!debug) return;
                LogWarning("[Audio Controller]:" + _msg);
            }
            #endregion
        }


    }


}


