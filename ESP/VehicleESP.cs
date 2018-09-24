using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class VehicleESP : MonoBehaviour
    {
        public InteractableVehicle espveh;
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.vehicleEsp)
                {
                    for (int i = 0; i < ESPUtil.vehicles.Length; i++)
                    {
                        Functions.DrawHighlight(ESPUtil.vehicles[i].gameObject, MenuGUI.instance.vehicleGlowColor);
                    }
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.vehicleEspEnabled)
                {
                    ESPUtil.vehicles = VehicleManager.vehicles.ToArray();
                    for (int i = 0; i < ESPUtil.vehicles.Length; i++)
                    {
                        if (MenuGUI.instance.onlyShowUnlocked)
                        {
                            if (!ESPUtil.vehicles[i].isLocked)
                            {
                                espveh = ESPUtil.vehicles[i];
                            }
                        }
                        else
                        {
                            espveh = ESPUtil.vehicles[i];
                        }
                        if (espveh != null)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(espveh.transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                string labelText = "";
                                float vehicleDistance = Functions.GetDistance(espveh.transform.position);
                                if (vehicleDistance < MenuGUI.instance.vehicleEspMaxDistance && Functions.IsVisable(espveh.transform))
                                {
                                    if (MenuGUI.instance.vehicleDistance) { labelText += "<color=#F8F8FF>[</color>" + vehicleDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    if (MenuGUI.instance.vehicleName)
                                    {
                                        labelText += espveh.asset.vehicleName;
                                    }
                                    if (MenuGUI.instance.isLocked)
                                    {
                                        if (espveh.isLocked)
                                        {
                                            labelText += "<color=#F8F8FF> - </color>LOCKED";
                                        }
                                        else
                                        {
                                            labelText += "<color=#F8F8FF> - </color><color=#ff5a00>UNLOCKED</color>";
                                        }

                                    }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.vehicleLabelColor, pos);
                                    if (MenuGUI.instance.vehicle2DBoxes)
                                    {
                                        Functions.Draw2DBox(espveh.transform, pos, MenuGUI.instance.vehicle2DBoxColor, espveh.transform.position + new Vector3(0, 1, 0));
                                    }
                                    if (MenuGUI.instance.vehicle3DBoxes)
                                    {
                                        Functions.Draw3DBox(espveh.gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.vehicle3DBoxColor);
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
