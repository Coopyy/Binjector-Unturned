using Binjector.Overrides;
using Binjector.Utilities;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Binjector.Utilities
{
    public class OverrideManager : MonoBehaviour
    {
        void Start()
        {
            Functions.OverrideMethod(typeof(Player), typeof(OV_Player), "askScreenshot", BindingFlags.Instance, BindingFlags.Public); //Player
            Functions.OverrideMethod(typeof(DamageTool), typeof(OV_DamageTool), "raycast", BindingFlags.Static, BindingFlags.Public); //DamageTool
            Functions.OverrideMethod(typeof(PlayerPauseUI), typeof(OV_PlayerPauseUI), "onClickedExitButton", BindingFlags.Static, BindingFlags.NonPublic); //PlayerPauseUI
            Functions.OverrideMethod(typeof(Provider), typeof(OV_Provider), "OnApplicationQuit", BindingFlags.Instance, BindingFlags.NonPublic); //Provider
            //Functions.OverrideMethod(typeof(LevelLighting), typeof(OV_LevelLighting), "updateLighting", BindingFlags.Static, BindingFlags.Public); //LevelLighting
        }
    }
}
