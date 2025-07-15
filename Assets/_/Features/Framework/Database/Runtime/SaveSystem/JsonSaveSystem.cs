using System;
using System.Collections.Generic;
using System.IO;
using Database.Runtime._.Features.Framework.Database.Runtime.Enums;
using Database.Runtime.Interfaces;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Database.Runtime
{
    public class JsonSaveSystem
    {
        #region Variables

        #region Public

        public string Path { get; private set; }
        
        #endregion
        
        #endregion
        
        #region Main Methods

        // DEPRECATED
        // public T Save<T>(T data)
        // {
        //     try
        //     {
        //         string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
        //         File.WriteAllText(Path, jsonString);
        //         // Info($"Game saved! \n Path: {_filePath}");
        //         return data;
        //     }
        //     catch (Exception ex)
        //     {
        //         // Error($"Error saving game: {ex.Message}");
        //         // throw new Exception(ex.Message);
        //         return default;
        //     }
        // }
 
        // DEPRECATED
        // public T Load<T>()
        // {
        //     try
        //     {
        //         if (!File.Exists(Path))
        //         {
        //             var message = $"File {Path} does not exist";
        //
        //             throw new FileNotFoundException(message);
        //             // todo: call save method on error
        //         }
        //
        //         var jsonString = File.ReadAllText(Path);
        //
        //         return JsonConvert.DeserializeObject<T>(jsonString);
        //     }
        //     catch (FileNotFoundException ex)
        //     {
        //         var defaultSave = Save(default(T));
        //         throw new Exception(ex.Message);
        //         return defaultSave; // return value should be null
        //     }
        //     catch (JsonException ex)
        //     {
        //         //todo: find a way to send error message with return value of null
        //         throw new Exception(ex.Message);
        //     }
        // }
        
        //todo: add way to manage different slots with a SaveSlot class/struct
        public Dictionary<string, IFact> Load(FactDictionary factStore, SaveSlot slot)
        {
            var savePath = GetSavePath(slot);
            if (!File.Exists(savePath))
                throw new FileNotFoundException($"Save {slot} not found.");
            
            var json = File.ReadAllText(savePath);
            // 
            var saveFile = JsonConvert.DeserializeObject<Dictionary<string, SerializableFact>>(json);
            Debug.Log(saveFile);
            // var saveFile = JsonConvert.DeserializeObject<Dictionary<string, IFact>>(json);
            factStore.AllFacts.Clear();

            foreach (var kvp in saveFile)
            {
                // get type from type string
                var type = Type.GetType(kvp.Value.ValueType);
                // deserialize value from json string with proper value type
                var value = JsonConvert.DeserializeObject(kvp.Value.JsonValue, type);
                // create generic Fact with proper type
                var factType = typeof(Fact<>).MakeGenericType(type);
                // create Fact instance with deserialized value
                var fact = (IFact)Activator.CreateInstance(factType, value, kvp.Value.IsPersistent);
                
                //factStore.SetFact(kvp.Key, fact, FactDictionary);
                factStore.AllFacts[kvp.Key] = fact;
            }

            return factStore.AllFacts;
        }

        public string Save(Dictionary<string, IFact> persistentFacts, SaveSlot slot)
        {
            var path = GetSavePath(slot);
            string jsonString = JsonConvert.SerializeObject(persistentFacts, Formatting.Indented);
            File.WriteAllText(path, jsonString);
            return jsonString;
            // Info($"Game saved! \n Path: {_filePath}");
        }
        /*
        Cherif's method: uses a SaveFile class with a SerializableFact in order to
            deserialize Facts from the Json database
            Save file contains a dictionary of <key: string, value: SerializableFact>
            SerializableFact only contains Fact.JsonValue and Fact.JsonValue.Type
            SerializableFact could be a struct

        public static void Load(FactDictionary factStore, SaveSlot slot, string stateId)
        {
            var path = GetSavePath(slot, stateId);
            if (!File.Exists(path))
                throw new FileNotFoundException($"Save state '{stateId}' not found in {slot}");

            var json = File.ReadAllText(path);
            var saveFile = JsonConvert.DeserializeObject<SaveFile>(json);

            factStore.AllFacts.Clear();

            foreach (var kvp in saveFile.Facts)
            {
                var type = Type.GetType(kvp.JsonValue.Type);
                var value = JsonConvert.DeserializeObject(kvp.JsonValue.ValueType, type);
                var factType = typeof(Fact<>).MakeGenericType(type);
                var fact = (IFact)Activator.CreateInstance(factType, value, kvp.JsonValue.IsPersistent);
                factStore.AllFacts[kvp.Key] = fact;
            }
        }*/

        #endregion
        
        #region Utils

        private static string GetSavePath(SaveSlot slot)
        {
            return $"{Application.persistentDataPath}/Save_{slot}.json";
        }
        public void SetPath(string path)
        {
            Path = path;
        }
        #endregion
    }
}