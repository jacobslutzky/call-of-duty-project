using System;
using CallOfDuty.Enemies;
using CallOfDuty.Weapons.IAttachments;

namespace CallOfDuty.Weapons
{
    public abstract class Weapon
    {
        protected int _damagePoints;
        public int? ammoRemaining;
      

        protected int? _maxAmmo;
       
        //ToDo prevent ammo from being less than or equal to zero
        //ToDo try math.max and math.min
        public bool AddAmmo(int amount)
        {
            if(ammoRemaining + amount > _maxAmmo)
            {
                ammoRemaining = _maxAmmo;
                return true;
            }
            else if(ammoRemaining + amount > 0)
            {
                ammoRemaining += amount;
                return true;
            }
               return false;
            

        }

      
        public void SetAmmo(int amount)
        {
            ammoRemaining = amount;
        }

        //ToDo make shoot a bool and test shoot returns false when ammoRemaining is 0
        public virtual bool Shoot(Enemy enemy)
        {
            if (ammoRemaining > 0)
            {
                enemy.ReceiveDamage(_damagePoints);
                ammoRemaining -= 1;
                return true;
            }
            return false;
        }
       
    }
}

