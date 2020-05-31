using System;
using System.Collections.Generic;

namespace PMC.ModPatcher.AssetPack
{
    [Serializable]
    public class Waypoint
    {
        public List<int> ConnectedTo = new List<int>();
        public float[] Position;
        public bool IsOuter;
        public bool IsRabbitHoleGoal;
    }
}
