using jogoDaVelha.Models;
using jogoDaVelha.Utils;

namespace jogoDaVelha
{
    class Program
    {
        public static Player SetPlayer()
        {
            Console.Write("Digite seu nome de usuário: ");
            string username = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string password = Console.ReadLine();

            return Game.FindPlayer(username);
        }

        public static void Main()
        {
            Game game = new();
            Player playerOne = null;
            Player playerTwo = null;

            while (true)
            {
                if (playerOne != null && playerTwo != null)
                {
                    int optionMenuGames = Menus.MenuGames();

                    Console.Clear();

                    switch (optionMenuGames)
                    {
                        case 0:
                            playerOne = null;
                            playerTwo = null;

                            break;
                        case 1:
                            Console.WriteLine("Você escolheu campo minado");
                            break;
                        case 2:
                            Console.WriteLine("Você escolheu jogo da velha");
                            break;
                        case 3:
                            Console.WriteLine("Você escolheu xadrez");
                            break;
                        default:
                            Messages.MessageError("Essa opção não está listada no menu abaixo!");
                            break;
                    }
                }
                else
                {
                    while (true)
                    {
                        int optionMenuInitial = Menus.MenuInitial();

                        Console.Clear();

                        switch (optionMenuInitial)
                        {
                            case 0:
                                Console.WriteLine("Volte sempre meu guerreiro, estaremos esperando você...");
                                break;
                            case 1:
                                Console.WriteLine("== Player 1 ==");
                                playerOne = SetPlayer();

                                Console.WriteLine();

                                Console.WriteLine("== Player 2 ==");
                                playerTwo = SetPlayer();

                                optionMenuInitial = 0;
                                Console.Clear();

                                break;
                            case 2:
                                Console.WriteLine("|| CADASTRO DE JOGADOR ||\n");

                                Console.Write("Informe seu nome completo: ");
                                string full_name = Console.ReadLine();

                                Console.Write("Agora nos informe um nome de usuário: ");
                                string username = Console.ReadLine();

                                Console.Write("Faça uma senha: ");
                                string password = Console.ReadLine();

                                Player player = new(full_name, username, password);

                                Game.AddPlayer(player);

                                Console.Clear();
                                Messages.MessageSuccess("Jogador cadastrado com sucesso!");

                                break;
                            default:
                                Messages.MessageError("Essa opção não está listada no menu abaixo!");
                                break;
                        }

                        if (optionMenuInitial == 0)
                            break;
                    }
                }
            }
        }
    }
}
