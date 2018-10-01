using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class PlayerESP : MonoBehaviour
    {
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.playerEsp)
                {
                    for (int i = 0; i < ESPUtil.players.Length; i++)
                    {
                        if (ESPUtil.players[i] != null && ESPUtil.players[i].player != null && ESPUtil.players[i].player.gameObject != null && !ESPUtil.players[i].player.life.isDead && ESPUtil.players[i].player != Player.player)
                        {
                            if (Functions.isFriend(ESPUtil.players[i].playerID.steamID.ToString()))
                            {
                                Functions.DrawHighlight(ESPUtil.players[i].player.gameObject, MenuGUI.instance.friendGlowColor);
                            }
                            else
                            {
                                Functions.DrawHighlight(ESPUtil.players[i].player.gameObject, MenuGUI.instance.playerGlowColor);
                            }
                        }
                    }
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.playerEspEnabled)
                {
                    ESPUtil.players = Provider.clients.ToArray();

                    for (int i = 0; i < ESPUtil.players.Length; i++)
                    {
                        if (ESPUtil.players[i] != null && ESPUtil.players[i].player != null && ESPUtil.players[i].player.gameObject != null && !ESPUtil.players[i].player.life.isDead && ESPUtil.players[i].player != Player.player)
                        {
                            GameObject go = ESPUtil.players[i].player.gameObject;
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(ESPUtil.players[i].player.transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                string labelText = "";
                                Color color = Color.red;
                                float playerD = Functions.GetDistance(ESPUtil.players[i].player.transform.position);
                                if (playerD < MenuGUI.instance.playerEspMaxDistance)
                                {
                                    if (Functions.IsVisable(ESPUtil.players[i].player.transform))
                                    {
                                        if (MenuGUI.instance.playerVisabilityChecks)
                                        {
                                            Functions.InCameraView(Functions.GetLimbPosition(ESPUtil.players[i].player.transform, "Skull"), out RaycastHit hit);
                                            if (DamageTool.getPlayer(hit.transform))
                                            {
                                                color = new Color32(255, 174, 25, 255);
                                            }
                                        }
                                        if (MenuGUI.instance.playerDistance) { labelText += "<color=#F8F8FF>[</color>" + playerD.ToString() + "<color=#F8F8FF>] </color>"; }
                                        if (MenuGUI.instance.playerName) { labelText += ESPUtil.players[i].playerID.characterName; }
                                        if (MenuGUI.instance.playerWeapon)
                                        {
                                            if (ESPUtil.players[i].player.equipment.asset != null)
                                            {
                                                labelText += "<color=#F8F8FF> - </color>" + ESPUtil.players[i].player.equipment.asset.name.Replace("_", " ");
                                            }
                                            else
                                            {
                                                labelText += "<color=#F8F8FF> - </color>None";
                                            }
                                        }

                                        Functions.DrawLabel(labelText, Functions.isFriend(ESPUtil.players[i].playerID.steamID.ToString()) ? MenuGUI.instance.friendLabelColor : color, pos);

                                        if (MenuGUI.instance.player3DBoxes && Functions.IsVisable(ESPUtil.players[i].player.transform))
                                        {
                                            Functions.Draw3DBox(new Bounds(ESPUtil.players[i].player.transform.position + new Vector3(0, 1.1f, 0), ESPUtil.players[i].player.transform.localScale + new Vector3(0, .95f, 0)), Functions.isFriend(ESPUtil.players[i].playerID.steamID.ToString()) ? MenuGUI.instance.friend3DBoxColor : color);
                                        }
                                    }

                                    if (MenuGUI.instance.playerLines)
                                    {
                                        Functions.DrawTracer(pos, Functions.isFriend(ESPUtil.players[i].playerID.steamID.ToString()) ? MenuGUI.instance.friendTracerColor : color);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

