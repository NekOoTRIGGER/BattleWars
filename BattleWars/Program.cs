using BattleWars.Business;
using BattleWars.NewFolder;

namespace BattleWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartManager startManager = new StartManager();
            startManager.StartMessage();
            (int rebellesNumber, int empireNumber) sizeTeams = startManager.DefineSizeTeams();
            string voteResult = startManager.UserVote();

            FightManager fightManager = new FightManager();
            (List<Models.Empire> empires, List<Models.Rebelle> rebelles) teams = fightManager.FillTeamsWithChoice(sizeTeams.empireNumber, sizeTeams.rebellesNumber);
            string finalResult = fightManager.StartFightWithRandomTeam(teams.empires, teams.rebelles);
            fightManager.VerifyTheWinner(voteResult, finalResult);

            if (startManager.Replay())
            {
                Main(args);
            }
        }
    }
}
