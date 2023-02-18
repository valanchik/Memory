using System;

namespace Ecs.Components
{
    public struct GameComponent
    {
        public int Pairs;
        public int OpenedPairs;
        public bool Started;
        public DateTime StartTime;
        public TimeSpan DeltaTime;
        public int Steps;
        public int BadSteps;
        public int RecordPoints;
    }
}