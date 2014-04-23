namespace GameFifteen
{
    using System;
    using System.Text;

    public static class Messages
    {
        public static string GetCellDoesNotExistMessage()
        {
            return "That cell does not exist in the matrix.";
        }

        public static string GetGoodbye()
        {
            return "Good bye!";
        }

        public static string GetIllegalCommandMessage()
        {
            return "Illegal command!";
        }

        public static string GetIllegalMoveMessage()
        {
            return "Illegal move!";
        }

        public static string GetNextMoveMessage()
        {
            return "Enter a number to move: ";
        }

        public static string GetWelcomeMessage()
        {
            StringBuilder welcomeMessage = new StringBuilder();

            welcomeMessage.AppendLine("Welcome to the Game \"15\".");
            welcomeMessage.AppendLine("Please try to arrange the numbers sequentially.");
            welcomeMessage.AppendLine("Menu:");
            welcomeMessage.AppendLine("top - view the top scoreboard");
            welcomeMessage.AppendLine("restart - start a new game");
            welcomeMessage.Append("exit - quit the game");

            return welcomeMessage.ToString();
        }

        public static string GetCongratsMessage(string moves)
        {
            return "Congratulations! You won the game in " + moves + ".";
        }

        public static string GetSorrowMessage(int topScoresCount)
        {
            return "You couldn't get in the top " + topScoresCount + " scoreboard.";
        }

        public static string GetMessageRequestToEnterName()
        {
            return "Please enter your name for the top scoreboard: ";
        }
    }
}