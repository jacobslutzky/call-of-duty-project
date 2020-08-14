using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.IAttachments.Models
{
  public class Sight
  {
       public readonly double accuracyMultiplier;
   public Sight(SightEnum sight = SightEnum.NoSight)
        {

            accuracyMultiplier = GetSightAccuracyMultiplier(sight);
        }

        public static double GetSightAccuracyMultiplier(SightEnum sight)
        {
            return (double)sight / 100;
        }
    }
  public enum SightEnum
    {
        //Accuracy multiplier
        NoSight = 100,
        LaserSight = 110,
        ReflexSight = 125,
        ZoomSight = 150,

    }
}
