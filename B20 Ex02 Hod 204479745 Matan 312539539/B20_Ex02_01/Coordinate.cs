namespace B20_Ex02_01
{
    internal struct Coordinate
    {
        int m_X;
        int m_Y;

        public Coordinate(int i_X = 0, int i_Y = 0)
        {
            m_X = i_X;
            m_Y = i_Y;
        }

        public int X
        {
            get
            {
                return m_X;
            }

            set
            {
                m_X = value;
            }
        }

        public int Y
        {
            get
            {
                return m_Y;
            }

            set
            {
                m_Y = value;
            }
        }
    }
}
