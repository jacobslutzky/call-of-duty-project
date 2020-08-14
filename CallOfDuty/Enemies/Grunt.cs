using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallOfDuty.Enemies
{
    public class Grunt : Enemy
    {
        public const int Grunt_Starting_Energy = 1000;

        public Grunt()
        {
            EnergyRemaining = Grunt_Starting_Energy;
        }
    }
}
