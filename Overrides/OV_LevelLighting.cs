using Binjector.Cheats;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Binjector.Overrides
{
    public class OV_LevelLighting
    {
        public static void OV_updateLighting()
		{
            Misc.LevelTime.SetValue(null, 1200);
            Misc.LevelRainyness.SetValue(null, ELightingRain.NONE);
            Misc.LevelTime.SetValue(null, ELightingSnow.NONE);
        }
    }
}
