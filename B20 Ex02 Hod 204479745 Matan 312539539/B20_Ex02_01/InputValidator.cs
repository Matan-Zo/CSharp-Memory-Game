namespace B20_Ex02_01
{
    using System.Text;

    internal static class InputValidator
    {  
        private static readonly StringBuilder sr_QuitString = new StringBuilder("Q");

        public static GameMessage.eValidationMessageType ValidateInput(eValidationType i_CurrentValidationType, StringBuilder i_UserInput)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.Invalid;
            switch (i_CurrentValidationType)
            {
                case eValidationType.ValidatePlayerName:
                    messageType = checkIfPlayerNameValid(i_UserInput);
                    break;
                case eValidationType.ValidateGameMode:
                    messageType = checkIfGameModeValid(i_UserInput);
                    break;
                case eValidationType.ValidateBoardDimensions:
                    messageType = checkIfBoardDimensionsValid(i_UserInput);
                    break;
                case eValidationType.ValidateTile:
                    messageType = checkIfTileValid(i_UserInput);
                    break;
                case eValidationType.ValidateIsPlayingAgain:
                    messageType = checkIfPlayAgainValid(i_UserInput);
                    break;
            }
            return messageType;
        }

        public static GameMessage.eValidationMessageType ValidateInput(eValidationType i_CurrentValidationType,
                                                                       StringBuilder i_UserInput,
                                                                       Coordinate i_BoardSize)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.Invalid;
            messageType = checkIfTileLocationCorrect(i_UserInput, i_BoardSize);
            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfPlayerNameValid(StringBuilder i_StringToValidate)
        {
            // TODO: Dont know if we need to validate player name
            return GameMessage.eValidationMessageType.Valid;
        }

        private static GameMessage.eValidationMessageType checkIfGameModeValid(StringBuilder i_StringToValidate)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidGameMode;
            int gameModeNumber = -1;

            if (int.TryParse(i_StringToValidate.ToString(), out gameModeNumber))
            {
                if (gameModeNumber >= 1 && gameModeNumber <= 2)
                {
                    messageType = GameMessage.eValidationMessageType.Valid;
                }
            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfBoardDimensionsValid(StringBuilder i_StringToValidate)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidDimensions;
            bool isValid = false;

            isValid = checkIsDimensionInFormat(i_StringToValidate);

            return messageType;
        }

        private static bool checkIsDimensionInFormat(StringBuilder i_StringBoardDimension)
        {
            bool isValidFormat = true;

            if (i_StringBoardDimension.Length > 3)
            {
                isValidFormat = false;
            }
            else
            {
                for (int i = 0; i < i_StringBoardDimension.Length; i += 2)
                {
                    if (!(char.IsDigit(i_StringBoardDimension[i])))
                    {
                        isValidFormat = false;
                        break;
                    }
                }

                if (i_StringBoardDimension[1] != ',')
                {
                    isValidFormat = false;
                }
            }

            return isValidFormat;
        }

        private static bool isBoardSizeValid(StringBuilder i_ValidDimensionFormat)
        {
            bool isBoardSizeValid = true;
            int[] dimensions = new int[2];

            for (int i = 0, j = 0; i < i_ValidDimensionFormat.Length; i+=2)
            {
                dimensions[j++] = int.Parse(i_ValidDimensionFormat[i].ToString());
            }

            if (dimensions[0] >= 4 && dimensions[0] <= 6 && dimensions[1] >=4 && dimensions[1] <=6)
            {
                if (dimensions[0] != 5 || dimensions[1] != 5 )
                {
                    isBoardSizeValid = true;
                }
            }

            return isBoardSizeValid;
        }

        private static GameMessage.eValidationMessageType checkIfTileValid(StringBuilder i_StringToValidate)
        { 
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidTile;

            if (i_StringToValidate.Length < 2)
            {
                if (char.IsLetter(i_StringToValidate[0]))
                {
                    if (char.IsDigit(i_StringToValidate[1]))
                    {
                        messageType = GameMessage.eValidationMessageType.Valid;
                    }
                }
            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfTileLocationCorrect(StringBuilder i_TileStringLocation, Coordinate i_BoardSize)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidTileOutOfBounds;
            Coordinate tileLocation = Coordinate.ConvertBoardCoordinateInputToCoordinate(i_TileStringLocation);

            if (tileLocation.X < i_BoardSize.X && tileLocation.Y < i_BoardSize.Y)
            {
                messageType = GameMessage.eValidationMessageType.Valid;
            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfPlayAgainValid(StringBuilder i_PlayAgainInput)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.Invalid;
            int playAgainNumber = -1;
            if (int.TryParse(i_PlayAgainInput.ToString(), out playAgainNumber))
            {
                if (playAgainNumber >= 1 && playAgainNumber <= 2)
                {
                    messageType = GameMessage.eValidationMessageType.Valid;
                }
            }

            return messageType;
        }

        public static bool isPressedQuit(StringBuilder i_StringUserInput)
        {
            bool isPressed = false;

            if (i_StringUserInput.ToString().CompareTo(sr_QuitString.ToString()) == 0)
            {
                isPressed = true;
            }

            return isPressed;
        }

        public enum eValidationType
        {
            None,
            ValidatePlayerName,
            ValidateGameMode,
            ValidateBoardDimensions,
            ValidateTile,
            ValidateTileOnBoard,
            ValidateIsPlayingAgain,
        }
    }
}
