using System;

namespace Game
{
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
}