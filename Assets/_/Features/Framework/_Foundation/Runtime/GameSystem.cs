using Database.Runtime;
using UnityEngine;

namespace Foundation.Runtime
{
    public class GameSystem : FMono
    {
        #region Variables
        // Start of the Variables region
        #region Private
        // Start of the Private region
        
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

        // End of the Private region
        #endregion

        #region Public
        // Start of the Public region
        
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
        
        // End of the Public region
        #endregion
        
        // End of the Variables region
        #endregion

    }
}