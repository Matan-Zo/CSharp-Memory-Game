namespace B20_Ex02_01
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Ex02.ConsoleUtils;
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

        private void clearView()
        {
            Screen.Clear();
        }

        private void printBoard(char[,] i_VisualBoardMatrixToPrint)
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

        public StringBuilder GetUserInput()
        {
            StringBuilder userInput = new StringBuilder();
            userInput.Append(Console.ReadLine());

            return userInput;
        }

        public void UpdateAndShowTurnScreen(Player i_CurrentPlayer, char[,] i_VisualBoardMatrix)
        {
            clearView();
            printBoard(i_VisualBoardMatrix);
            printCurrentPlayerNameAndScore(i_CurrentPlayer);
        }

        private void printCurrentPlayerNameAndScore(Player i_CurrentPlayer)
        {
            StringBuilder stringToPrint = new StringBuilder();
            stringToPrint.AppendFormat("Current Turn --> {0} : {1}", i_CurrentPlayer.Name, i_CurrentPlayer.Score);
            Console.WriteLine(stringToPrint);
        }

        public void ClearViewAndShowScores(List<Player> i_PlayersList)
        {
            clearView();
            showScores(i_PlayersList);
        }

        private void showScores(List<Player> i_PlayersList)
        {
            StringBuilder stringToPrint = new StringBuilder();
            stringToPrint.AppendFormat("{0}:{1}. {2}:{3}.", i_PlayersList[0].Name, i_PlayersList[0].Score,
                                                            i_PlayersList[1].Name, i_PlayersList[1].Score);
            stringToPrint.AppendLine();
            if (i_PlayersList[0].Score > i_PlayersList[1].Score)
            {
                stringToPrint.AppendFormat("The Winner is {0}!", i_PlayersList[0].Name);
            }
            else if (i_PlayersList[0].Score < i_PlayersList[1].Score)
            {
                stringToPrint.AppendFormat("The Winner is {0}!", i_PlayersList[1].Name);
            }
            else
            {
                stringToPrint.AppendFormat("It is a draw! Outstanding!!");
            }

            Console.WriteLine(stringToPrint);
        }
    }
}
