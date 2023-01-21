
namespace jogoDaVelha.Utils
{
    public class Messages
    {
        public static void MessageError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message + "\n");
            Console.ResetColor();
        }

        public static void MessageSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message + "\n");
            Console.ResetColor();
        }
    }
}
