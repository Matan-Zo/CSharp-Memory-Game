namespace B20_Ex02_01
{
    internal class GameViewManager
    {
        public void ShowMessage(GameMessage.eGameMessageType i_MessageType)
        {
            GameMessage.PrintGameMessage(i_MessageType);
        }

        public void ShowValidationMessage(GameMessage.eValidationMessageType i_MessageType)
        {
            GameMessage.PrintValidationMessage(i_MessageType);
        }

        public void PrintBoard(char[,] i_VisualBoardMatrixToPrint)
        {
            
        }

        public void HandleQuit() // maybe, not sure yet.
        {

        }
    }
}
