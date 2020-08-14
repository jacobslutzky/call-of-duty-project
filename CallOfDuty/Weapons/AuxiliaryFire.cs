using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.Weapons
{   
    public class AuxiliaryFire : Weapon
    {
        public const int Auxiliary_Fire_Damage_Points = 10;

        public AuxiliaryFire()
        {
            _damagePoints = Auxiliary_Fire_Damage_Points;
            _maxAmmo = 25;
            ammoRemaining = 1;
        }

    }
}
