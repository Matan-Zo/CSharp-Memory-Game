namespace B20_Ex02_01
{
    public class Program
    {
        public static void Main()
        {
            launchGame();   
        }

        private static void launchGame()
        {
            GameInstance currentGame = new GameInstance();
            currentGame.InitiateGame();
        }
    }
}