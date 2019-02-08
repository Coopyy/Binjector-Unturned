/*using System;
using SDG.Framework.Modules;
using UnityEngine.UI;*/
using System;
using System.CodeDom;
using Binjector.Cheats;
using Binjector.Utilities;
using SDG.Framework.Modules;
using SDG.Unturned;
using Steamworks;
using UnityEngine;


namespace Binjector
{
	public class Manager : MonoBehaviour
	{
        public GUIStyle stlye;
        public GameObject objectspawn1;
		public GameObject manager;
	
		void Start()
		{
			manager = GameObject.Find("Manager");
			DontDestroyOnLoad(this.manager);

			objectspawn1 = new GameObject("Testobject");
			DontDestroyOnLoad(objectspawn1);

            // Load Components
			objectspawn1.AddComponent<MenuGUI>();
            objectspawn1.AddComponent<ESPUtil>();
            objectspawn1.AddComponent<Weapons>();
            objectspawn1.AddComponent<Misc>();
            objectspawn1.AddComponent<Aimbot>();
            objectspawn1.AddComponent<Cheats.Items>();
            objectspawn1.AddComponent<Vehicles>();
            objectspawn1.AddComponent<OverrideManager>();

            // Load ESP Components
            objectspawn1.AddComponent<ESP.PlayerESP>();
            objectspawn1.AddComponent<ESP.ItemESP>();
            objectspawn1.AddComponent<ESP.BedESP>();
            objectspawn1.AddComponent<ESP.StorageESP>();
            objectspawn1.AddComponent<ESP.ZombieESP>();
            objectspawn1.AddComponent<ESP.VehicleESP>();
            objectspawn1.AddComponent<ESP.GeneratorESP>();
            objectspawn1.AddComponent<ESP.ClaimflagESP>();
            
            
        }
		
		


        public void Selfdestroy()
        {
			Destroy(objectspawn1);
			Destroy(manager);
		}
    }
}
