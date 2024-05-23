namespace BattleWars.Interfaces
{
    public interface IStartManager
    {
        void StartMessage();
        (int rebellesNumber, int empireNumber) DefineSizeTeams();
        string UserVote();
        bool Replay();
    }
}
