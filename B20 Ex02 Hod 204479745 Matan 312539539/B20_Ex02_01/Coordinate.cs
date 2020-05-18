namespace B20_Ex02_01
{
    using System.Text;

    internal class Coordinate
    {
        private int m_X;
        private int m_Y;

        public Coordinate()
        {
            m_X = -1;
            m_Y = -1;
        }

        public Coordinate(int i_X, int i_Y)
        {
            m_X = i_X;
            m_Y = i_Y;
        }

        public void CopyCoordinateData(Coordinate i_CoordinateToCopy)
        {
            X = i_CoordinateToCopy.X;
            Y = i_CoordinateToCopy.Y;
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

        public static Coordinate ConvertStringToCoordinate(StringBuilder i_StringBoardLocation)
        {
            int xCoordinate, yCoordinate;

            if (char.IsUpper(i_StringBoardLocation[0]))
            {
                xCoordinate = i_StringBoardLocation[0] - 'A';
            }
            else
            {
                xCoordinate = i_StringBoardLocation[0] - 'a';
            }

            yCoordinate = (int)char.GetNumericValue(i_StringBoardLocation[1]);

            return new Coordinate(xCoordinate, yCoordinate);
        }
    }
}
