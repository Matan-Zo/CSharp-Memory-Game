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
                if (value >= 0)
                {
                    m_X = value;
                }
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
                if (value >= 0)
                {
                    m_Y = value;
                }
            }
        }

        public bool IsEmpty()
        {
            bool isEmpty = ((X == -1) && (Y == -1));

            return isEmpty;
        }

        public void ClearCoordinateData()
        {
            m_X = -1;
            m_Y = -1;
        }

        public static Coordinate ConvertTileCoordinateInputToCoordinate(StringBuilder i_StringBoardLocation)
        {
            int xCoordinate, yCoordinate;

            if (char.IsUpper(i_StringBoardLocation[0]))
            {
                yCoordinate = i_StringBoardLocation[0] - 'A';
            }
            else
            {
                yCoordinate = i_StringBoardLocation[0] - 'a';
            }

            xCoordinate = int.Parse(i_StringBoardLocation.ToString().Substring(1, i_StringBoardLocation.Length - 1)) - 1;

            return (new Coordinate(xCoordinate, yCoordinate));
        }

        public static Coordinate ConvertValidCoordinateFormatToCoordinate(StringBuilder i_StringCoordinate)
        {
            int CoordinateX = int.Parse(i_StringCoordinate[0].ToString());
            int CoordinateY = int.Parse(i_StringCoordinate[2].ToString());

            return new Coordinate(CoordinateX, CoordinateY);
        }

        public static bool CheckIfInRange (Coordinate i_CoordToCheck,Coordinate i_MaxCoordRange,
                                           Coordinate i_MinCoordRange)
        {
            bool isInRange = false;

            isInRange = ((i_CoordToCheck.X <= i_MaxCoordRange.X && i_CoordToCheck.Y <= i_MaxCoordRange.Y) &&
                        (i_CoordToCheck.X >= i_MinCoordRange.X && i_CoordToCheck.Y >= i_MinCoordRange.Y));

            return isInRange;
        }
    }
}