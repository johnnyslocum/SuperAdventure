using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface ILivingCreature
    {
        int MaximumHitPoints { get; set; }
        int CurrentHitPoints { get; set; }
    }
}
