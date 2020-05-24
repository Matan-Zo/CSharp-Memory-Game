namespace B20_Ex02_01
{
    using System;
    using System.Collections.Generic;

    internal class Board
    {
        private static readonly char sr_DefaultData = ' ';
        private char[,]              m_Matrix;
        
        public Board(Coordinate i_Dimensions)
        {
            m_Matrix = new char[i_Dimensions.X, i_Dimensions.Y];
            for (int i = 0 ; i < m_Matrix.GetLength(0) ; i++)
            {
                for (int j = 0 ; j < m_Matrix.GetLength(1) ; j++)
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
                return m_Matrix.GetLength(1);
            }
        }

        public int Height
        {
            get
            {
                return m_Matrix.GetLength(0);
            }
        }

        public Coordinate Size
        {
            get
            {
                return new Coordinate(m_Matrix.GetLength(0), m_Matrix.GetLength(1));
            }
        }

        public static char getDefaultTileData()
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
            List<Coordinate> CoordinatesToShuffle  = new List<Coordinate>(Height * Width);
            Random           randomLocation        = new Random();
            int              randomCoordinateIndex = 0;

            for (int i = 0 ; i < Height ; i++)
            {
                for (int j = 0 ; j < Width ; j++)
                {
                    CoordinatesToShuffle.Add(new Coordinate(i, j));
                }
            }

            for (char letterToFill = 'A' ; CoordinatesToShuffle.Count > 0 ; letterToFill++)
            {
                for (int i = 0 ; i < 2 ; i++)                                               // loop will run 2 times for pairs of letters.
                {
                    randomCoordinateIndex = randomLocation.Next(CoordinatesToShuffle.Count); 
                    m_Matrix[CoordinatesToShuffle[randomCoordinateIndex].X,
                             CoordinatesToShuffle[randomCoordinateIndex].Y] = letterToFill;
                    CoordinatesToShuffle.RemoveAt(randomCoordinateIndex);                   // after using a coordinate from the list, remove it to make sure not to choose it again.
                }
            }
        }

        public void ClearTileAtLocation(Coordinate i_Location)
        {
            ClearTileAtLocation(i_Location.X, i_Location.Y);
        }

        public void ClearTileAtLocation(int i_CoordinateX, int i_CoordinateY)
        {
            m_Matrix[i_CoordinateX, i_CoordinateY] = sr_DefaultData;
        }

        public void ClearBoard()
        {
            for (int i = 0 ; i < this.Height ; i++)
            {
                for (int j = 0 ; j < this.Width ; j++)
                {
                    m_Matrix[i, j] = sr_DefaultData;
                }
            }
        }
    }
}