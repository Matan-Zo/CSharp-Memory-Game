namespace B20_Ex02_01
{
    internal class Player
    {
        private string m_Name;
        private int m_Score;
        private bool m_IsHuman;

        public Player()
        {
            m_Name = "Player";
            m_Score = 0;
            m_IsHuman = true;
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public bool IsHuman
        {
            get
            {
                return IsHuman;
            }

            set
            {
                IsHuman = value;
            }
        }
    }
}
