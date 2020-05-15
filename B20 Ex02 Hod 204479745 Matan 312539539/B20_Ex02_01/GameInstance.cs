namespace B20_Ex02_01
{
    class GameInstance
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
            makePlayerTwo(); // askAndGetisOtherPlayerHumanFromInput()
            activateAndRunInstance();
            
        }

        private void askAndGetPlayerNameFromInput()
        {
            m_CurrentViewManager.AskForPlayerName();
            m_CurrentDataManager.MakeNewHumanPlayer();
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
