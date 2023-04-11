using System.Collections.Generic;
using Extensions;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Game
{
    public class GameStorage: IGameStorage
    {
        private readonly string  _recordKey = "records";
        public bool TrySaveGameResult(GameResult result)
        {
            List<GameResult> list = GetResultsGame();
            var best = list.Find((x) => x.ColumnCount == result.ColumnCount);
            if (best==null)
            {
                list.Add(result);
                SaveListToStorage(list);
                return true;
            }
            if (result.IsBetter(best))
            {
                list.ReplaceAt(best, result);
                SaveListToStorage(list);
                return true;
            }
            return false;
        }

        public List<GameResult> GetResultsGame(){
        
            var str  = PlayerPrefs.GetString(_recordKey);
            if (str == string.Empty)
            {
                return new List<GameResult>();
            }
            else
            {
                return JsonConvert.DeserializeObject<List<GameResult>>(str);
            }
        }

        public void Reset()
        {
            SaveListToStorage(new List<GameResult>());
        }


        private void SaveListToStorage(List<GameResult> list)
        {
            var str = JsonConvert.SerializeObject(list);
            PlayerPrefs.SetString(_recordKey, str);
        }
    }
}