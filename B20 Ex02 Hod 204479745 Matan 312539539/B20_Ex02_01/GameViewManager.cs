namespace B20_Ex02_01
{
    internal class GameViewManager
    {
        public void ShowMessage(GameMessage.eGameMessageType i_MessageType)
        {

        }

        public string AskAndGetValidInputPlayerName() 
        {
            string playerValidInput = string.Empty;
            GameMessage.AskPlayerName();
            playerValidInput = GameInput.GetValidPlayerName();
            return playerValidInput;
        }

        public int AskAndGetValidInputGameMode()
        {
            int validGameMode = 1;
            GameMessage.AskGameMode();
            validGameMode = GameInput.GetValidGameMode();
            return validGameMode;
        }

        public Coordinate AskAndGetValidInputBoardDimensions()
        {
            Coordinate validBoardDimensions = new Coordinate();
            GameMessage.AskBoardDimensions();
            validBoardDimensions = GameInput.GetValidBoardDimensions();
            return validBoardDimensions;
        }

        public void PrintBoard(char[,] i_VisualBoardMatrixToPrint)
        {

        }

        public string AskAndGetValidPlayerPlay(char[,] i_VisualBoardMatrix, int i_CurrentTurnTileNumberToPlay)
        {
            string validTilePlayerPlayed = string.Empty;
            GameMessage.AskPlayerPlayTile(i_CurrentTileNumberToPlay);
            validTilePlayerPlayed = GameInput.GetValidTilePlay(i_VisualBoardMatrix); // quit input will count as valid here.
            return validTilePlayerPlayed;
        }

        public void HandleQuit() // maybe, not sure yet.
        {

        }

        public bool AskAndGetValidCheckIfPlayingAgain(Player[] i_gamePlayers)
        {
            bool isPlayingAgain = false;
            GameMessage.ShowWinnerAndScore(i_gamePlayers);
            GameMessage.AskIfPlayingAgain();
            isPlayingAgain = GameInput.GetValidIsPlayingAgain();
            return isPlayingAgain;
        }
    }
}
