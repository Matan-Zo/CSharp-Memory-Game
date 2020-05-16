namespace B20_Ex02_01
{
    internal class Tile
    {
        private Coordinate m_LocationOnBoard;
        private char m_Data;

        public Tile()
        {
            m_LocationOnBoard = new Coordinate();
            m_Data = ' ';
        }

        public Coordinate Location
        {
            get
            {
                return m_LocationOnBoard;
            }

            set
            {
                m_LocationOnBoard = value;
            }
        }

        public char Data
        {
            get
            {
                return m_Data;
            }

            set
            {
                m_Data = value;
            }
        }
    }
}