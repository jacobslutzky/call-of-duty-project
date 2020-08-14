using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CallOfDuty.Enemies
{
    public class Tank : Enemy
    {
        public const int Tank_Starting_Energy = 1000;


        public Tank()
        {
            EnergyRemaining = Tank_Starting_Energy;
        }
        public override bool ReceiveDamage(int damage)
        {
            if (damage < 0)
                damage *= -1;
            if (damage >= 500)
            {
                if (EnergyRemaining - damage < 0)
                {
                    EnergyRemaining = 0;
                }
                else
                {
                    EnergyRemaining -= damage;
                }
                return true;
            }
            return false;
        }
    }
}