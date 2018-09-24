using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class StorageESP : MonoBehaviour
    {
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && MenuGUI.instance.storageEsp)
            {
                for (int i = 0; i < ESPUtil.storages.Length; i++)
                {
                    Functions.DrawHighlight(ESPUtil.storages[i].gameObject, MenuGUI.instance.storageGlowColor);
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.storageEspEnabled)
                {
                    for (int i = 0; i < ESPUtil.storages.Length; i++)
                    {
                        if (ESPUtil.storages[i] != null)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(ESPUtil.storages[i].transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                float storageDistance = Functions.GetDistance(ESPUtil.storages[i].transform.position);
                                string labelText = "";
                                if (storageDistance < MenuGUI.instance.storageEspMaxDistance && Functions.IsVisable(ESPUtil.storages[i].transform))
                                {
                                    if (MenuGUI.instance.storageDistance) { labelText += "<color=#F8F8FF>[</color>" + storageDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    if (MenuGUI.instance.storageName) { labelText += "Storage"; }
                                    if (MenuGUI.instance.isOpen)
                                    {
                                        if (ESPUtil.storages[i].isOpen)
                                        {
                                            labelText += "<color=#F8F8FF> - </color>LOCKED";
                                        } else
                                        {
                                            labelText += "<color=#F8F8FF> - </color>UNLOCKED";
                                        }
                                    }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.storageLabelColor, pos);

                                    
                                    if (MenuGUI.instance.storage3DBoxes)
                                    {
                                        Functions.Draw3DBox(ESPUtil.storages[i].gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.storage3DBoxColor);
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
