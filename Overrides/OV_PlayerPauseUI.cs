using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Binjector.Overrides
{
    public class OV_PlayerPauseUI
    {
        public static void OV_onClickedExitButton(SleekButton button)
        {
            Provider.disconnect();
        }
    }
}
