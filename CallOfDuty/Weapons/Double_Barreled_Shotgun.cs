using CallOfDuty.Enemies;
using System.Linq.Expressions;

namespace CallOfDuty.Weapons
{
    public class Double_Barreled_Shotgun : Weapon
    {
        public const int DB_Shotgun_Damage_Points = 60;
        public static int DB_Default_Ammo_Used = 2;
        public Double_Barreled_Shotgun()
        {
            _damagePoints = DB_Shotgun_Damage_Points;
            _maxAmmo = 50;
            ammoRemaining = 2;
        }


        //ToDo make all shoot methods bools and return false if shoot does not work
        public override bool Shoot(Enemy enemy)
        {
            if (ammoRemaining > 0)
            {
                if (ammoRemaining == 1)
                {
                    enemy.ReceiveDamage(_damagePoints);
                    ammoRemaining -= 1;
                }
                else
                {
                    enemy.ReceiveDamage(_damagePoints*DB_Default_Ammo_Used);
                    ammoRemaining -= DB_Default_Ammo_Used;
                }
                return true;
            }
            return false;
        }
    }
}

