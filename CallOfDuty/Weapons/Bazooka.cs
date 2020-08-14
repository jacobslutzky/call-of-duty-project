namespace CallOfDuty.Weapons
{

    public class Bazooka : Weapon
    {
        public const int Bazooka_Damage_Points = 500;
        public Bazooka()
        {
            _damagePoints = Bazooka_Damage_Points;
            _maxAmmo = 2;
            ammoRemaining = 1;
        }
    }
}