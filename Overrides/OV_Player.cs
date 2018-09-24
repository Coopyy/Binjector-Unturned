using Binjector.Utilities;
using SDG.Unturned;
using Steamworks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Binjector.Overrides
{
    public class OV_Player
    {
        public static void OV_askScreenshot(CSteamID steamid)
		{
            return;
        }
    }
}
