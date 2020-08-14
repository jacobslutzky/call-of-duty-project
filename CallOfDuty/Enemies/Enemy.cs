using System;
namespace CallOfDuty.Enemies
{
    public abstract class Enemy
    {
        public int EnergyRemaining { get; protected set; }
       
        public bool Alive
        {
            get { return EnergyRemaining > 0; }
        }


        public virtual bool ReceiveDamage(int damage)
        {
            if(damage < 0)
            {
                damage *= -1;
            }
            if(EnergyRemaining - damage < 0)
            {
                EnergyRemaining = 0;
                return true;
            }
            else
            {
                EnergyRemaining -= damage;
                return true;
            }
        }


    }
}
