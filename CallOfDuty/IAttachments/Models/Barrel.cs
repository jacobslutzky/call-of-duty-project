using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.IAttachments.Models
{
    public class Barrel
    {
        public readonly double damageMultiplier;
        

        public Barrel(BarrelEnum barrel = BarrelEnum.NoBarrel)
        {

            damageMultiplier = GetBarrelDamageMultiplier(barrel);
        }

         public static double GetBarrelDamageMultiplier(BarrelEnum barrel)
        {
            return (double) barrel / 100;
            
        }
    }


    public enum BarrelEnum
    {
        //Accuracy multiplier
        NoBarrel = 100,
        ShortBarrel = 110,
        MediumBarrel = 125,
        LongBarrel = 150
    }

}

