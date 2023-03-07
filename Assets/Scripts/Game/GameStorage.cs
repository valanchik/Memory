using System;
using System.Collections.Generic;
using Codice.Client.BaseCommands.Ls;
using Ecs;
using Extensions;
using JetBrains.Annotations;
using Unity.Plastic.Newtonsoft.Json;
using UnityEngine;

namespace Game
{
    public interface IGameStorage
    {
        bool TrySaveGameResult(GameResult result);
        List<GameResult> GetResultsGame();
        void Reset();
    }

    public class GameResult: IEquatable<GameResult>
    {
        public TimeSpan Time { get; set; }
        public int Steps { get; set; }
        public  int ColumnCount { get; set; }

        public bool IsEmpty()
        {
            return Steps <= 0 ? true : false;
        }

        public bool IsBetter(GameResult result)
        {
            if (result==null || IsEmpty()) return false;
            
            if (ColumnCount == result.ColumnCount && ((result.Steps==Steps && Time<result.Time) || Steps<result.Steps))
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Time: {Time.ToString(@"mm\:ss")}, Steps: {Steps}, ColumnCount: {ColumnCount}";
        } 

        public bool Equals(GameResult other)
        {
            if (other == null)
                return false;

            return Time == other.Time && Steps == other.Steps && ColumnCount == other.ColumnCount;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Time, Steps, ColumnCount);
        }
    }

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