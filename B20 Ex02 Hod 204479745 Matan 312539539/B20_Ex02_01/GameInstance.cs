namespace B20_Ex02_01
{
    using System.Text;
    using System.Collections.Generic;
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

        private StringBuilder getValidInput(InputValidator.eValidationType i_ValidateType)
        {
            StringBuilder userInput = null;
            GameMessage.eValidationMessageType validationMessage = GameMessage.eValidationMessageType.Invalid;
            while (validationMessage != GameMessage.eValidationMessageType.Valid)
            {
                userInput = m_CurrentViewManager.GetUserInput();
                validationMessage = m_CurrentDataManager.CheckIfValid(i_ValidateType, userInput);
                m_CurrentViewManager.ShowValidationMessage(validationMessage);
            }
            return userInput;
        }

        private void askAndGetPlayerNameFromInput()
        {
            StringBuilder validPlayerName = null;
            m_CurrentViewManager.ShowMessage(GameMessage.eGameMessageType.GetPlayerName);
            validPlayerName = getValidInput(InputValidator.eValidationType.PlayerName);
            m_CurrentDataManager.PlayerName = validPlayerName;
        }

        private void askAndGetGameModeFromInput()
        {
            StringBuilder validGameMode = null;
            m_CurrentViewManager.ShowMessage(GameMessage.eGameMessageType.GetGameMode);
            validGameMode = getValidInput(InputValidator.eValidationType.GameMode);
            m_CurrentDataManager.GameMode = validGameMode;
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
            StringBuilder validDimensions = AskAndGetValidInputBoardDimensions();
            m_CurrentDataManager.GenerateBoards(validDimensions);
            m_CurrentViewManager.PrintBoard(m_CurrentDataManager.VisualBoardMatrix);
        }

        private StringBuilder AskAndGetValidInputBoardDimensions()
        {
            StringBuilder validBoardDimensions = null;
            m_CurrentViewManager.ShowMessage(GameMessage.eGameMessageType.EnterBoardDimensions);
            validBoardDimensions = getValidInput(InputValidator.eValidationType.BoardDimensions);

            //m_CurrentViewManager.ShowMessage(GameMessage.eGameMessageType.EnterBoardRow);
            //validBoardRow = getValidInput(InputValidator.eValidationType.BoardDimensions);
            //m_CurrentViewManager.ShowMessage(GameMessage.eGameMessageType.EnterBoardCollum);
            //validBoardCollum = getValidInput(InputValidator.eValidationType.BoardDimensions);
            //validBoardDimensions.Append(validBoardRow);
            //validBoardDimensions.Append(",");
            //validBoardDimensions.Append(validBoardCollum);
            return validBoardDimensions;
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
            StringBuilder tileLocationInput;
            for (int currentTurnTileNumber = 1; currentTurnTileNumber <= amountOfTilesToPick; currentTurnTileNumber++)
            {
                if (m_CurrentDataManager.CheckIfCurrentPlayerHuman())
                {
                    AskAndGetValidInputPlayerPlay(currentTurnTileNumber, out tileLocationInput);
                    quitIfStringsAreEqual(tileLocationInput); // if Q then exit
                    m_CurrentDataManager.SetChosenTileAsShown(tileLocationInput, currentTurnTileNumber);
                }
                else
                {
                    m_CurrentDataManager.AIPlay(currentTurnTileNumber);
                }

                m_CurrentViewManager.PrintBoard(m_CurrentDataManager.VisualBoardMatrix);
            }
        }

        private void AskAndGetValidInputPlayerPlay(int i_CurrentTurnTileNumber, out StringBuilder o_TileLocationInput)
        {
            GameMessage.eGameMessageType messageType;
            if (i_CurrentTurnTileNumber == 1)
            {
                messageType = GameMessage.eGameMessageType.EnterTileOne;
            }
            else
            {
                messageType = GameMessage.eGameMessageType.EnterTileTwo;
            }

            m_CurrentViewManager.ShowMessage(messageType);
            o_TileLocationInput = getValidInput(InputValidator.eValidationType.GetTileLocation);
        }

        private void quitIfStringsAreEqual(StringBuilder i_FirstStringToCheck)
        {
            // TODO: Move this check to the validator.
            string quitString = "Q";
            if (i_FirstStringToCheck.ToString().CompareTo(quitString) == 0)
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
            List<Player> gamePlayers;
            gamePlayers = m_CurrentDataManager.GamePlayers;
            m_CurrentViewManager.ShowScoreBoard(gamePlayers);
            isPlayingAgain = askAndGetValidInputCheckIfPlayingAgain();
            return isPlayingAgain;
        }

        private bool askAndGetValidInputCheckIfPlayingAgain()
        {
            StringBuilder isPlayingAgain = null;
            bool          convertedIsPlayingAgain = false;
            m_CurrentViewManager.ShowMessage(GameMessage.eGameMessageType.AskAnotherGame);
            isPlayingAgain = getValidInput(InputValidator.eValidationType.IsPlayingAgain);
            convertedIsPlayingAgain = (isPlayingAgain.ToString().CompareTo("true") == 0);
            return convertedIsPlayingAgain;
        }
    }
}
