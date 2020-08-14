using CallOfDuty.Enemies;
using CallOfDuty.IAttachments.Models;
using CallOfDuty.Weapons.IAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.Weapons
{
    public class FireModdableWeapon : Weapon, IFireMode
    {
        protected FireModeEnum FireMode;
        public FireModdableWeapon(FireModeEnum firemode)
        {
            FireMode = firemode;
        }
        public void SetFireMode(FireModeEnum firemode)
        {
            FireMode = firemode;
        }
        public override bool Shoot(Enemy enemy)
        {
            if (ammoRemaining - (int)FireMode >= 0)
            {
                enemy.ReceiveDamage(_damagePoints * (int)FireMode);
                ammoRemaining -= (int)FireMode;
                return true;
            }
            return false;
        }
    }
    
    
}
