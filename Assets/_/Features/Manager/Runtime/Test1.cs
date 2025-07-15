using Foundation.Runtime;
using UnityEngine;

namespace Manager.Runtime
{
    public class Test1 : FMono
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Info("Starting Test1");
            SetFact("CounterTest/Int", 1, true);
            //InfoDone($"All Facts: {GameFacts.AllFacts.Keys}");
            Save();
        }

        // Update is called once per frame
        void Update()
        {
            Load();
            var counter = GetFact<int>("CounterTest/Int");
            // counter++;
            SetFact("CounterTest/Int", ++counter, true);

            if (counter != 20) return;
            InfoDone($"Reached {counter}");
            // Load();
        }
    }
}
