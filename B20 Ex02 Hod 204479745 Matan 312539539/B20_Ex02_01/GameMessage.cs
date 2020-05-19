namespace B20_Ex02_01
{
    using System;
    using System.Text;
    internal static class GameMessage
    {
        public static void PrintGameMessage(eGameMessageType i_MessageType)
        {
            switch (i_MessageType)
            {
                case eGameMessageType.GetPlayerName:
                    getPlayerNameMsg();
                    break;
                case eGameMessageType.GetGameMode:
                    getGameModeMsg();
                    break;
                case eGameMessageType.EnterBoardDimensions:
                    enterBoardDimensionsMsg();
                    break;
                case eGameMessageType.EnterTileOne:
                    enterTileMsg(1);
                    break;
                case eGameMessageType.EnterTileTwo:
                    enterTileMsg(2);
                    break;
                case eGameMessageType.AskAnotherGame:
                    askAnotherGameMsg();
                    break;
            }
        }

        private static void getPlayerNameMsg()
        {
            StringBuilder stringToPrint = new StringBuilder("Please enter a name.");
            Console.WriteLine(stringToPrint); 
        }

        private static void getGameModeMsg()
        {
            StringBuilder stringToPrint = new StringBuilder(@"What gamemode would you like to play?
Enter 1 for friend vs friend 
Enter 2 for you vs AI");
            Console.WriteLine(stringToPrint);
        }

        private static void enterBoardDimensionsMsg()
        {
            StringBuilder stringToPrint = new StringBuilder("Please enter the desired board dimensions:");
            Console.WriteLine(stringToPrint);
        }

        private static void enterTileMsg(int i_TileNumberToPrint)
        {
            StringBuilder stringToPrint = new StringBuilder(string.Format("Please enter {0}st tile:", i_TileNumberToPrint));
            Console.WriteLine(stringToPrint);
        }

        private static void askAnotherGameMsg()
        {
            StringBuilder stringToPrint = new StringBuilder("Do you wish to play another round?");
            Console.WriteLine(stringToPrint);
        }


        public enum eGameMessageType
        {
            NoMessage,
            GetPlayerName,
            GetGameMode,
            EnterBoardDimensions,
            EnterTileOne,
            EnterTileTwo,
            ShowScoreWithNames,
            AskAnotherGame,
        }

        public static void PrintValidationMessage(eValidationMessageType i_MessageType)
        {
            switch (i_MessageType)
            {
                case eValidationMessageType.Invalid:
                    invalidInputMsg();
                    break;
                case eValidationMessageType.InvalidGameMode:
                    invalidInputGameModeMsg();
                    break;
                case eValidationMessageType.InvalidDimensions:
                    invalidInputDimensionsMsg();
                    break;
                case eValidationMessageType.InvalidTile:
                    invalidInputTileMsg(1);
                    break;
                case eValidationMessageType.InvalidTileOutOfBounds:
                    invalidInputTileMsg(2);
                    break;
                case eValidationMessageType.TileAlreadyShown:
                    invalidInputTileMsg(3);
                    break;
            }
        }

        private static void invalidInputMsg()
        {
            StringBuilder stringToPrint =new StringBuilder("Invalid input, please type again.");
            Console.WriteLine(stringToPrint);
        }

        private static void invalidInputGameModeMsg()
        {
            StringBuilder stringToPrint = new StringBuilder("Invalid gamemode, please enter either 1 or 2.");
            Console.WriteLine(stringToPrint);
        }

        private static void invalidInputDimensionsMsg()
        {
            StringBuilder stringToPrint = new StringBuilder(@"Invalid dimension.
Please enter dimensions in range of 4x4 to 6x6, excluding 5x5.");
            Console.WriteLine(stringToPrint);
        }

        private static void invalidInputTileMsg(int i_MessageType)
        {
            StringBuilder stringToPrint = new StringBuilder("Invalid Tile, ");
            if (i_MessageType == 2)
            {
                stringToPrint.Append("it is out of bounds.");
            }
            else if (i_MessageType == 3)
            {
                stringToPrint.Append("it is already revealed.");
            }

            stringToPrint.Append("Please type again.");
            Console.WriteLine(stringToPrint);
        }

        public enum eValidationMessageType
        {
            Invalid,
            Valid,
            InvalidGameMode,
            InvalidDimensions,
            InvalidTile,
            InvalidTileOutOfBounds,
            TileAlreadyShown,
        }
    }
}
