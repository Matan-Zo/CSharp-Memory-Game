namespace B20_Ex02_01
{
    internal class GameInstance
    {
        private GameDataManager m_CurrentDataManager;
        private GameViewManager m_CurrentViewManager;
        public GameInstance()
        {
            m_CurrentDataManager = new GameDataManager();
            m_CurrentViewManager = new GameViewManager();
        }

        public void InitiateGame()
        {
            askAndGetPlayerNameFromInput();
            askAndGetGameModeFromInput();
            makePlayerTwo(); // askAndGetisOtherPlayerHumanFromInput()
            activateAndRunInstance();
            
        }

        private void askAndGetPlayerNameFromInput()
        {
            m_CurrentDataManager.PlayerName = (m_CurrentViewManager.HandlePlayerName());
        }

        private void askAndGetGameModeFromInput()
        {
            m_CurrentDataManager.GameMode = m_CurrentViewManager.HandleGameMode();
            
        }

        private void makePlayerTwo()
        {
            if (m_CurrentDataManager.GameMode == 1)
            {
                askAndGetPlayerNameFromInput();
            }
            else
            {
                m_CurrentDataManager.MakeAIPlayer();
            }
        }

        private void activateAndRunInstance()
        {
            bool isInstanceActive = true;
            while (isInstanceActive)
            {
                setNewGameData();
                buildBoard(); // getBoardDimentions() 
                startGame();
                showGameOverInformation();
                isInstanceActive = askIfPlayerWantsAnotherGame();
            }
            

        }

        private void setNewGameData()
        {
            m_CurrentDataManager.SetDataForNewGame();
        }

        private void buildBoard()
        {
            Dimension dimension = m_CurrentViewManager.HandleBoardDimensionAndShowBoard(); // ask ,getInput and show.
            m_CurrentDataManager.SetAllBoardsDimensions(dimension); // update for ai if needed.
            m_CurrentDataManager.GenerateBoard();
        }

        private void startGame()
        {
            bool isGameRunning = true;
            while (isGameRunning)
            {
                playTurn();
                if (m_CurrentDataManager.CheckIfCurrentPlayerCorrect())
                {
                    m_CurrentDataManager.IncrementCurrentPlayerScore();
                    isGameRunning = m_CurrentDataManager.CheckIfGameOver();
                }
                else
                {
                    sleepThenHideTiles();
                    m_CurrentDataManager.ChangeTurn();
                }
            }
            
        }

        private void playTurn()
        {
            int     amountOfTilesToPick = 2;
            string  tileLocationInput;
            Tile    pickedTile = new Tile();
            for (int i = 0; i < amountOfTilesToPick; i++)
            {
                if (m_CurrentDataManager.CheckIfCurrentPlayerHuman())
                {
                    tileLocationInput = m_CurrentViewManager.HandlePlayerPlay();
                    quitIfStringsAreEqual(tileLocationInput);
                    pickedTile = m_CurrentDataManager.GetTileFromBoard(tileLocationInput); 
                }
                else
                {
                    pickedTile = m_CurrentDataManager.AIPlay();
                }

                m_CurrentViewManager.RevealTile(pickedTile);
            }
        }

        private void quitIfStringsAreEqual(string i_FirstStringToCheck)
        {
            string quitString = "Q";
            if (i_FirstStringToCheck.CompareTo(quitString) == 0)
            {
                m_CurrentViewManager.HandleQuit(); 
                System.Environment.Exit(0);
            }
            
        }

        private void waitThenHideTiles()
        {
            Tile tilesToHide[] = new Tile[2];
            tilesToHide = m_CurrentDataManager.TilesToHide;
            m_CurrentViewManager.SleepThenHideTiles(2,tilesToHide);
        }

        private void showGameOverInformation()
        {
            Player gamePlayers[] = new Player[2];
            gamePlayers = m_CurrentDataManager.GamePlayers;
            m_CurrentViewManager.HandleGameOver(playersList);
        }
    }
}
