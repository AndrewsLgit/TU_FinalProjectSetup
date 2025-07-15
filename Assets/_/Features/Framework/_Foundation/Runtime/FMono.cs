using System.Collections.Generic;
using Database.Runtime;
using Database.Runtime._.Features.Framework.Database.Runtime.Enums;
using Database.Runtime.Interfaces;
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
        protected static JsonSaveSystem SaveSystem => GameSystem.m_jsonSaveSystem;
        
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

        protected void SetFact<T>(string key, T value, bool isPersistent)
        {
            GameFacts.SetFact<T>(key, value, isPersistent ? FactDictionary.FactPersistence.Persistent : FactDictionary.FactPersistence.Normal);
        }

        protected T GetFact<T>(string key)
        {
            return GameFacts.GetFact<T>(key);
        }

        protected void RemoveFact<T>(string key)
        {
            GameFacts.RemoveFact<T>(key);
        }

        protected void SetFactPersistence(bool isPersistent)
        {
            _persistence = isPersistent ? FactDictionary.FactPersistence.Persistent : FactDictionary.FactPersistence.Normal;
        }
   
        #endregion 
   
        #region Save/Load

        protected void Save()
        {
            InfoInProgress($"Saving Game");
            var saved = SaveSystem.Save(GameFacts.GetPersistentFacts(), SaveSlot.First_Slot);
            InfoDone($"Game saved: {saved}");
        }

        protected void Load()
        {
            InfoInProgress($"Loading Game");
            var loaded = SaveSystem.Load(GameFacts, SaveSlot.First_Slot);
            foreach (var fact in loaded)
            {
                InfoDone($"Fact: {fact.Key} = {fact.Value.GetObjectValue}");
            }
            //InfoDone($"Game loaded: {loaded}");
            
        }

        // protected void SaveGame()
        // {
        //     InfoInProgress("Saving Game");
        //     var savedFacts = GameSystem.SaveGame();
        //     InfoDone("Game Saved: {" + string.Join(", ", savedFacts.Keys) + string.Join(", ", savedFacts.Values) + "}");
        // }
        //todo: remove these methods, they should be handled on the SaveSystem class
        // protected Dictionary<string, IFact> SaveGame()
        // {
        //     InfoInProgress("Saving Game");
        //     var persistentFacts = GameFacts.GetPersistentFacts();
        //     var savedFacts = SaveSystem.Save<Dictionary<string, IFact>>(persistentFacts);
        //     InfoDone("Game Saved: {" + string.Join(", ", savedFacts.Keys) + string.Join(", ", savedFacts.Values) + "}");
        //     //todo: refresh IFact dictionary, when saving/loading 
        //     return persistentFacts;
        // }
        // protected void LoadGame()
        // {
        //     InfoInProgress("Loading Game");
        //     var loadedFacts = GameSystem.LoadGame();
        //     InfoDone("Game Loaded: {" + string.Join(", ", loadedFacts.Keys) + string.Join(", ", loadedFacts.Values) + "}");
        // }
        
        // protected void LoadGame()
        // {
        //     InfoInProgress("Loading Game");
        //     // Activator.CreateInstance
        //     // typeof.makeNewType
        //     var loadedFacts = SaveSystem.Load();
        //     if (loadedFacts == null) return null;
        //
        //     foreach (var fact in loadedFacts)
        //     {
        //         InfoInProgress($"Loading fact: {fact.Key}: {fact.JsonValue}");
        //         GameFacts.SetFact(fact.Key, fact.JsonValue, FactDictionary.FactPersistence.Persistent);;
        //     }
        //     InfoDone("Game Loaded: {" + string.Join(", ", loadedFacts.Keys) + string.Join(", ", loadedFacts.Values) + "}");
        //
        //     return loadedFacts;
        // }
        
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
