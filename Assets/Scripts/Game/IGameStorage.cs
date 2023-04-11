using System.Collections.Generic;

namespace Game
{
    public interface IGameStorage
    {
        bool TrySaveGameResult(GameResult result);
        List<GameResult> GetResultsGame();
        void Reset();
    }
}