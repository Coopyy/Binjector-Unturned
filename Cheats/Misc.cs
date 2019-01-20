using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Binjector.Utilities;
using UnityEngine;
using Binjector.Other;
using System.Collections;
using Binjector.Overrides;
using Binjector.Variables;

namespace Binjector.Cheats
{
    public class Misc : MonoBehaviour
    {
        public static FieldInfo LevelTime;
        public static FieldInfo LevelRainyness;
        public static FieldInfo LevelSnowyness;

        public static DateTime Second = DateTime.Now;

        void Start()
        {
            OV_DamageTool.Random = new System.Random();
            LevelTime = typeof(LevelLighting).GetField("_time", ReflectionVariables.PrivateStatic);
            LevelRainyness = typeof(LevelLighting).GetField("rainyness", ReflectionVariables.PrivateStatic);
            LevelSnowyness = typeof(LevelLighting).GetField("snowyness", ReflectionVariables.PrivateStatic);
        }

        public void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.freeCam)
                {
                    Player.player.look.isOrbiting = true;
                    Player.player.look.isTracking = true;
                }
                else
                {
                    Player.player.look.isOrbiting = false;
                    Player.player.look.isTracking = false;
                }
                if (PlayerPauseUI.active)
                {
                    PlayerPauseUI.lastLeave = 0;
                }
            }
        }

        void OnGUI()
        {
            Event e = Event.current;
            if (e.isKey)
            {
                if (MenuGUI.instance.bindingMenu)
                {
                    MenuGUI.instance.menuKey = e.keyCode;
                    MenuGUI.instance.bindingMenu = false;
                }
                if (MenuGUI.instance.bindingAim)
                {
                    MenuGUI.instance.aimKey = e.keyCode;
                    MenuGUI.instance.bindingAim = false;
                }
                if (MenuGUI.instance.bindingChat)
                {
                    MenuGUI.instance.chatKey = e.keyCode;
                    MenuGUI.instance.bindingChat = false;
                }
                if (MenuGUI.instance.bindingItem)
                {
                    MenuGUI.instance.itemKey = e.keyCode;
                    MenuGUI.instance.bindingItem = false;
                }
            }
        }
    }
}
