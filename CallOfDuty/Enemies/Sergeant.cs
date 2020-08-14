using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallOfDuty.Enemies
{
    public class Sergeant : Enemy
    {
        public const int Sergeant_Starting_Energy  = 200;


        public Sergeant()
        {
            EnergyRemaining = Sergeant_Starting_Energy;
        }
    }
}
