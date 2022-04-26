using System.Collections;
using UnityEngine;

//Renaissance Coders
//#unity3d #menu #tutorial
//How To Code a Robust Menu System In Unity3D, Game Essentials (1/5)
//https://www.youtube.com/watch?v=qkKuGmGRF2k&t=1s

namespace UnityCore {
    namespace Menu
    {
        public class Page : MonoBehaviour
        {
            /*//Read only strings
            public static readonly string FLAG_ON = "On";
            public static readonly string FLAG_OFF = "Off";
            public static readonly string FLAG_NONE = "None";

            public bool debug;
            public PageType type;
            public bool useAnimation;
            public string targetState{ get; private set;}
            public bool Debug { get => debug; set => debug = value; }

            private Animator m_Animator;

            #region Unity Functions
            private void OnEnable() 
            { 
            CheckAnimatorIntegrity();
            }

            #endregion

            #region Public Functions 
            //Core responsability for the page
            //Handles entrance and exit from view
            public void Animate(bool _on) 
            {
                if (useAnimation)
                {
                    m_Animator.SetBool("on", _on);

                    StopCoroutine("AwaitAnimation");
                    StartCoroutine("AwaitAnimation", _on);
                }
                else
                {
                    if (!_on) 
                    {
                        gameObject.SetActive(false);
                    }
                }
            }
            #endregion

            #region Private Functions
            private IEnumerator AwaitAnimation(bool _on) 
            { 
                targetState = _on ? "FLAG_ON" : "FLAG_OFF";

                //Wait for the animator to reach the target state
                while (!m_Animator.GetCurrentAnimatorStateInfo(0).IsName(targetState)) 
                {
                    yield return null;
                }

                //Wait for the animator to finish animating
                while (m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1) 
                {
                    yield return null;
                }
                targetState = FLAG_NONE;

                Log("Page["+type+"]finished transitioning to "+(_on ?"on" : "off"));

                if (!_on) 
                {
                    gameObject.SetActive(false);
                }
                   
            }

            private void CheckAnimatorIntegrity() 
            {
                if (useAnimation)
                {
                    m_Animator = GetComponent<Animator>();

                    if (m_Animator) 
                    {
                        LogWarning("Please add an animator to the object ("+type+").");
                    }
                }
            }
            
            private void Log(string _msg)
            {
                if (!Debug)
                {
                    return;
                }
                Debug.Log("[Page]: " + _msg);
            }

            private void LogWarning(string _msg)
            {
                if (!Debug)
                {
                    return;
                }
                Debug.LogWarning("[Page]: " + _msg);
            }
            #endregion*/
        }
    }
}
