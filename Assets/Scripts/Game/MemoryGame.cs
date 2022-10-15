using System;
using System.Collections;
using System.Collections.Generic;
using Extensions;
using UnityEditor;
using UnityEngine;

namespace Game
{
    public class MemoryGame
    {
        private readonly List<Position> list = new List<Position>();
        private Position _lastOpenPosition = null;
        private readonly List<Position> _lastStates = new List<Position>();
        public MemoryGame(int countPairs)
        {
            NewGame(countPairs);
        }
        public void NewGame(int countPairs)
        {
            ResetList(); 
            CreatePairs(countPairs);
            randomizeList();
        }
        public bool Open(int index)
        {
            var pos = list.Find(p => p.Index == index);
            if (pos != null && pos.IsNotOpen())
            {
                pos.Open();
                _lastStates.Add(pos);
                if (_lastOpenPosition!=null && _lastOpenPosition.Value != pos.Value)
                {
                    _lastOpenPosition.Hide();
                    _lastStates.Add(_lastOpenPosition);
                }
                else
                {
                    pos.FixPosition();
                    _lastOpenPosition?.FixPosition();
                    return true;
                }
                _lastOpenPosition = pos;
                return true;
            }
            return false;
        }
        public List<Position> GetNewState()
        {
            var l = new List<Position>();
            foreach (var position in _lastStates)
            {
                l.Add(position);
            }
            _lastStates.Clear();
            return l;
        }
        private void ResetList()
        {
            list.Clear();
        }
        private void CreatePairs(int countPairs)
        {
            for (var i = 0; i < countPairs; i++)
            {
                list.Add(new Position(i, i, false));
                list.Add(new Position(i+1, i, false));
            }    
        }
        private void randomizeList()
        {
            list.Shuffle();
        }
    }
}

