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
            m_CurrentDataManager.PlayerName = (m_CurrentViewManager.AskAndGetValidInputPlayerName());
        }

        private void askAndGetGameModeFromInput()
        {
            m_CurrentDataManager.GameMode = m_CurrentViewManager.AskAndGetValidInputGameMode();

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
                buildDataAndVisualBoard(); // getBoardDimentions() 
                startGame();
                isInstanceActive = GameOver();
            }


        }

        private void setNewGameData()
        {
            m_CurrentDataManager.SetDataForNewGame();
        }

        private void buildDataAndVisualBoard()
        {
            Coordinate dimension = m_CurrentViewManager.AskAndGetValidInputBoardDimension(); // ask ,getInput and show.
            m_CurrentDataManager.GenerateBoards(dimension);
            m_CurrentViewManager.PrintBoard(m_CurrentDataManager.VisualBoardMatrix);
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
                    isGameRunning = !(m_CurrentDataManager.CheckIfGameOver());
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
            int amountOfTilesToPick = 2;
            string tileLocationInput;
            for (int currentTurnTileNumber = 1; currentTurnTileNumber <= amountOfTilesToPick; currentTurnTileNumber++)
            {
                if (m_CurrentDataManager.CheckIfCurrentPlayerHuman())
                {
                    tileLocationInput = m_CurrentViewManager.AskAndGetVaildInputPlayerPlay(m_CurrentDataManager.VisualBoardMatrix, currentTurnTileNumber);
                    quitIfStringsAreEqual(tileLocationInput); // if Q then exit
                    m_CurrentDataManager.SetChosenTileAsShown(tileLocationInput, currentTurnTileNumber);
                }
                else
                {
                    m_CurrentDataManager.AIPlay();
                }

                m_CurrentViewManager.PrintBoard(m_CurrentDataManager.VisualBoardMatrix);
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

        private void sleepThenHideTiles()
        {
            int timeToSleep = 2;
            sleep(timeToSleep);
            m_CurrentDataManager.HideCurrentTurnTiles();
            m_CurrentViewManager.PrintBoard(m_CurrentDataManager.VisualBoardMatrix);
        }

        private bool GameOver()
        {
            int amountOfPlayers = 2;
            bool isPlayingAgain = false;
            Player[] gamePlayers = new Player[amountOfPlayers];
            gamePlayers = m_CurrentDataManager.GamePlayers;
            isPlayingAgain = m_CurrentViewManager.AskAndGetValidInputCheckIfPlayingAgain(gamePlayers);
            return isPlayingAgain;
        }
    }
}