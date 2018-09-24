using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class ClaimflagESP : MonoBehaviour
    {
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && MenuGUI.instance.claimflagEsp)
            {
                for (int i = 0; i < ESPUtil.claimflags.Length; i++)
                {
                    Functions.DrawHighlight(ESPUtil.claimflags[i].gameObject, MenuGUI.instance.claimflagGlowColor);
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.claimflagEspEnabled)
                {
                    for (int i = 0; i < ESPUtil.claimflags.Length; i++)
                    {
                        if (ESPUtil.claimflags[i] != null)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(ESPUtil.claimflags[i].transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                string labelText = "";
                                float claimflagDistance = Functions.GetDistance(ESPUtil.claimflags[i].transform.position);
                                if (claimflagDistance < MenuGUI.instance.claimflagEspMaxDistance && Functions.IsVisable(ESPUtil.claimflags[i].transform))
                                {
                                    if (MenuGUI.instance.claimflagDistance)
                                    {
                                        if (MenuGUI.instance.claimflagDistance) { labelText += "<color=#F8F8FF>[</color>" + claimflagDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    }
                                    if (MenuGUI.instance.claimflagName) { labelText += "Claim Flag"; }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.claimflagLabelColor, pos);
                                    if (MenuGUI.instance.claimflag3DBoxes)
                                    {
                                        Functions.Draw3DBox(ESPUtil.claimflags[i].gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.claimflag3DBoxColor);
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
