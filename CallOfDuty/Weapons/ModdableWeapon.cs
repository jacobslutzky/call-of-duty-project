using CallOfDuty.Enemies;
using CallOfDuty.IAttachments.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;

namespace CallOfDuty.Weapons
{
    public abstract class ModdableWeapon : Weapon
    {
        public int FireMode;

        protected double accuracy;
        public List <Barrel> barrelInventory;
        public int CurrentBarrelIndex { get; protected set; }
        protected List<Sight> sightInventory;
        public int CurrentSightIndex { get; protected set; }
        public const int StartingBarrelIndex = 1;
        public const int StartingSightIndex = 1;



        public ModdableWeapon(FireModeEnum firemode = FireModeEnum.SingleShot)
        {
            FireMode = (int)firemode;
            barrelInventory = new List<Barrel>();
            barrelInventory.Add(new Barrel(BarrelEnum.NoBarrel));
            sightInventory = new List<Sight>();
            sightInventory.Add(new Sight(SightEnum.NoSight));
            CurrentBarrelIndex = 0;
            CurrentSightIndex = 0;
          
        }

       
        public bool SetFireMode(FireModeEnum firemode)
        {
            if (FireMode == (int)firemode)
            {
                return false;
            }
            else
            {
                FireMode = (int)firemode;
                return true;
            }
        }

        public void AddBarrel(BarrelEnum barrel)
        {
            barrelInventory.Add(new Barrel(barrel));
            if(CurrentBarrelIndex == 0)
                CurrentBarrelIndex += 1;      
            else
                ToggleBarrel();
            
        }
        public Barrel GetCurrentBarrel()
        {
            return barrelInventory[CurrentBarrelIndex];
        }
        public bool ToggleBarrel(ToggleEnum toggleEnum = ToggleEnum.toggleForwards)
        {
            //Never toggle barrel if there's only the base barrel enum of NoBarrel
            if(barrelInventory.Count == 2)
            {
                return false;
            }
            if (toggleEnum == ToggleEnum.toggleForwards && CurrentBarrelIndex == barrelInventory.Count - 1)
            {
                CurrentBarrelIndex = 1;
            }
            else if (toggleEnum == ToggleEnum.toggleBackwards && CurrentBarrelIndex == 1)
            {
                CurrentBarrelIndex = barrelInventory.Count - 1;
            }
            else
            {
                CurrentBarrelIndex += (int)toggleEnum;
            }
            return true;
        }


        public bool RemoveBarrel()
        {
            if (barrelInventory.Count == 1)
                return false;
            barrelInventory.RemoveAt(CurrentBarrelIndex);
            //Barrel only toggles when there is more than one barrel in the inventory
            if (CurrentBarrelIndex == 2)
                CurrentBarrelIndex = 1;
            else
                ToggleBarrel(ToggleEnum.toggleBackwards);
            return true;
        }
        public void AddSight(SightEnum sight)
        {
            sightInventory.Add(new Sight(sight));
            if (CurrentSightIndex == 0)
                CurrentSightIndex += 1;
            else
                ToggleSight();

        }
        public Sight GetCurrentSight()
        {
            return sightInventory[CurrentSightIndex];
        }
        public bool ToggleSight(ToggleEnum toggleEnum = ToggleEnum.toggleForwards)
        {
            //Never toggle sight if there's only the base barrel enum of NoBarrel
            if (sightInventory.Count == 2)
            {
                return false;
            }
            if (toggleEnum == ToggleEnum.toggleForwards && CurrentSightIndex == sightInventory.Count - 1)
            {
                CurrentSightIndex = 1;
            }
            else if (toggleEnum == ToggleEnum.toggleBackwards && CurrentSightIndex == 1)
            {
                CurrentSightIndex = sightInventory.Count - 1;
            }
            else
            {
                CurrentSightIndex += (int)toggleEnum;
            }
            return true;
        }


        public bool RemoveSight()
        {
            if (sightInventory.Count == 1)
                return false;
            sightInventory.RemoveAt(CurrentSightIndex);
            //Sight only toggles when there is more than one barrel in the inventory
            if (CurrentSightIndex == 2)
                CurrentSightIndex = 1;
            else
                ToggleSight(ToggleEnum.toggleBackwards);
            return true;
        }
        //public void SetAuxiliaryFire(AuxiliaryFireEnum auxiliaryfire)
        //{
        //    AuxiliaryFire = auxiliaryfire;
        //}


        public double GetAccuracy()
        {
            return (accuracy * GetCurrentSight().accuracyMultiplier);
        }

        public int GetDamage()
        {
            return (int)(_damagePoints * GetAccuracy() * FireMode * GetCurrentBarrel().damageMultiplier);

        }


        public override bool Shoot(Enemy enemy)
        {
            if(ammoRemaining > 0)
            {
                enemy.ReceiveDamage(GetDamage());
                ammoRemaining -= FireMode;
                return true;
            }
            return false;
        }

      
    }
}
