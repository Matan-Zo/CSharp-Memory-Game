namespace B20_Ex02_01
{
    using System.Collections.Generic;
    using System.Text;

    internal class GameDataManager
    {
        private List<Player> m_GamePlayers;
        private Player m_CurrentPlayerTurn;
        private Board m_VisualBoard;
        private Board m_DataBoard;
        private AIPlayer m_AiPlayer;
        private int m_GameMode;
        private Coordinate[] m_LastTilePicked;
        private int m_NumberOfExposedTiles;

        public GameDataManager()
        {
            m_GameMode = 0;
            m_NumberOfExposedTiles = 0;
            InitiateAllPlayers();
            InitiateLastPickedTiles();
        }

        private void InitiateAllPlayers()
        {
            m_GamePlayers = new List<Player>(2);
            for (int i = 0; i < m_GamePlayers.Capacity; i++)
            {
                m_GamePlayers[i] = new Player();
            }

            m_CurrentPlayerTurn = m_GamePlayers[0];
        }

        private void InitiateLastPickedTiles()
        {
            m_LastTilePicked = new Coordinate[2];
            for (int i = 0; i < m_LastTilePicked.Length; i++)
            {
                m_LastTilePicked[i] = new Coordinate();
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
                    if (string.IsNullOrEmpty(GamePlayer.Name.ToString()))
                    {
                        GamePlayer.Name = value;
                        break;
                    }
                }
            }
        }

        public char[,] VisualBoardMatrix
        {
            get
            {
                return m_VisualBoard.Matrix;
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

        public void GenerateBoards(StringBuilder i_StringBoardDimensions)
        {
            Coordinate boardDimensions = Coordinate.ConvertBoardCoordinateInputToCoordinate(i_StringBoardDimensions);
            m_VisualBoard = new Board(boardDimensions);
            m_DataBoard = new Board(boardDimensions);
            m_DataBoard.FillBoardRandomly();

            if (GameMode == 2)
            {
                m_AiPlayer.GenerateAiBoard(i_StringBoardDimensions);
            }
        }

        public GameMessage.eValidationMessageType CheckIfValid(InputValidator.eValidationType i_CurrentValidationType,
                                                               StringBuilder i_UserInput)
        {
            GameMessage.eValidationMessageType validationType;
            if (i_CurrentValidationType == InputValidator.eValidationType.ValidateTileOnBoard)
            {
                validationType = InputValidator.ValidateInput(i_CurrentValidationType, i_UserInput, m_DataBoard.Size);
            }
            else
            {
                validationType = InputValidator.ValidateInput(i_CurrentValidationType, i_UserInput);
            }
            return validationType;
        }

        public bool CheckIfCurrentPlayerCorrect()
        {
            bool isCorrect = false;
            char TileData1 = m_DataBoard.GetDataAtLocation(m_LastTilePicked[0]);
            char TileData2 = m_DataBoard.GetDataAtLocation(m_LastTilePicked[1]);

            if (TileData1 == TileData2)
            {
                isCorrect = true;
                m_NumberOfExposedTiles = +2;
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

        public void SetChosenTileAsShown(StringBuilder i_TileLocation, int i_CurrentTurnTileNumber)
        {
            Coordinate pickedTileLocation = Coordinate.ConvertBoardCoordinateInputToCoordinate(i_TileLocation);
            showTileOnVisualBoard(pickedTileLocation, i_CurrentTurnTileNumber);

            if (GameMode == 2)
            {
                m_AiPlayer.CopyTileDataToBoard(m_VisualBoard.GetDataAtLocation(pickedTileLocation), pickedTileLocation);
            }
        }

        private void showTileOnVisualBoard(Coordinate i_TileCoordinateToShow, int i_CurrentTurnTileNumber)
        {
            char Data = m_DataBoard.GetDataAtLocation(i_TileCoordinateToShow);
            m_VisualBoard.SetDataAtLocation(Data, i_TileCoordinateToShow);
            m_LastTilePicked[i_CurrentTurnTileNumber].CopyCoordinateData(i_TileCoordinateToShow);
        }

        public void HideCurrentTurnTiles()
        {
            for (int i = 0; i < m_LastTilePicked.Length; i++)
            {
                m_VisualBoard.ClearTileAtLocation(m_LastTilePicked[i]);
            }
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

        /*
        public void AIPlay(int i_CurrentTurnTileNumber)
        {
            Coordinate aiPickedTile = AIPlayer.PickTile(m_VisualBoard); // TEMP NAME
            showTileOnVisualBoard(aiPickedTile, i_CurrentTurnTileNumber);
        }
        */
    }
}
