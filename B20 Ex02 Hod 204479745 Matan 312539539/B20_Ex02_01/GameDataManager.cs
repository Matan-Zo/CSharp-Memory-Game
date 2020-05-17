namespace B20_Ex02_01
{
    using System.Collections.Generic;
    class GameDataManager
    {
        private List<Player> m_GamePlayers;
        private Player m_CurrentPlayerTurn;
        private Board m_VisualBoard;
        private Board m_DataBoard;
        private AIPlayer m_AiPlayer;
        private int m_GameMode;
        private Tile[] m_LastTilePicked;
        private int m_NumberOfExposedTiles;

        public GameDataManager()
        {
            m_GameMode = 0;
            m_NumberOfExposedTiles = 0;
            generateAllPlayers();
            generateLastPickedTiles();
        }

        private void generateAllPlayers()
        {
            m_GamePlayers = new List<Player>(2);
            for (int i = 0; i < m_GamePlayers.Count; i++)
            {
                m_GamePlayers[i] = new Player();
            }

            m_CurrentPlayerTurn = m_GamePlayers[0];
        }

        private void generateLastPickedTiles()
        {
            m_LastTilePicked = new Tile[2];
            for (int i = 0; i < m_LastTilePicked.Length; i++)
            {
                m_LastTilePicked[i] = new Tile();
            }
        }

        public int GameMode
        {
            get
            {
                return m_GameMode;
            }
            set
            {
                m_GameMode = value;
            }
        }

        public List<Player> GamePlayers
        {
            get
            {
                return m_GamePlayers;
            }
        }

        public string PlayerName
        {
            set
            {
                foreach (Player GamePlayer in m_GamePlayers)
                {
                    if(GamePlayer.Name == string.Empty)
                    {
                        GamePlayer.Name = value;
                        break;
                    }
                }
            }
        }

        public Board VisualBoardMatrix
        {
            get
            {
                return m_VisualBoard.VisualMatrix;
            }
        }

        public void MakeAIPlayer()
        {
            m_AiPlayer = new AIPlayer();
            m_GamePlayers[1].Name = "[AI]";
            m_GamePlayers[1].IsHuman = false;
        }

        public void SetDataForNewGame()
        {
            foreach (Player GamePlayer in m_GamePlayers)
            {
                GamePlayer.Score = 0;
            }
        }

        public void GenerateBoards(Coordinate i_BoardDimensions)
        {
            m_VisualBoard = new Board(i_BoardDimensions);
            m_DataBoard = new Board(i_BoardDimensions);
            m_DataBoard.FillBoardRandomly();

            if (GameMode == 2)
            {
                m_AiPlayer.GenerateAiBoard(i_BoardDimensions);
            }
        }

        public bool CheckIfCurrentPlayerCorrect()
        {
            bool isCorrect = false;
            char TileData1 = m_DataBoard.GetTileDataAtLocation(m_LastTilePicked[0].Location);
            char TileData2 = m_DataBoard.GetTileDataAtLocation(m_LastTilePicked[1].Location);

            if (TileData1 == TileData2)
            {
                isCorrect = true;
            }

            return isCorrect;
        }

        public void IncrementCurrentPlayerScore()
        {
            m_CurrentPlayerTurn.Score++;
        }

        public bool CheckIfCurrentPlayerHuman()
        {
            return m_CurrentPlayerTurn.IsHuman;
        }

        public void SetChosenTileAsShown(string i_TileLocatin, int i_TileNumber)
        {
            Coordinate pickedTileLocation = new Coordinate();
            pickedTileLocation = convertStringToCoordinate();
            char Data = m_DataBoard.GetDataAtLocation(pickedTileLocation);
            m_VisualBoard.SetDataAtLocation(Data, pickedTileLocation);
            m_LastTilePicked[i_TileNumber].SetTile(Data, pickedTileLocation);
        }

        public bool CheckIfGameOver()
        {
            bool isGameOver = false;

            if (m_NumberOfExposedTiles == m_DataBoard.Height * m_DataBoard.Width)
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        public void ChangeTurn()
        {
            if (m_CurrentPlayerTurn.Equals(m_GamePlayers[0]))
            {
                m_CurrentPlayerTurn = m_GamePlayers[1];
            }
            else
            {
                m_CurrentPlayerTurn = m_GamePlayers[0];
            }
        }
    }
}
