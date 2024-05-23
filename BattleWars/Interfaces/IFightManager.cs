using BattleWars.Models;

namespace BattleWars.Interfaces
{
    public interface IFightManager
    {
        (List<Empire> empires, List<Rebelle> rebelles) FillTeamsWithChoice(int nbEmpires, int nbRebelles);
        string StartFightWithRandomTeam(List<Empire> empires, List<Rebelle> rebelles);
        void VerifyTheWinner(string voteResult, string finalResult);
    }
}
