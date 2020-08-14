using CallOfDuty.IAttachments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallOfDuty.Weapons.IAttachments
{
    public interface IFireMode
    {
    void SetFireMode(FireModeEnum firemode);
    }
}
