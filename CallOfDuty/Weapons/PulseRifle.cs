using CallOfDuty.Enemies;
using System;
using System.Diagnostics;
using Moq;



namespace CallOfDuty.Weapons
{
    public class PulseRifle : Weapon
    {
        public DateTime StartTime;
        public DateTime EndTime;
        
        public const int Pulse_Rifle_Damage_Points = 300;
        
       
        public PulseRifle()
        {

            _damagePoints = Pulse_Rifle_Damage_Points;
            _maxAmmo = 50;
            ammoRemaining = 1;
            StartTime = DateTime.MinValue;
            EndTime= DateTime.MinValue;
        }

        public override bool Shoot(Enemy enemy)
        {
            if (StartTime == DateTime.MinValue)
            {
                if (ammoRemaining > 0)
                {
                    enemy.ReceiveDamage(_damagePoints);
                    ammoRemaining -= 1;
                    StartTime = DateTime.UtcNow;
                    return true;
                }
            }
            else
            {
                if (ammoRemaining > 0)
                {
                    EndTime = DateTime.UtcNow;

                    var diffInSeconds = EndTime.Subtract(StartTime).TotalSeconds;
               
                    if (diffInSeconds >= 5)
                    {
                        enemy.ReceiveDamage(_damagePoints);
                        ammoRemaining -= 1;
                        StartTime = DateTime.UtcNow;
                        return true;
                    }
                }
            }
            return false;
            
        }
    }
}

