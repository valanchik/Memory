using Ecs;
using UnityEngine;

namespace Game
{
    public interface IGameStorage
    {
        void SavePoints(int points);
        int GetPoins();
    }
    public class GameStorage: IGameStorage
    {
        public void SavePoints(int points)
        {
            PlayerPrefs.SetInt("points", points);
        }

        public int GetPoins()
        {
            return PlayerPrefs.GetInt("points");
        }
    }
}