using CallOfDuty.Enemies;
using CallOfDuty.IAttachments;
using CallOfDuty.IAttachments.Models;
using CallOfDuty.Weapons.IAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.Weapons
{
    public class AssaultRifle : ModdableWeapon, IAssaultRifle
    {
        public const int Assault_Rifle_Damage_Points = 100;
        public AuxiliaryFire auxiliaryFireWeapon = null;
        private bool _usingAssaultRifle;
        private bool weaponHasAuxiliaryFire;


        public AssaultRifle(FireModeEnum firemode = FireModeEnum.SingleShot) 
            :base(firemode)
        {
            _damagePoints = Assault_Rifle_Damage_Points;
            _maxAmmo = 500;
            ammoRemaining = 1;
            accuracy = 1;
            _usingAssaultRifle = true;
            weaponHasAuxiliaryFire = false;
        }
        public void AddAuxiliaryAttachment()
        {
            auxiliaryFireWeapon = new AuxiliaryFire();
            weaponHasAuxiliaryFire = true;

        }
        public override bool Shoot(Enemy enemy)
        {
            if (_usingAssaultRifle)
            {   
                if (weaponHasAuxiliaryFire && ammoRemaining == 0 && auxiliaryFireWeapon.ammoRemaining > 0)
                {
                    Toggle();
                    auxiliaryFireWeapon.Shoot(enemy);
                }
                else
                {
                base.Shoot(enemy);
                }
        
                return true;
            }
            else if(weaponHasAuxiliaryFire)
            {
                if (auxiliaryFireWeapon.ammoRemaining == 0 && ammoRemaining > 0)
                {
                    Toggle();
                    base.Shoot(enemy);
                }
                else
                {
                    auxiliaryFireWeapon.Shoot(enemy);
                }
               
                return true;
            }
            return false;
        }
        
        public bool Toggle()
        {
            if (weaponHasAuxiliaryFire)
            {
                _usingAssaultRifle = !_usingAssaultRifle;
                return true;
            }
            return false;
        }
    }
}
