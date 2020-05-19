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
                case eValidationType.ValidatePlayAgain:
                    messageType = checkIfPlayAgainValid(i_UserInput);
                    break;
            }
            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfPlayerNameValid(StringBuilder i_StringToValidate)
        {
            // TODO: Dont know if we need to validate player name
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
            int boardDimension = -1;

            if (int.TryParse(i_StringToValidate.ToString(), out boardDimension))
            {
                if (boardDimension <= 6 || boardDimension >= 4 || boardDimension != 5)
                {
                    messageType = GameMessage.eValidationMessageType.Valid;
                }

            }

            return messageType;
        }

        private static GameMessage.eValidationMessageType checkIfTileValid(StringBuilder i_StringToValidate)
        {
            // TODO: Still dont know how to check it.
            GameMessage.eValidationMessageType messageType = GameMessage.eValidationMessageType.InvalidTile;
        }

        public enum eValidationType
        {
            None,
            ValidatePlayerName,
            ValidateGameMode,
            ValidateBoardDimensions,
            ValidateTile,
            ValidatePlayAgain,
        }
    }
}
