using Database.Runtime;
using UnityEngine;

namespace Foundation.Runtime
{
    public class GameSystem : FMono
    {
        #region Private Variables
        
        private static FactDictionary _gameFacts;
        private static JsonSaveSystem _jsonSaveSystem;
        
        // TODO: make separate class for file saving
        // Systems (FactDictionaries, RegionSelection, Platform, etc.) should be created in separate classes
        // the GameSystem should only implement them so that our FMono simply calls functions
        // all these systems are able to be instantiated in order to have different implementations
        // BUT they should be statically accessible in order to be called from anywhere with our FMono
        // TODO: Use this to implement the localisation
        // For localisation, use an Event to update language without having 
        
        private static readonly string _filePath = $"{Application.persistentDataPath}/{_savePath}";

        
        #endregion

        #region Public Members

        public static FactDictionary m_gameFacts
        {
            get
            {
                if (_gameFacts != null) return _gameFacts;
                _gameFacts = new FactDictionary();
                return _gameFacts;
            }
        }

        public static JsonSaveSystem m_jsonSaveSystem
        {
            get
            {
                if (_jsonSaveSystem != null) return _jsonSaveSystem;
                _jsonSaveSystem = new JsonSaveSystem();
                _jsonSaveSystem.SetPath(_filePath);
                return _jsonSaveSystem;
            }
        }
        
        #endregion

    }
}