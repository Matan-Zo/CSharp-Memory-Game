﻿namespace B20_Ex02_01
{
    internal class GameDataManager
    {
        private int m_gamemode;
        public int GameMode
        {
            get
            {
                return m_gamemode;
            }
            set
            {
                    m_gamemode = value; 
            }
        }
    }
}
