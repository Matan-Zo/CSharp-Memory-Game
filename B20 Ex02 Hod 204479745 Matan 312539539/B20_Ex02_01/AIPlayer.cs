namespace B20_Ex02_01
{
    using System.Collections.Generic;
    using System;

    internal class AIPlayer
    {
        private Board m_AIBoard;
        private List<Coordinate> m_HiddenTilesList;
        private Coordinate m_SecondTileToPick;
        private Coordinate m_FirstTilePicked;


        public AIPlayer()
        {
            m_SecondTileToPick = new Coordinate();
            m_FirstTilePicked = new Coordinate();
        }

        public void GenerateAiBoard(Coordinate i_BoardDimensions)
        {
            m_AIBoard = new Board(i_BoardDimensions);
            BuildHiddenTileList(i_BoardDimensions);
        }

        private void BuildHiddenTileList(Coordinate i_BoardDimensions)
        {
            m_HiddenTilesList = new List<Coordinate>(i_BoardDimensions.X * i_BoardDimensions.Y);

            for (int i = 0; i < i_BoardDimensions.X; i++)
            {
                for (int j = 0; j < i_BoardDimensions.Y; j++)
                {
                    m_HiddenTilesList.Add(new Coordinate(i, j));
                }
            }
        }

        public Coordinate PickTile(int i_CurrentPickNumber)
        {
            Coordinate pickedCoordinate = new Coordinate();

            if (i_CurrentPickNumber == 1)
            {
                pickedCoordinate.CopyCoordinateData(scanHiddenTilesList());
            }
            else if (i_CurrentPickNumber == 2)
            {
                pickedCoordinate.CopyCoordinateData(checkFirstPickSavedDataAndChooseSecondTile());
                clearSavedTiles();
            }

            if (pickedCoordinate.IsEmpty())
            {
                pickedCoordinate.CopyCoordinateData(chooseRandomUnseenTile());
            }

            m_FirstTilePicked.CopyCoordinateData(pickedCoordinate);

            return pickedCoordinate;
        }

        private Coordinate scanHiddenTilesList()
        {
            Coordinate pickedCoordinate = new Coordinate();

            foreach (Coordinate HiddenTile in m_HiddenTilesList)
            {
                if (m_AIBoard.Matrix[HiddenTile.X, HiddenTile.Y] != Board.getDefaultTileData()
                    && checkIfMatchingTileExists(HiddenTile.X, HiddenTile.Y))
                {
                    pickedCoordinate.CopyCoordinateData(HiddenTile);
                    break;
                }
            }

            return pickedCoordinate;
        }

        private bool checkIfMatchingTileExists(int i_TileX, int i_TileY)
        {
            bool isMatching = false;
            char FirstTile = m_AIBoard.Matrix[i_TileX, i_TileY];

            for (int i = 0; i < m_AIBoard.Height; i++)
            {
                for (int j = 0; j < m_AIBoard.Width; j++)
                {
                    if (m_AIBoard.Matrix[i, j] == FirstTile && i != i_TileX && j != i_TileY)
                    {
                        isMatching = true;
                        m_SecondTileToPick.X = i;
                        m_SecondTileToPick.Y = j;
                        i = j = m_AIBoard.Height + m_AIBoard.Width;
                    }
                }
            }

            return isMatching;
        }

        private Coordinate checkFirstPickSavedDataAndChooseSecondTile()
        {
            Coordinate pickedCoordinate = new Coordinate();

            if (m_SecondTileToPick.IsEmpty())
            {
                pickedCoordinate.CopyCoordinateData(searchForMatchingTile());
            }
            else
            {
                pickedCoordinate.CopyCoordinateData(m_SecondTileToPick);
            }

            return pickedCoordinate;
        }

        private Coordinate searchForMatchingTile()
        {
            Coordinate pickedCoordinate = new Coordinate();
            char firstTilePickedData = m_AIBoard.GetDataAtLocation(m_FirstTilePicked);

            for (int i = 0; i < m_AIBoard.Height; i++)
            {
                for (int j = 0; j < m_AIBoard.Width; j++)
                {
                    if (firstTilePickedData == m_AIBoard.Matrix[i,j] && 
                        (m_FirstTilePicked.X != i || m_FirstTilePicked.Y != j))
                    {
                        pickedCoordinate.X = i;
                        pickedCoordinate.Y = j;
                        i = j = m_AIBoard.Height + m_AIBoard.Width;
                    }
                }
            }

            return pickedCoordinate;
        }

        private Coordinate chooseRandomUnseenTile()
        {
            int maxListSize = m_HiddenTilesList.Count, randomNumber;
            Coordinate tileToChoose = new Coordinate();
            Random randomNumberGenerator = new Random();

            while (tileToChoose.IsEmpty() && maxListSize > 0)
            {
                randomNumber = randomNumberGenerator.Next(maxListSize);
                tileToChoose.CopyCoordinateData(m_HiddenTilesList[randomNumber]);
                if (m_AIBoard.Matrix[tileToChoose.X, tileToChoose.Y] != Board.getDefaultTileData()) // AI tries to find tiles he havn't seen
                {
                    tileToChoose.ClearCoordinateData();
                }
            }

            return tileToChoose;
        }

        public void CopyTileDataToAIBoard(char i_Data, Coordinate i_DataLocationOnBoard)
        {
            m_AIBoard.SetDataAtLocation(i_Data, i_DataLocationOnBoard);
        }

        public void RemoveShownTilesFromList(Coordinate[] i_TilesToRemove)
        {
            foreach (Coordinate ShownTile in i_TilesToRemove)
            {
                foreach (Coordinate TileToDelete in m_HiddenTilesList)
                {
                    if (TileToDelete.X == ShownTile.X && TileToDelete.Y == ShownTile.Y)
                    {
                        m_HiddenTilesList.Remove(TileToDelete);
                        break;
                    }
                }
            }
        }

        public void clearSavedTiles()
        {
            m_FirstTilePicked.ClearCoordinateData();
            m_SecondTileToPick.ClearCoordinateData();
        }
    }
}
