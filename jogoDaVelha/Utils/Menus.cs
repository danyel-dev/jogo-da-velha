
namespace jogoDaVelha.Utils
{
    public class Menus
    {
        public static int MenuInitial()
        {
            Console.WriteLine("1 - Começar uma nova partida");
            Console.WriteLine("2 - Criar uma conta");
            Console.WriteLine(); 
            Console.Write("Informe uma das opções acima (ou digite 0 para sair): ");

            return int.Parse(Console.ReadLine());
        }

        public static int MenuGames()
        {
            Console.WriteLine("1 - Campo minado");
            Console.WriteLine("2 - Jogo da velha");
            Console.WriteLine("3 - Xadrez");
            Console.WriteLine();
            Console.Write("Informe uma das opções acima (ou digite 0 para voltar ao menu anterior): ");

            return int.Parse(Console.ReadLine());
        }
    }
}
