namespace B20_Ex02_01
{
    using System;
    internal static class GameInput
    {
        private static string GetValidInput(eValidInputType i_ValidInputType)
        {
            string playerInput = string.Empty;
            bool   isInputValid = false;
            switch (i_ValidInputType)
            {
                case eValidInputType.PlayerName:
                    break;
                case eValidInputType.GameMode:
                    break;
                case eValidInputType.BoardDimensions:
                    break;
                case eValidInputType.TilePlay:
                    break;
                case eValidInputType.IsPlayingAgain:
                    break;
            }

            return playerInput;

        }

        public static string GetValidPlayerName()
        {
            string playerInput = string.Empty;
            bool   isInputValid = false;
            while(!isInputValid)
            {
                playerInput = Console.ReadLine();
                isInputValid = true;
            }
            return playerInput;
        }

        public static int GetValidGameMode()
        {
            string playerInput = string.Empty;
            bool isInputValid = false;
            while (!isInputValid)
            {
                playerInput = Console.ReadLine();
                
                if (playerInput)
            }

            return playerInput;
        }

        public static Coordinate GetValidBoardDImensions()
        {

        }

        public static string GetValidTilePlay(char[,] i_VisualBoardMatrix)
        {

        }

        public static bool GetValidIsPlayingAgain()
        {

        }

        private enum eValidInputType
        {
            PlayerName,
            GameMode,
            BoardDimensions,
            TilePlay,
            IsPlayingAgain,
        }
    }
}
