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
                isInstanceActive = askIfPlayerWantsAnotherGame();
            }
            

        }

        private void setNewGameData()
        {
            m_CurrentDataManager.SetDataForNewGame();
        }

        private void buildBoard()
        {
            Point dimension = m_CurrentViewManager.HandleBoardDimension();
            m_CurrentDataManager.SetAllBoardsDimensions(dimension); // update for ai if needed.
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
            showGameOverInformation();
        }

        private void playTurn()
        {
            int     amountOfTilesToPick = 2;
            string  playerInput;
            Tile    pickedTile;
            for (int i = 0; i < amountOfTilesToPick; i++)
            {
                if (m_CurrentDataManager.CheckIfCurrentPlayerHuman())
                {
                    playerInput = m_CurrentViewManager.GetCurrentPlayerPlayInput();
                    CheckIfQAndQuit(playerInput);
                    pickedTile = m_CurrentDataManager.GetTile(playerInput);
                }
                else
                {
                    pickedTile = m_CurrentDataManager.AIPlay();
                }

                m_CurrentViewManager.RevealTile(pickedTile);
            }
        }
    }
}
