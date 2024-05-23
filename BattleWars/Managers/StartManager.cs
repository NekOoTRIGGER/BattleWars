using BattleWars.Interfaces;

namespace BattleWars.NewFolder
{
    public class StartManager : IStartManager
    {
        public void StartMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n--------------------------------------------------------------------------------------");
            Console.WriteLine("Bonjour et bienvenue dans l'espace aujourd'hui vous allez etre le maitre de l'univers.");
            Console.WriteLine("--------------------------------------------------------------------------------------\n\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public (int rebellesNumber, int empireNumber) DefineSizeTeams()
        {
            int rebellesNumber = 0;
            int empireNumber = 0;
            bool isCorrectNumbers = false;

            while (!isCorrectNumbers)
            {
                Console.Write("Veuillez choisir le nombre de soldats Rebelles : ");
                if (int.TryParse(Console.ReadLine(), out rebellesNumber))
                {

                    Console.Write("Veuillez choisir le nombre de soldats de l'empire : ");
                    if (int.TryParse(Console.ReadLine(), out empireNumber))
                    {
                        if (empireNumber <= 0 || rebellesNumber <= 0)
                        {
                            Console.WriteLine("Veuillez entrer un nombre au dessu de 0 pour les deux équipes !");
                            isCorrectNumbers = false;
                        }
                        else
                        {
                            isCorrectNumbers = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Donnée entrée invalide !");
                        isCorrectNumbers = false;
                    }
                }
            }

            return (rebellesNumber, empireNumber);
        }

        public string UserVote()
        {
            string userChoice = "";
            Console.WriteLine("vous pouvez choisir un favoris qui choisissez-vous ?\n" +
                "   1- Rebelles\n" +
                "   2- Empire\n");
            bool chooseOk = false;

            while (!chooseOk)
            {
                Console.Write("les choix correct sont 1 ou 2 : ");
                userChoice = Console.ReadLine();

                if (userChoice == "1")
                {
                    return "1";
                }
                else if (userChoice == "2")
                {
                    return "2";
                }
            }
            return userChoice;
        }

        public bool Replay()
        {
            Console.WriteLine("\nVoulez-vous jouer une nouvelle partie ? (oui / non)");
            string responseForReplay = Console.ReadLine();

            if (responseForReplay.ToUpper() == "OUI")
            {
                Console.Clear();
                return true;
            }
            return false;
        }
    }
}