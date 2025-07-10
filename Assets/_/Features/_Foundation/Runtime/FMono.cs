using Foundation.Runtime;
using UnityEngine;

public class FMono : MonoBehaviour
{
   #region Variables

   public enum FactPersistence
   {
      Normal,
      Persistent,
   }

   [SerializeField, Header("Debug")]
   protected bool m_isVerbose;
   
   #endregion
   
   #region Fact Dictionary

   protected bool FactExists<T>(string key, out T value)
   {
      GameFacts.FactExists<T>(key, out value);
      return value != null;
   }

   protected void SetFact<T>(string key, T value, FactPersistence persistence = FactPersistence.Normal)
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
   
   protected FactDictionary GameFacts => GameManager.m_gameFacts;
   
   #endregion 
   
   #region Debug
   
   protected void Info(string message)
   {
      if (!m_isVerbose) return;
      Debug.Log($"FROM: {this} | INFO: {message}");
   }

   protected void Warning(string message)
   {
      if (!m_isVerbose) return;
      Debug.LogWarning($"FROM: {this} | WARNING: {message}");
   }

   protected void Error(string message)
   {
      if (!m_isVerbose) return;
      Debug.LogError($"FROM: {this} | ERROR: {message}");
   }
   
   #endregion
   
  
}
