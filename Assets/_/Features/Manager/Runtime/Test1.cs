using Foundation.Runtime;
using UnityEngine;

namespace Manager.Runtime
{
    public class Test1 : FMono
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            SetFact("CounterTest/Int", 1, _persistence);
            InfoProgress($"All Facts: {GameFacts.AllFacts.Keys}");
            SaveGame();
        }

        // Update is called once per frame
        void Update()
        {
            var counter = GetFact<int>("CounterTest/Int");
            counter++;
            SetFact("CounterTest/Int", counter, _persistence);

            if (counter == 20)
            {
                InfoProgress($"Reached {counter}");
                LoadGame();
            }
        }
    }
}
