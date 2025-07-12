using Fact.Runtime;
using SaveSystem.Runtime;
using UnityEngine;

namespace Foundation.Runtime
{
    public class FMono : MonoBehaviour
    {
        #region Variables

        #region Public
   
        
        
        #endregion

        #region Private and Protected
        [SerializeField, Header("Debug")]
        protected bool m_isVerbose;
        protected static FactDictionary GameFacts => GameSystem.m_gameFacts;
        protected static string _savePath = "SaveData.json";
        protected FactDictionary.FactPersistence _persistence = FactDictionary.FactPersistence.Normal;
   
        // protected static GameSystem System => GameSystem.Instance;

        #endregion
   
        #endregion
   
        #region Fact Dictionary

        protected bool FactExists<T>(string key, out T value)
        {
            GameFacts.FactExists<T>(key, out value);
            return value != null;
        }

        protected void SetFact<T>(string key, T value, FactDictionary.FactPersistence persistence = FactDictionary.FactPersistence.Normal)
        {
            GameFacts.SetFact<T>(key, value, persistence);
        }

        protected T GetFact<T>(string key)
        {
            return GameFacts.GetFact<T>(key);
        }

        protected void RemoveFact<T>(string key)
        {
            GameFacts.RemoveFact<T>(key);
        }

        protected void SetFactPersistence(FactDictionary.FactPersistence persistence)
        {
            _persistence = persistence;
        }
   
        #endregion 
   
        #region Save/Load

        protected void SaveGame()
        {
            InfoInProgress("Saving Game");
            GameSystem.SaveGame();
            InfoDone("Game Saved");
        }
   
        protected void LoadGame()
        {
            InfoInProgress("Loading Game");
            GameSystem.LoadGame();
            InfoDone("Game Loaded");
        }
        #endregion
   
        #region Debug

        protected void Info(string message)
        {
            if (!m_isVerbose) return;
            Debug.Log($"<color=cyan> FROM: {this} | INFO: {message} </color>");
        }
   
        protected void InfoInProgress(string message)
        {
            if (!m_isVerbose) return;
            Debug.Log($"<color=orange> FROM: {this} | IN_PROGRESS: {message} </color>");
        }
        
        protected void InfoDone(string message)
        {
            if (!m_isVerbose) return;
            Debug.Log($"<color=green> FROM: {this} | DONE: {message} </color>");
        }

        protected void Warning(string message)
        {
            if (!m_isVerbose) return;
            Debug.LogWarning($"<color=yellow> FROM: {this} | WARNING: {message} </color>");
        }

        protected void Error(string message)
        {
            if (!m_isVerbose) return;
            Debug.LogError($"<color=red> FROM: {this} | ERROR: {message} </color>");
        }
   
        #endregion
   
  
    }
  
}
