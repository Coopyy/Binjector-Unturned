using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class GeneratorESP : MonoBehaviour
    {
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && MenuGUI.instance.generatorEsp)
            {
                for (int i = 0; i < ESPUtil.generators.Length; i++)
                {
                    Functions.DrawHighlight(ESPUtil.generators[i].gameObject, MenuGUI.instance.generatorGlowColor);
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.generatorEspEnabled)
                {
                    for (int i = 0; i < ESPUtil.generators.Length; i++)
                    {
                        if (ESPUtil.generators[i] != null)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(ESPUtil.generators[i].transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                string labelText = "";
                                float generatorDistance = Functions.GetDistance(ESPUtil.generators[i].transform.position);
                                if (generatorDistance < MenuGUI.instance.generatorEspMaxDistance && Functions.IsVisable(ESPUtil.generators[i].transform))
                                {
                                    if (MenuGUI.instance.generatorDistance)
                                    {
                                        if (MenuGUI.instance.generatorDistance) { labelText += "<color=#F8F8FF>[</color>" + generatorDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    }
                                    if (MenuGUI.instance.generatorName) { labelText += "Generator"; }
                                    if (MenuGUI.instance.generatorStatus)
                                    {
                                        if (ESPUtil.generators[i].isPowered)
                                        {
                                            labelText += "<color=#F8F8FF> - </color>On";
                                        } else
                                        {
                                            labelText += "<color=#F8F8FF> - </color>Off";
                                        }
                                    }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.generatorLabelColor, pos);
                                    if (MenuGUI.instance.generator3DBoxes)
                                    {
                                        Functions.Draw3DBox(ESPUtil.generators[i].gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.generator3DBoxColor);
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
