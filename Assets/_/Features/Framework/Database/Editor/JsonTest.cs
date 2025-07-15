using System;
using Database.Runtime;
using Unity.Plastic.Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

namespace Database.Editor
{
    public class JsonTest : UnityEditor.EditorWindow
    {
        [MenuItem("Custom Tool/JsonTest")]
        public static void CreateWindow()
        {
            _window = EditorWindow.GetWindow(typeof(JsonTest), true, "Json Test Window");
            _window.Show();
        }

        private void OnGUI()
        {
            // GUILayout.Button("Hello");
            _jsonContent = GUILayout.TextArea($"{_jsonContent}");

            if (GUILayout.Button("Deserialize"))
            {
                _output = JsonConvert.DeserializeObject<SaveFile>(_jsonContent);
            }
            if(_output != null) GUILayout.Label(_output.ToString());
            if(_output != null) GUILayout.Label(_output.Facts.Count.ToString());
        }

        private static EditorWindow _window;
        private static string _jsonContent = "{\n  \"CounterTest/Int\": {\n    \"JsonValue\": 1,\n    \"ValueType\": \"System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\",\n    \"IsPersistent\": true\n  }\n}\n";
        private static SaveFile _output;
    }
}
