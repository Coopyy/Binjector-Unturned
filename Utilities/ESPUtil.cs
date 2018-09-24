using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;
using HighlightingSystem;
using Steamworks;

namespace Binjector.Utilities
{
    public class ESPUtil : MonoBehaviour
    {
        public static DateTime Second = DateTime.Now;

        public static Camera mainCamera = null;

        public static SteamPlayer[] players;
        public static Zombie[] zombies;
        public static InteractableItem[] items;
        public static InteractableVehicle[] vehicles;
        public static InteractableStorage[] storages;
        public static InteractableBed[] beds;
        public static InteractableClaim[] claimflags;
        public static InteractableGenerator[] generators;

        public static Material DrawingMaterial;

        void Start()
        {
            var material = new Material(Shader.Find("Hidden/Internal-Colored"));
            material.hideFlags = (HideFlags)61;
            DrawingMaterial = material;
            DrawingMaterial.SetInt("_SrcBlend", 5);
            DrawingMaterial.SetInt("_DstBlend", 10);
            DrawingMaterial.SetInt("_Cull", 0);
            DrawingMaterial.SetInt("_ZWrite", 0);
        }

        void Update()
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                players = Provider.clients.ToArray();
                vehicles = VehicleManager.vehicles.ToArray();
                if ((DateTime.Now - Second).TotalSeconds > 3)
                {
                    if (MenuGUI.instance.zombieEspEnabled) { zombies = FindObjectsOfType<Zombie>(); }
                    if (MenuGUI.instance.itemEspEnabled) { items = FindObjectsOfType<InteractableItem>(); }
                    if (MenuGUI.instance.bedEspEnabled) { beds = FindObjectsOfType<InteractableBed>(); }
                    if (MenuGUI.instance.storageEspEnabled) { storages = FindObjectsOfType<InteractableStorage>(); }
                    if (MenuGUI.instance.claimflagEspEnabled) { claimflags = FindObjectsOfType<InteractableClaim>(); }
                    if (MenuGUI.instance.generatorEspEnabled) { generators = FindObjectsOfType<InteractableGenerator>(); }
                    Second = DateTime.Now;
                }
            }
        }

        public void OnGUI()
		{
			if (Provider.isConnected && !Provider.isLoading)
			{
				if (ESPUtil.mainCamera == null)
				{
					ESPUtil.mainCamera = Camera.main;
				}
			}
		}
    }
}