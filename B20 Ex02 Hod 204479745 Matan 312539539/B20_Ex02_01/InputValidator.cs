namespace B20_Ex02_01
{
    using System.Text;

    internal static class InputValidator
    {  
        private static readonly StringBuilder sr_QuitString = new StringBuilder("Q");

        public static GameMessage.eValidationMessageType ValidateInput(eValidationType i_CurrentValidationType,
                                                                       StringBuilder i_UserInput,
                                                                       char[,] i_VisualBoardMatrix)
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
                    messageType = checkIfTileValid(i_UserInput, i_VisualBoardMatrix);
                    break;
                case eValidationType.ValidateIsPlayingAgain:
                    messageType = checkIfPlayAgainValid(i_UserInput);
                    break;
            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfPlayerNameValid(StringBuilder i_StringToValidate)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.Invalid;

            if (!(string.IsNullOrEmpty(i_StringToValidate.ToString())))
            {
                messageType = GameMessage.eValidationMessageType.Valid;
            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfGameModeValid(StringBuilder i_StringToValidate)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidGameMode;
            int                                gameModeNumber = -1;

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
            GameMessage.eValidationMessageType  messageType = GameMessage.eValidationMessageType.InvalidDimensions;

            if (checkIfBoardDimensionInFormat(i_StringToValidate))
            {
                if (isBoardSizeValid(i_StringToValidate))
                {
                    messageType = GameMessage.eValidationMessageType.Valid;
                }
            }

            return messageType;
        }

        private static bool checkIfBoardDimensionInFormat(StringBuilder i_StringBoardDimension)
        {
            bool isValidFormat = true;

            if (i_StringBoardDimension.Length == 3)
            {
                for (int i = 0 ; i < i_StringBoardDimension.Length ; i += 2)
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
            else
            {
                isValidFormat = false;
            }

            return isValidFormat;
        }

        private static bool isBoardSizeValid(StringBuilder i_ValidDimensionFormat)
        {
            bool       isBoardSizeValid = false;
            Coordinate maxDimension = new Coordinate(6, 6);
            Coordinate minDimension = new Coordinate(4, 4);
            Coordinate dimension = Coordinate.ConvertValidCoordinateFormatToCoordinate(i_ValidDimensionFormat);

            if (Coordinate.CheckIfInRange(dimension, maxDimension, minDimension))
            {
                if (dimension.X != 5 || dimension.Y != 5 )
                {
                    isBoardSizeValid = true;
                }
            }

            return isBoardSizeValid;
        }

        private static GameMessage.eValidationMessageType checkIfTileValid(StringBuilder i_StringToValidate,
                                                                           char[,] i_VisualBoardMatrix)
        { 
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidTile;

            if (checkIfTileFormatValid(i_StringToValidate))
            {
                if (checkIfTileNumbersAreInRangeOfBoard(i_StringToValidate, i_VisualBoardMatrix))
                {
                    if (checkIfTileIsHidden(i_StringToValidate, i_VisualBoardMatrix))
                    {
                        messageType = GameMessage.eValidationMessageType.Valid;
                    }
                    else
                    {
                        messageType = GameMessage.eValidationMessageType.TileAlreadyShown;
                    }
                }
                else
                {
                    messageType = GameMessage.eValidationMessageType.InvalidTileOutOfBounds;
                }
            }
            else if (isPressedQuit(i_StringToValidate))
            {
                messageType = GameMessage.eValidationMessageType.Valid;
            }

            return messageType;
        }

        private static bool checkIfTileNumbersAreInRangeOfBoard(StringBuilder i_TileToCheck,
                                                                char[,] i_VisualBoardMatrix)
        {
            bool       isTileNumbersInRange = false;
            Coordinate tileCoordinate = Coordinate.ConvertTileCoordinateInputToCoordinate(i_TileToCheck);
            Coordinate boardMinRange = new Coordinate(0, 0);
            Coordinate boardMaxRange = new Coordinate(i_VisualBoardMatrix.GetLength(0) - 1,
                                                      i_VisualBoardMatrix.GetLength(1) - 1);

            isTileNumbersInRange = Coordinate.CheckIfInRange(tileCoordinate, boardMaxRange, boardMinRange);

            return isTileNumbersInRange;
        }

        private static bool checkIfTileIsHidden(StringBuilder i_TileToCheck, char[,] i_VisualBoardMatrix)
        {
            Coordinate tileCoordinate = Coordinate.ConvertTileCoordinateInputToCoordinate(i_TileToCheck);
            bool       isTileHidden = (i_VisualBoardMatrix[tileCoordinate.X, tileCoordinate.Y] == 
                                        Board.getDefaultTileData());

            return isTileHidden;
        }

        private static bool checkIfTileFormatValid(StringBuilder i_TileToCheck)
        {
            bool isFormatValid = false;
            int  parseResult = -1;

            if (i_TileToCheck.Length >= 2)
            {
                if (char.IsLetter(i_TileToCheck[0]))
                {
                    if (int.TryParse(i_TileToCheck.ToString().Substring(1, i_TileToCheck.Length - 1),
                        out parseResult))
                    {
                        isFormatValid = true;
                    }
                }
            }

            return isFormatValid;
        }

        private static GameMessage.eValidationMessageType checkIfTileLocationCorrect(StringBuilder i_TileStringLocation, Coordinate i_BoardSize)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidTileOutOfBounds;
            Coordinate                         tileLocation = Coordinate.ConvertTileCoordinateInputToCoordinate(i_TileStringLocation);

            if (tileLocation.X < i_BoardSize.X && tileLocation.Y < i_BoardSize.Y)
            {
                messageType = GameMessage.eValidationMessageType.Valid;
            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfPlayAgainValid(StringBuilder i_PlayAgainInput)
        {
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.Invalid;
            int                                playAgainNumber = -1;

            if (int.TryParse(i_PlayAgainInput.ToString(), out playAgainNumber))
            {
                if (playAgainNumber == 1 || playAgainNumber == 2)
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