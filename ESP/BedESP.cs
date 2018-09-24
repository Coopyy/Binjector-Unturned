using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class BedESP : MonoBehaviour
    {
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && MenuGUI.instance.bedEsp)
            {
                for (int i = 0; i < ESPUtil.beds.Length; i++)
                {
                    Functions.DrawHighlight(ESPUtil.beds[i].gameObject, MenuGUI.instance.bedGlowColor);
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.bedEspEnabled)
                {
                    for (int i = 0; i < ESPUtil.beds.Length; i++)
                    {
                        if (ESPUtil.beds[i] != null)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(ESPUtil.beds[i].transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                string labelText = "";
                                float bedDistance = Functions.GetDistance(ESPUtil.beds[i].transform.position);
                                if (bedDistance < MenuGUI.instance.bedEspMaxDistance && Functions.IsVisable(ESPUtil.beds[i].transform))
                                {
                                    if (MenuGUI.instance.bedDistance)
                                    {
                                        if (MenuGUI.instance.bedDistance) { labelText += "<color=#F8F8FF>[</color>" + bedDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    }
                                    if (MenuGUI.instance.isClaimed)
                                    {
                                        if (ESPUtil.beds[i].isClaimed)
                                        {
                                            labelText += "Claimed";
                                        }
                                        else
                                        {
                                            labelText += "Unclaimed";
                                        }
                                    }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.bedLabelColor, pos);
                                    if (MenuGUI.instance.bed3DBoxes)
                                    {
                                        Functions.Draw3DBox(ESPUtil.beds[i].gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.bed3DBoxColor);
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
