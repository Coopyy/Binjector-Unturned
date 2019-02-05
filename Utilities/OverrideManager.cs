using Binjector.Overrides;
using Binjector.Utilities;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Binjector.Variables;
using UnityEngine;

namespace Binjector.Utilities
{
    public class OverrideManager : MonoBehaviour
    {
        void Start()
        {
            Functions.OverrideMethod(typeof(Player), typeof(OV_Player), "askScreenshot", ReflectionVariables.PublicInstance); //Player
            Functions.OverrideMethod(typeof(DamageTool), typeof(OV_DamageTool), "raycast", ReflectionVariables.PublicStatic); //DamageTool
            Functions.OverrideMethod(typeof(PlayerPauseUI), typeof(OV_PlayerPauseUI), "onClickedExitButton", ReflectionVariables.PrivateStatic); //PlayerPauseUI
            Functions.OverrideMethod(typeof(Provider), typeof(OV_Provider), "OnApplicationQuit", ReflectionVariables.PrivateInstance); //Provider
            //Functions.OverrideMethod(typeof(LevelLighting), typeof(OV_LevelLighting), "updateLighting", BindingFlags.Static, BindingFlags.Public); //LevelLighting
        }
    }
}
