using Binjector.Other;
using Binjector.Utilities;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Binjector.Cheats
{
    public class Weapons : MonoBehaviour
    {
        public Rect GunInfoWin = new Rect(1785, 10, 120, 50);

        public void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                ItemGunAsset gun = (ItemGunAsset)Player.player.equipment.asset;
                if (gun != null)
                {
                    Player.player.equipment.isBusy = false;
                    Player.player.equipment.useable.GetType().GetField("isFired", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, false);
                    Player.player.equipment.useable.GetType().GetField("isHammering", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, false);
                    Player.player.equipment.useable.GetType().GetField("needsRechamber", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, false);
                    Player.player.equipment.useable.GetType().GetField("reloadTime", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.equipment.useable, 0f);
                    gun.hasAuto = true;

                    if (MenuGUI.instance.noSpread && Player.player.equipment.asset is ItemGunAsset)
                    {
                        gun.spreadAim = 0f;
                        gun.spreadHip = 0f;
                        PlayerUI.disableCrosshair();
                        PlayerUI.enableDot();
                    }
                    else
                    {
                        PlayerUI.enableCrosshair();
                    }

                    if (MenuGUI.instance.noRecoil && Player.player.equipment.asset is ItemGunAsset)
                    {
                        gun.recoilMax_x = 0f;
                        gun.recoilMax_y = 0f;
                        gun.recoilMin_x = 0f;
                        gun.recoilMin_y = 0f;
                    }

                    if (MenuGUI.instance.noSway && Player.player.equipment.asset is ItemGunAsset)
                    {
                        gun.shakeMax_x = 0f;
                        gun.shakeMax_y = 0f;
                        gun.shakeMax_z = 0f;
                        gun.shakeMin_x = 0f;
                        gun.shakeMin_y = 0f;
                        gun.shakeMin_z = 0f;
                        MenuGUI.instance.alwaysBreath = true;
                        Player.player.animator.viewSway = Vector3.zero;
                        //Player.player.equipment.GetType().GetField("prim", BindingFlags.NonPublic | BindingFlags.Instance).SetValue(Player.player.equipment, true);
                    }
                }
                else
                {
                    if (MenuGUI.instance.noSpread)
                    {
                        PlayerUI.enableDot();
                    }
                }
            }
        }

        public void OnGUI()
        {
            ItemGunAsset gun = (ItemGunAsset)Player.player.equipment.asset;
            if (MenuGUI.instance.showGunRange && gun != null && Provider.isConnected && !Provider.isLoading)
            {
                GunInfoWin = GUILayout.Window(73964, GunInfoWin, GunInfoWindow, "Weapon Info");
            }
        }

        void GunInfoWindow(int winid)
        {
            string s = "";
            ItemGunAsset gun = (ItemGunAsset)Player.player.equipment.asset;
            if (gun != null && Provider.isConnected && !Provider.isLoading)
            {
                s += gun.range.ToString();
            }
            GUILayout.Label("Range: " + s);
            GUI.DragWindow();
        }

        public static FieldInfo FireMode;
    }
}
