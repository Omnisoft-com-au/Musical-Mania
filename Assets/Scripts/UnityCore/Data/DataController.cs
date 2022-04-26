
using UnityEngine;

//Renaissance Coders
//How To Code Data Storage In Unity3D, Game Essentials (2/5)
//https://www.youtube.com/watch?v=Vhuf1e0PVH0
// Simple wrapper class for localised data storage
namespace UnityCore
{
    namespace Data
    {
        /*public class DataController : MonoBehaviour
        {
            private static readonly string DATA_SCORE = "score";
            private static readonly string DATA_HIGHSCORE = "highscore";
            private static readonly int DEFAULT_INT = 0;

            #region Properties
            //Testing the ability to add to the score, subtract from
            //the score and clear the score. Also checks if the score
            //is higher than the high score. If so resets it. 
            public int Score
            {
                get {
                    return GetInt(DATA_SCORE);
                }
                set {
                    SaveInt(DATA_SCORE, value);
                    int _score = this.Score;
                    if (_score > this.Highscore) 
                    {
                        this.Highscore = _score;
                    }
                }
            }

            public int Highscore 
            {
                get {
                    return GetInt(DATA_HIGHSCORE);
                }
                private set {
                    SaveInt(DATA_HIGHSCORE, value);
                   
                }
            }
            #endregion
          
            #region Private Functions

            private void SaveInt(string _data, int _value) 
            {
                PlayerPrefs.SetInt(_data, _value);
            }
            //Set default value
            private int GetInt(string _data) 
            {
                //DEFAULT_INT is always 0
                return PlayerPrefs.GetInt(_data, DEFAULT_INT);
            } 

            #endregion

        }*/
    }
}
