namespace B20_Ex02_01
{
    using System;
    using System.Collections.Generic;

    internal class Board
    {
        private char[,] m_Matrix;
        private static readonly char sr_DefaultData = ' ';

        public Board(Coordinate i_Dimensions)
        {
            m_Matrix = new char[i_Dimensions.X, i_Dimensions.Y];
            for (int i=0; i<m_Matrix.GetLength(0); i++)
            {
                for (int j=0; j<m_Matrix.GetLength(1);j++)
                {
                    m_Matrix[i, j] = sr_DefaultData;
                }
            }
        }

        public char[,] Matrix
        {
            get
            {
                return m_Matrix;
            }
        }

        public int Width
        {
            get
            {
                return m_Matrix.GetLength(0);
            }
        }

        public int Height
        {
            get
            {
                return m_Matrix.GetLength(1);
            }
        }

        public static char getDefualtTileData()
        {
            return sr_DefaultData;
        }

        public char GetDataAtLocation(Coordinate i_Location)
        {
            return m_Matrix[i_Location.X, i_Location.Y];
        }

        public void SetDataAtLocation(char i_Data, Coordinate i_Location)
        {
            m_Matrix[i_Location.X, i_Location.Y] = i_Data;
        }
        
        public void FillBoardRandomly()
        {
            List<Coordinate> availableCoordinates = new List<Coordinate>(Height * Width);
            Random randomLocation = new Random();
            int CoordinateIndex = 0;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    availableCoordinates[i + j] = new Coordinate(i, j);
                }
            }

            for (char letterToFill = 'Z'; availableCoordinates.Count > 0; letterToFill--)
            {
                for (int i = 0; i < 2; i++)
                {
                    CoordinateIndex = randomLocation.Next(availableCoordinates.Count);
                    m_Matrix[availableCoordinates[CoordinateIndex].X, availableCoordinates[CoordinateIndex].Y] = letterToFill;
                    availableCoordinates.RemoveAt(CoordinateIndex);
                }
            }
        }

        public void ClearTileAtLocation(Coordinate i_Location)
        {
            SetDataAtLocation(sr_DefaultData, i_Location);
        }

        public void ClearBoard()
        {
            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    m_Matrix[i, j] = sr_DefaultData;
                }
            }
        }
    }
}
