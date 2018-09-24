using SDG.Unturned;
using Steamworks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Binjector.Overrides
{
    public class OV_Provider
    {
        public static void OV_OnApplicationQuit(CSteamID steamid)
		{
            Provider.disconnect();
            Process.GetCurrentProcess().Kill();
        }
    }
}
