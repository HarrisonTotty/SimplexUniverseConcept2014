using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimplexUniverse.Math;

namespace SimplexUniverse.Simulations
{
    public class SimpleBufferedSimulation
    {
        public SimpleBufferedSimulation(int NumberGenerations)
        {
            this.Positions = new List<List<Vector>>(NumberGenerations);
        }
    
        public List<List<Vector>> Positions
        {
            get;
            set;
        }
    }
}
