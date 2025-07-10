namespace Foundation.Runtime
{
    public class GameManager : FMono
    {
        #region Private Variables
        
        private static FactDictionary _gameFacts;
        
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

        #endregion
        
    }
}