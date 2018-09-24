using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binjector.Utilities;
using UnityEngine;

namespace Binjector.ESP
{
    public class ItemESP : MonoBehaviour
    {
        public InteractableItem espitem;
        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && MenuGUI.instance.itemEsp)
            {
                for (int i = 0; i < ESPUtil.items.Length; i++)
                {
                    Functions.DrawHighlight(ESPUtil.items[i].gameObject, MenuGUI.instance.itemGlowColor);
                }
            }
        }

        void OnGUI()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                if (MenuGUI.instance.itemEspEnabled)
                {
                    for (int i = 0; i < ESPUtil.items.Length; i++)
                    {
                        if (MenuGUI.instance.filterItems)
                        {
                            if (MenuGUI.instance.viewGun && ESPUtil.items[i].asset is ItemGunAsset)
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewClothing && ESPUtil.items[i].asset is ItemClothingAsset)
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewFoodWater && (ESPUtil.items[i].asset is ItemFoodAsset || ESPUtil.items[i].asset is ItemWaterAsset))
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewBackpack && ESPUtil.items[i].asset is ItemBackpackAsset)
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewAmmo && (ESPUtil.items[i].asset is ItemMagazineAsset || ESPUtil.items[i].asset is ItemBoxAsset))
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewFuel && ESPUtil.items[i].asset is ItemFuelAsset)
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewAttachments && (ESPUtil.items[i].asset is ItemBarrelAsset || ESPUtil.items[i].asset is ItemGripAsset || ESPUtil.items[i].asset is ItemOpticAsset || ESPUtil.items[i].asset is ItemTacticalAsset))
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewMedical && ESPUtil.items[i].asset is ItemMedicalAsset)
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewMelee && ESPUtil.items[i].asset is ItemMeleeAsset)
                            {
                                espitem = ESPUtil.items[i];
                            }
                            else if (MenuGUI.instance.viewThrowable && ESPUtil.items[i].asset is ItemThrowableAsset)
                            {
                                espitem = ESPUtil.items[i];
                            } else
                            {
                                espitem = null;
                            }
                        } else
                        {
                            espitem = ESPUtil.items[i];
                        }

                        if (espitem != null)
                        {
                            Vector3 pos = ESPUtil.mainCamera.WorldToScreenPoint(espitem.transform.position);
                            pos.y = Screen.height - pos.y;

                            if (pos.z >= 0)
                            {
                                float itemDistance = Functions.GetDistance(espitem.transform.position);
                                string labelText = "";
                                if (itemDistance < MenuGUI.instance.itemEspMaxDistance && Functions.IsVisable(espitem.transform))
                                {
                                    if (MenuGUI.instance.itemDistance)
                                    {
                                        if (MenuGUI.instance.itemDistance) { labelText += "<color=#F8F8FF>[</color>" + itemDistance.ToString() + "<color=#F8F8FF>] </color>"; }
                                    }
                                    if (MenuGUI.instance.itemName)
                                    {
                                        labelText += espitem.asset.itemName;
                                        GUI.contentColor = MenuGUI.instance.itemLabelColor;
                                    }
                                    Functions.DrawLabel(labelText, MenuGUI.instance.itemLabelColor, pos);
                                    if (MenuGUI.instance.item3DBoxes)
                                    {
                                        Functions.Draw3DBox(espitem.gameObject.GetComponent<Collider>().bounds, MenuGUI.instance.item3DBoxColor);
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
