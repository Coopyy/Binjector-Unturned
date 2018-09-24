using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class ZombieESP : MonoBehaviour
    {
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && MenuGUI.instance.zombieEsp)
            {
                for (int i = 0; i < ESPUtil.zombies.Length; i++)
                {
                    Functions.DrawHighlight(ESPUtil.zombies[i].gameObject, MenuGUI.instance.zombieGlowColor);
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.zombieEspEnabled)
                {
                    for (int i = 0; i < ESPUtil.zombies.Length; i++)
                    {
                        if (!ESPUtil.zombies[i].isDead)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(ESPUtil.zombies[i].transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                float zombieDistance = Functions.GetDistance(ESPUtil.zombies[i].transform.position);
                                if (zombieDistance < MenuGUI.instance.zombieEspMaxDistance && Functions.IsVisable(ESPUtil.zombies[i].transform))
                                {
                                    string labelText = "";
                                    if (MenuGUI.instance.zombieDistance) { labelText += "<color=#F8F8FF>[</color>" + zombieDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    if (MenuGUI.instance.zombieName)
                                    {
                                        labelText += "Zombie";
                                    }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.zombieLabelColor, pos);
                                    if (MenuGUI.instance.zombie3DBoxes)
                                    {
                                        Functions.Draw3DBox(ESPUtil.zombies[i].gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.zombie3DBoxColor);
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
