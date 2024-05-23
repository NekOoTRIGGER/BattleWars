using BattleWars.Interfaces;
using BattleWars.Models;

namespace BattleWars.Business
{
    public class FightManager : IFightManager
    {
        public (List<Empire> empires, List<Rebelle> rebelles) FillTeamsWithChoice(int nbSoldierEmpires, int nbSoldierRebelles)
        {
            List<Empire> empires = new List<Empire>();
            List<Rebelle> rebelles = new List<Rebelle>();

            for (int i = 1; i < nbSoldierEmpires + 1; i++)
            {
                empires.Add(new Empire($"SoldatEmpire{i}", $"MAT{i}"));
            }
            for (int i = 1; i < nbSoldierRebelles + 1; i++)
            {
                rebelles.Add(new Rebelle($"SoldatRebelle{i}", $"MAT{i}"));
            }

            return (empires, rebelles);
        }

        public string StartFightWithRandomTeam(List<Empire> empires, List<Rebelle> rebelles)
        {
            bool whileAgain = true;
            while (whileAgain)
            {
                Random rand = new Random();
                int numberRand = rand.Next(1, 3);
                int numberOfSoldierEmpire = rand.Next(1, empires.Count + 1);
                int numberOfSoldierRebelle = rand.Next(1, rebelles.Count + 1);
                Empire selectedEmpireSoldier = empires.Where(x => x.name == $"SoldatEmpire{numberOfSoldierEmpire}" && x.isDead == false).FirstOrDefault();
                Rebelle selectedRebelleSoldier = rebelles.Where(x => x.name == $"SoldatRebelle{numberOfSoldierRebelle}" && x.isDead == false).FirstOrDefault();

                if (selectedEmpireSoldier == null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("\nLes rebelles gagne");
                    Console.ForegroundColor = ConsoleColor.White;
                    return "1";
                }
                if (selectedRebelleSoldier == null)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.WriteLine("\nL'empire gagne !");
                    Console.ForegroundColor = ConsoleColor.White;
                    return "2";
                }
                switch (numberRand)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        selectedRebelleSoldier.life -= selectedEmpireSoldier.damage;
                        Console.WriteLine(selectedEmpireSoldier.name + " MATRICULE: " + selectedEmpireSoldier.numberId + " : Traitor !");
                        Console.WriteLine(selectedEmpireSoldier.name + " MATRICULE: " + selectedEmpireSoldier.numberId + " Inflige " + selectedEmpireSoldier.damage + " à " + selectedRebelleSoldier.name + " MATRICULE " + selectedRebelleSoldier.numberId + " Vie restante " + selectedRebelleSoldier.life);

                        if (selectedRebelleSoldier.life <= 0)
                        {
                            Console.WriteLine(selectedRebelleSoldier.name + " est mort !");
                            selectedRebelleSoldier.isDead = true;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;

                        selectedEmpireSoldier.life -= selectedRebelleSoldier.damage;
                        Console.WriteLine(selectedRebelleSoldier.name + " MATRICULE: " + selectedRebelleSoldier.numberId + " : Pour la princesse Organa !");
                        Console.WriteLine(selectedRebelleSoldier.name + " MATRICULE: " + selectedRebelleSoldier.numberId + " Inflige " + selectedRebelleSoldier.damage + " à " + selectedEmpireSoldier.name + " MATRICULE " + selectedEmpireSoldier.numberId + " Vie restante " + selectedEmpireSoldier.life);

                        if (selectedEmpireSoldier.life <= 0)
                        {
                            Console.WriteLine(selectedEmpireSoldier.name + " est mort !");
                            selectedEmpireSoldier.isDead = true;
                        }
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    default:
                        break;
                }
            }

            return default;
        }

        public void VerifyTheWinner(string voteResult, string finalResult)
        {
            if (voteResult == finalResult)
            {
                Console.WriteLine("Bravo vous avez gagné le pari !");
            }
            else
            {
                Console.WriteLine("Dommage vous avez perdu le pari !");
            }
        }
    }
}
