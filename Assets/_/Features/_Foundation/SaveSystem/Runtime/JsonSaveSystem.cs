using System;
using System.IO;
using SaveSystem.Runtime.Interfaces;
using Unity.Plastic.Newtonsoft.Json;

namespace SaveSystem.Runtime
{
    public class JsonSaveSystem : ISaveSystem
    {
        #region Variables

        #region Private and Protected
        
        #endregion
        
        #region Public

        

        public string Path { get; private set; }
        
        #endregion
        
        #endregion
        
        #region Main Methods

        public T Save<T>(T data)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(Path, jsonString);
                // Info($"Game saved! \n Path: {_filePath}");
                return data;
            }
            catch (Exception ex)
            {
                // Error($"Error saving game: {ex.Message}");
                // throw new Exception(ex.Message);
                return default;
            }
        }
        
        public T Load<T>()
        {
            try
            {
                if (!File.Exists(Path))
                {
                    var message = $"File {Path} does not exist";

                    throw new FileNotFoundException(message);
                    // todo: call save method on error
                }

                var jsonString = File.ReadAllText(Path);

                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (FileNotFoundException ex)
            {
                var defaultSave = Save(default(T));
                return defaultSave; // return value should be null
            }
            catch (JsonException ex)
            {
                //todo: find a way to send error message with return value of null
                return default;
            }
        }

        public void SetPath(string path)
        {
            Path = path;
        }

        #endregion
    }
}