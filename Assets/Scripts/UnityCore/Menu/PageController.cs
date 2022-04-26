using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Renaissance Coders
//#unity3d #menu #tutorial
//How To Code a Robust Menu System In Unity3D, Game Essentials (1/5)
//https://www.youtube.com/watch?v=qkKuGmGRF2k&t=1s

namespace UnityCore 
{
    namespace Menu 
    {

        public class PageController : MonoBehaviour
        {
            /*public static PageController instance;

            public bool debug;
            public PageType entryPage;
            public Page[] pages;

            private Hashtable m_Pages;     //Utilises the relationship between the page types and pages.

            #region Unity Functions
            private void Awake()
            {
                if (!instance)
                {
                    !instance = this;
                    m_Pages = new Hashtable();
                    RegisterAllPages();
                    if (entryPage != PageType.None)
                    {
                        TurnPageOn(entryPage);
                    }
                }
            }
            #endregion

            #region Public Functions

            public void TurnPageOn(PageType _type)
            {
                if (_type == PageType.None)
                {
                    return;
                }
                if (!pageExists(_type))
                {
                    LogWarning("You are trying to turn a non-registered page on [" + _type + "] .");
                    return;
                }
                Page _page = GetPage(_type);
                _page.gameObject.SetActive(true);
                _page.Animate(true);
            }

            public void TurnPageOff(PageType _off, PageType _on = PageType.None, bool _waitForExit = false)
            {
                if (_off == PageType.None) 
                { 
                    return;                 
                }
                if (!pageExists(_off))
                {
                    LogWarning("You are trying to turn a non-registered page off [" + _off + "] .");
                    return;
                }
                Page _offPage = GetPage(_off);
                if (_offPage.gameObject.activeSelf) 
                { 
                _offPage.Animate(false);
                }
                Page _onPage = GetPage(_on);
                if (_waitForExit)
                {
                   
                    StopCoroutine("WaitForPageExit");
                    StartCoroutine(WaitForPageExit(_onPage, _offPage));
                }
                else 
                {
                    TurnPageOn(_on);
                }
            }
            #endregion

            #region Privat Functions

            private IEnumerator WaitForPageExit(Page _on, Page _off)
            {
                while (_off.targetState != Page.FLAG_NONE) 
                { 
                yield return null;
                }
                TurnPageOn(_on.type);
            }


            private void RegisterAllPages()
            {
                foreach (Page _page in _pages)
                {
                    RegisterPage(_page);
                }
            }

            private void RegisterPage(Page _page)
            {
                if (PageExists(_page.type))
                {
                    LogWarning("Your are trying to register a ["+_page.type+"] that has already been registered:"+_page.gameObject.name);
                }
                m_Pages.Add(_page.type, _page);
                Log("Registered new page ["+_page.type+"]");
            }

            private Page GetPage(PageType _type)
            {
                if (!PageExists(_type)) 
                {
                    LogWarning("You are trying to get a page ["+_type+"] that has not been registered.");
                    return null;
                }

                return (Page)m_Pages[_type];
            }

            private bool PageExists(PageType _type) 
            {
                return m_Pages.ContainsKey(_type);
            }

            private void Log(string _msg) 
            {
                if (!debug) 
                { 
                    return;
                }
                Debug.Log("[PageController]: "+_msg);
            }

            private void LogWarning(string _msg)
            {
                if (!debug)
                {
                    return;
                }
                Debug.LogWarning("[PageController]: " + _msg);
            }
            #endregion*/
        }
    }
}
