using CallOfDuty.Enemies;

namespace CallOfDuty.Weapons
{
    public class Knife : Weapon
    {
        public const int Knife_Damage_Points = 10;
        public Knife()
        {
            _damagePoints = Knife_Damage_Points;
            ammoRemaining = null;
            _maxAmmo = null;
       

        }

        public override bool Shoot(Enemy enemy)
        {
            enemy.ReceiveDamage(_damagePoints);
            return true;
        }
    }
}