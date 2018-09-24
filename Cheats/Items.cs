using Binjector.Utilities;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Binjector.Cheats
{
    public class Items : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(MenuGUI.instance.itemKey))
            {
                if (MenuGUI.instance.autoItemPickup == true)
                {
                    MenuGUI.instance.autoItemPickup = false;
                }
                else
                {
                    MenuGUI.instance.autoItemPickup = true;
                }
            }
            if (MenuGUI.instance.autoItemPickup && Provider.isConnected && !Provider.isLoading && !(Player.player == null))
            {
                Collider[] array = Physics.OverlapSphere(Camera.main.transform.position, 19f, RayMasks.ITEM);
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] != null && array[i].gameObject != null && array[i].GetComponent<InteractableItem>() != null && array[i].GetComponent<InteractableItem>().asset != null)
                    {
                        InteractableItem component = array[i].GetComponent<InteractableItem>();
                        if (MenuGUI.instance.pickupAll)
                        {
                            component.use();
                        } else
                        {
                            if (MenuGUI.instance.pickupGun && component.asset is ItemGunAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupBackpack && component.asset is ItemBackpackAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupAmmo && component.asset is ItemMagazineAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupAttachments && (component.asset is ItemBarrelAsset || component.asset is ItemOpticAsset))
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupClothing && component.asset is ItemClothingAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupFuel && component.asset is ItemFuelAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupMedical && component.asset is ItemMedicalAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupMelee && component.asset is ItemMeleeAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupThrowable && component.asset is ItemThrowableAsset)
                            {
                                component.use();
                            }
                            else if (MenuGUI.instance.pickupFoodWater && (component.asset is ItemFoodAsset || component.asset is ItemWaterAsset))
                            {
                                component.use();
                            }
                        }
                    }
                }
            }
        }
    }
}
