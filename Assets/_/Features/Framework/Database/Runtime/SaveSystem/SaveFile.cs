using System;
using System.Collections.Generic;

namespace Database.Runtime
{
    [Serializable]
    public class SaveFile
    {
        public Dictionary<string, SerializableFact> Facts = new();
    }
}