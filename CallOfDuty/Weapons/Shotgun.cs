namespace CallOfDuty.Weapons
{
    public class Shotgun : Weapon
    {
        public const int Shotgun_Damage_Points = 10;

        public Shotgun()
        {
            _damagePoints = Shotgun_Damage_Points;
            _maxAmmo = 50;
            ammoRemaining = 1;
        }

    }
}
