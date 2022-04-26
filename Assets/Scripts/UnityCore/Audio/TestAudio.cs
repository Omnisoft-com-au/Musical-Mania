
using UnityEngine;

//Renaissence Coders
//UNITY 2020 ADVANCED AUDIO MANAGER, Game Essentials (3/5)
//https://www.youtube.com/watch?v=3hsBFxrIgQI&t=1214s

namespace UnityCore
{
    namespace Audio
    {
        public class TestAudio : MonoBehaviour
        {
            public AudioController audioController;


#region Unity Functions
           

#if UNITY_EDITOR
            private void Update()
            {

                if (Input.GetKeyUp(KeyCode.T))
                {
                    audioController.PlayAudio(AudioType.ST_01, true);
                }

                if (Input.GetKeyUp(KeyCode.G))
                {
                    audioController.StopAudio(AudioType.ST_01, true);
                }

                if (Input.GetKeyUp(KeyCode.B))
                {
                    audioController.RestartAudio(AudioType.ST_01, true);
                }
                ///TODO
                //if (Input.GetKeyUp(KeyCode.V))
                //{
                //    audioController.RecordAudio(AudioType.ST_01, true);
                //}
                
                if (Input.GetKeyUp(KeyCode.Y))
                {
                    audioController.PlayAudio(AudioType.SFX_01);
                }

                if (Input.GetKeyUp(KeyCode.H))
                {
                    audioController.StopAudio(AudioType.SFX_01);
                }

                if (Input.GetKeyUp(KeyCode.N))
                {
                    audioController.RestartAudio(AudioType.SFX_01);
                }
                ///TODO
                //if (Input.GetKeyUp(KeyCode.M))
                //{
                //   audioController.RecordAudio(AudioType.SFX_01);
                //}
            }

             
#endif
#endregion
        }

    }
}
