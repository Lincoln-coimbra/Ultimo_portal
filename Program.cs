using System;
using RPG_UltimoPortal.Classes;
using RPG_UltimoPortal.Enums;

namespace RPG_UltimoPortal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" BEM-VINDO AO RPG: O ÚLTIMO PORTAL \n");

            Console.WriteLine(" HISTÓRIA:");
            Console.WriteLine("Magos ancestrais deixaram portais para outras dimensões espalhados pelo mundo,");
            Console.WriteLine("mas apenas um ainda permanece ativo. Facções inteiras tentam controlá-lo,");
            Console.WriteLine("acreditando que do outro lado há o segredo da imortalidade.");
            Console.WriteLine("Você deve decidir: explorar esse portal ou impedir que ele seja usado para fins destrutivos.\n");

            // Nome do personagem
            Console.Write("Digite o nome do seu personagem: ");
            string nome = Console.ReadLine();

            // Escolher classe
            Console.WriteLine("\nEscolha sua classe:");
            Console.WriteLine("1 - Guerreiro");
            Console.WriteLine("2 - Mago");
            int classeEscolhida = int.Parse(Console.ReadLine());

            Personagem jogador;
            if (classeEscolhida == 1)
                jogador = new Guerreiro(nome);
            else
                jogador = new Mago(nome);

            // Escolher dificuldade
            Console.WriteLine("\nEscolha a dificuldade:");
            Console.WriteLine("1 - Fácil");
            Console.WriteLine("2 - Médio");
            Console.WriteLine("3 - Difícil");
            int dificuldadeEscolhida = int.Parse(Console.ReadLine());
            DificuldadeEnum dificuldade = (DificuldadeEnum)dificuldadeEscolhida;

            // Criar inimigo com base na dificuldade
            Personagem inimigo = new Guerreiro("Guardião do Portal");

            switch (dificuldade)
            {
                case DificuldadeEnum.Facil:
                    inimigo.Vida = 60;
                    inimigo.Forca = 8;
                    break;
                case DificuldadeEnum.Medio:
                    inimigo.Vida = 100;
                    inimigo.Forca = 12;
                    break;
                case DificuldadeEnum.Dificil:
                    inimigo.Vida = 150;
                    inimigo.Forca = 18;
                    break;
            }

            Console.WriteLine($"\n {jogador.Nome}, sua jornada começa agora. Prepare-se para enfrentar o Guardião do Último Portal!\n");

            // Batalha
            Batalha.Iniciar(jogador, inimigo);

            // Decisão final
            if (jogador.Vida > 0)
            {
                Console.WriteLine("\n Você derrotou o guardião e chegou ao Último Portal...");

                Console.WriteLine("\nO que deseja fazer?");
                Console.WriteLine("1 - Entrar no portal em busca da imortalidade");
                Console.WriteLine("2 - Destruir o portal e proteger o mundo");
                int decisao = int.Parse(Console.ReadLine());

                if (decisao == 1)
                {
                    Console.WriteLine("\n Você atravessa o portal... e seu corpo se transforma em pura energia.");
                    Console.WriteLine("Você agora existe além do tempo, imortal... mas sozinho, em um universo desconhecido.");
                    Console.WriteLine(" FIM: O Imortal Solitário");
                }
                else
                {
                    Console.WriteLine("\n Você canaliza sua energia e destrói o portal com um golpe final.");
                    Console.WriteLine("O mundo está salvo, mas o conhecimento do outro lado se perdeu para sempre.");
                    Console.WriteLine(" FIM: O Guardião da Humanidade");
                }
            }
            else
            {
                Console.WriteLine("\n☠ Você foi derrotado. O portal continua sob controle do Guardião...");
                Console.WriteLine(" FIM: O Mundo à Beira do Caos");
            }

            Console.WriteLine("\n Obrigado por jogar O Último Portal!");
        }
    }
}
