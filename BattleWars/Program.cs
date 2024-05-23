using BattleWars.Business;
using BattleWars.NewFolder;

namespace BattleWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartManager startBase = new StartManager();

            startBase.StartMessage();
            (int rebellesNumber, int empireNumber) sizeTeams = startBase.DefineSizeTeams();
            string voteResult = startBase.UserVote();


            FightManager fightManager = new FightManager();
            (List<Models.Empire> empires, List<Models.Rebelle> rebelles) teams = fightManager.FillTeamsWithChoice(sizeTeams.empireNumber, sizeTeams.rebellesNumber);
            string finalResult = fightManager.StartFightWithRandomTeam(teams.empires, teams.rebelles);
            fightManager.VerifyTheWinner(voteResult, finalResult);

            if (startBase.Replay())
            {
                Main(args);
            }
            

        }
    }
}
