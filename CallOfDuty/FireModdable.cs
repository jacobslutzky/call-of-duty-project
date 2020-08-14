using CallOfDuty.IAttachments.Models;
using CallOfDuty.Weapons.IAttachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.IAttachments
{
    public abstract class FireModdable : IFireMode
    {
        protected FireModeEnum FireMode;
        public FireModdable(FireModeEnum firemode)
        {
            FireMode = firemode;
        }
        public void SetFireMode(FireModeEnum firemode)
        {
            FireMode = firemode;
        }
       
    }
}
