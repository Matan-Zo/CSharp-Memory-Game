namespace B20_Ex02_01
{
    using System.Text;

    internal class AIPlayer
    {
        private Board m_AiBoard;

        public AIPlayer()
        {

        }

        public void GenerateAiBoard(StringBuilder i_StringBoardDimensions)
        {
            Coordinate boardDimensions = Coordinate.ConvertBoardCoordinateInputToCoordinate(i_StringBoardDimensions);
            m_AiBoard = new Board(boardDimensions);
        }

    }
}
