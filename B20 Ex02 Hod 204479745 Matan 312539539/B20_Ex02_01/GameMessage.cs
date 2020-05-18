namespace B20_Ex02_01
{
    internal static class GameMessage
    {
        public static void PrintGameMessage(eGameMessageType i_messageType)
        {
                
        }



        public enum eGameMessageType
        {
            NoMessage,
            GetPlayerName,
            GetGameMode,
            EnterBoardDimensions,
            EnterTiles,
            ShowScoreWithNames,
            AskAnotherGame,
        }

        public enum eValidationMessageType
        {
            Invalid,
            Valid,
            InvalidGameMode,
            InvalidDimensions,
            InvalidTile,
            TileAlreadyShown,
        }

    }
}
