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
    public class Aimbot : MonoBehaviour
    {
        public static SteamPlayer[] players;

        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (Input.GetKeyDown(MenuGUI.instance.aimKey))
                {
                    MenuGUI.instance.aimEnabled = true;
                }
                if (MenuGUI.instance.aimOnFire)
                {
                    ItemGunAsset gun = (ItemGunAsset)Player.player.equipment.asset;
                    if (gun != null && !MenuGUI.guiOn)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            MenuGUI.instance.aimEnabled = true;
                        }
                        if (Input.GetKeyUp(KeyCode.Mouse0))
                        {
                            MenuGUI.instance.aimEnabled = false;
                        }
                    }
                }
                if (Input.GetKeyUp(MenuGUI.instance.aimKey))
                {
                    MenuGUI.instance.aimEnabled = false;
                }

                if (Player.player.life == null || Player.player.life.isDead)
                {
                    MenuGUI.instance.aimEnabled = false;
                }

                if (MenuGUI.instance.aimEnabled)
                {
                    updateAim();
                }
            }
        }

        private void updateAim()
        {
            GameObject obj = null;

            if (MenuGUI.instance.lockPlayers)
            {
                Player p = Functions.GetNearestPlayer();
                if (p != null)
                {
                    if (obj == null)
                    {
                        obj = p.gameObject;
                    }
                    else
                    {
                        if (Vector3.Distance(ESPUtil.mainCamera.transform.position, p.transform.position) < Vector3.Distance(ESPUtil.mainCamera.transform.position, obj.transform.position))
                        {
                            obj = p.gameObject;
                        }
                    }
                }
            }

            if (obj != null)
            {
                aim(obj);
            }
        }

        private void aim(GameObject obj)
        {
            Vector3 skullPosition = Functions.GetLimbPosition(obj.transform, "Skull");
            Player.player.transform.LookAt(skullPosition);
            Player.player.transform.eulerAngles = new Vector3(0f, Player.player.transform.rotation.eulerAngles.y, 0f);
            Camera.main.transform.LookAt(skullPosition);
            float num4 = Camera.main.transform.localRotation.eulerAngles.x;
            if (num4 <= 90f && num4 <= 270f)
            {
                num4 = Camera.main.transform.localRotation.eulerAngles.x + 90f;
            }
            else if (num4 >= 270f && num4 <= 360f)
            {
                num4 = Camera.main.transform.localRotation.eulerAngles.x - 270f;
            }
            Player.player.look.GetType().GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.look, num4);
            Player.player.look.GetType().GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(Player.player.look, Player.player.transform.rotation.eulerAngles.y);
        }
    }
}
