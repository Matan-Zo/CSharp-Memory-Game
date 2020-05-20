namespace B20_Ex02_01
{
    using System;
    using System.Text;
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
            int           rows, cols;
            StringBuilder stringToPrint = new StringBuilder();
            rows = i_VisualBoardMatrixToPrint.GetLength(0);
            cols = i_VisualBoardMatrixToPrint.GetLength(1);
            for (char i = 'A'; i < cols + 'A'; i++)
            {
                stringToPrint.AppendFormat("     {0}", i);
            }

            appendRowBreak(cols, ref stringToPrint);
            for (int i = 0; i < rows; i++)
            {
                stringToPrint.AppendFormat("{0} |", i + 1);
                for (int j = 0; j < cols; j++)
                {
                    stringToPrint.AppendFormat("  {0}  |", i_VisualBoardMatrixToPrint[i, j]);
                }

                appendRowBreak(cols, ref stringToPrint);
            }
            Console.WriteLine(stringToPrint);
        }

        private void appendRowBreak(int i_RowLength, ref StringBuilder io_StringToAppend)
        {
            io_StringToAppend.AppendLine();
            io_StringToAppend.Append("  ");
            io_StringToAppend.Append('=', (i_RowLength * 6) + 1);
            io_StringToAppend.AppendLine();
        }

        public void HandleQuit() // maybe, not sure yet.
        {

        }
    }
}
