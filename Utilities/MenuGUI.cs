using SDG.Framework.Water;
using SDG.Unturned;
using Binjector.Cheats;
using System;
using System.Collections.Generic;
using System.Linq;
using Binjector.Utilities;
using UnityEngine;


namespace Binjector.Utilities
{
    public class MenuGUI : MonoBehaviour
    {
        #region Variables
        public static MenuGUI instance = null;
        private int vehnum = 1;
        private bool needchanging1 = false;
        private Color defColor;
        private Vector2 scrollPosition1;

        private SteamPlayer[] players;

        public static List<string> friends = new List<string>();

        public static bool guiOn = false;

        private int toolbarInt = 0;
        private string[] toolbarStrings = new string[] { "Keybinds", "Visuals", "Aimbot", "Players", "Weapons", "Items", "Misc", "Colors" };

        private int toolbar1Int = 0;
        private string[] toolbar1Strings = new string[] { "Players", "Zombies", "Vehicles", "Beds", "Items", "Storages", "Friends", "Claimflags", "Generator" };

        private int misctoolbarInt = 0;
        private string[] misctoolbarStrings = new string[] { "Vehicles", "Chat", "Interact", "Settings", "Camera", "Credits" };

        //Binds
        public bool bindingMenu = false;
        public bool bindingAim = false;
        public bool bindingChat = false;
        public bool bindingItem = false;
        public KeyCode menuKey = KeyCode.F1;
        public KeyCode aimKey = KeyCode.F2;
        public KeyCode chatKey = KeyCode.F3;
        public KeyCode itemKey = KeyCode.F4;

        // ESP
        public bool playerEspEnabled = false;
        public bool playerEsp = false;
        public bool playerName = false;
        public bool playerWeapon = false;
        public bool player2DBoxes = false;
        public bool player3DBoxes = false;
        public bool changeColorIfVisable = true;
        public bool playerLines = false;
        public bool playerDistance = false;
        public float playerEspMaxDistance = 1500;
        public bool zombieEspEnabled = false;
        public bool zombieEsp = false;
        public bool zombie2DBoxes = false;
        public bool zombie3DBoxes = false;
        public bool zombieLines = false;
        public bool zombieName = false;
        public bool zombieDistance = false;
        public float zombieEspMaxDistance = 200;
        public bool onlyShowUnlocked = false;
        public bool vehicleEspEnabled = false;
        public bool vehicleEsp = false;
        public bool vehicle2DBoxes = false;
        public bool vehicle3DBoxes = false;
        public bool vehicleLines = false;
        public bool vehicleName = false;
        public bool isLocked = false;
        public bool vehicleDistance = false;
        public float vehicleEspMaxDistance = 400;
        public bool itemEspEnabled = false;
        public bool itemEsp = false;
        public bool item3DBoxes = false;
        public bool itemLines = false;
        public bool itemName = false;
        public bool itemDistance = false;
        public bool generatorEspEnabled = false;
        public bool generatorEsp = false;
        public bool generator3DBoxes = false;
        public bool generatorName = false;
        public bool generatorDistance = false;
        public bool generatorStatus = false;
        public float generatorEspMaxDistance = 300;
        public bool claimflagEspEnabled = false;
        public bool claimflagEsp = false;
        public bool claimflag3DBoxes = false;
        public bool claimflagName = false;
        public bool claimflagDistance = false;
        public float claimflagEspMaxDistance = 400;

        public bool filterItems = false;
        public bool viewAll = true;
        public bool viewGun = false;
        public bool viewMelee = false;
        public bool viewBackpack = false;
        public bool viewClothing = false;
        public bool viewFuel = false;
        public bool viewFoodWater = false;
        public bool viewAmmo = false;
        public bool viewMedical = false;
        public bool viewThrowable = false;
        public bool viewAttachments = false;

        public float itemEspMaxDistance = 200;
        public bool storageEspEnabled = false;
        public bool storageEsp = false;
        public bool storage2DBoxes = false;
        public bool storage3DBoxes = false;
        public bool storageLines = false;
        public bool storageName = false;
        public bool storageDistance = false;
        public bool isOpen = false;
        public float storageEspMaxDistance = 500;
        public bool bedEspEnabled = false;
        public bool bedEsp = false;
        public bool bed2DBoxes = false;
        public bool bed3DBoxes = false;
        public bool bedLines = false;
        public bool isClaimed = false;
        public bool bedDistance = false;
        public float bedEspMaxDistance = 300;

        public Color playerGlowColor = Color.red;
        public Color playerTracerColor = Color.red;
        public Color player2DBoxColor = Color.red;
        public Color player3DBoxColor = Color.red;
        public Color playerLabelColor = Color.red;
        public Color friendGlowColor = Color.cyan;
        public Color friendTracerColor = Color.cyan;
        public Color friend2DBoxColor = Color.cyan;
        public Color friend3DBoxColor = Color.cyan;
        public Color friendLabelColor = Color.cyan;
        public Color zombieGlowColor = Color.grey;
        public Color zombie2DBoxColor = Color.grey;
        public Color zombie3DBoxColor = Color.grey;
        public Color zombieTracerColor = Color.grey;
        public Color zombieLabelColor = Color.grey;
        public Color vehicleGlowColor = Color.yellow;
        public Color vehicle2DBoxColor = Color.yellow;
        public Color vehicle3DBoxColor = Color.yellow;
        public Color vehicleTracerColor = Color.yellow;
        public Color vehicleLabelColor = Color.yellow;
        public Color itemGlowColor = Color.green;
        public Color item2DBoxColor = Color.green;
        public Color item3DBoxColor = Color.green;
        public Color itemTracerColor = Color.green;
        public Color itemLabelColor = Color.green;
        public Color storageGlowColor = Color.magenta;
        public Color storage2DBoxColor = Color.magenta;
        public Color storage3DBoxColor = Color.magenta;
        public Color storageTracerColor = Color.magenta;
        public Color storageLabelColor = Color.magenta;
        public Color bedGlowColor = Color.blue;
        public Color bed3DBoxColor = Color.blue;
        public Color bedLabelColor = Color.blue;
        public Color generatorGlowColor = new Color32(128, 0, 255, 255);
        public Color generator3DBoxColor = new Color32(128, 0, 255, 255);
        public Color generatorLabelColor = new Color32(128, 0, 255, 255);
        public Color claimflagGlowColor = new Color32(255, 0, 128, 255);
        public Color claimflag3DBoxColor = new Color32(255, 0, 128, 255);
        public Color claimflagLabelColor = new Color32(255, 0, 128, 255);

        // Weapons
        public bool noSpread = false;
        public bool noSway = false;
        public bool noRecoil = false;
        public bool LongRangeMelee = false;
        public bool showGunRange = false;
        public int MeleeRange = 6;

        // Misc
        public bool chatBind = false;
        public bool spamText = false;
        public string cmdString = "http://binjector.fun";
        public bool keepDay = false;
        public bool customZoom = false;
        public int zoomN = 1;
        public bool alwaysEnergy = false;
        public bool alwaysBreath = false;
        public bool freeCam = false;
        public float dayTime = 1200;
        public bool noRain = false;
        public bool noSnow = false;
        public bool InteractThroughWalls = true;

        //Aimbot
        public bool aimEnabled = false;
        public bool aimOnFire = false;
        public bool FOVAim = false;
        public float launchAmount = 0f;
        public bool lockPlayers = true;
        public bool silentAim = false;

        //Vehicles
        public bool customengine = false;
        public bool fly = false;
        public bool noclip = false;
        public float speedMultiplier = 1.9f;

        //Items
        public bool autoItemPickup = false;
        public bool pickupAll = true;
        public bool pickupGun = false;
        public bool pickupMelee = false;
        public bool pickupBackpack = false;
        public bool pickupClothing = false;
        public bool pickupFuel = false;
        public bool pickupFoodWater = false;
        public bool pickupAmmo = false;
        public bool pickupMedical = false;
        public bool pickupThrowable = false;
        public bool pickupAttachments = false;

        #endregion
        #region Windows
        private Rect VersionBox = new Rect(125, 0, 150, 24);

        private Rect NavegationWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 155, 400, 10);

        private Rect PlayerESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect ZombieESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect VehicleESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect StorageESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect ItemESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect BedESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect generatorESPWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect claimflagEspWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);

        private Rect PlayerColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect ZombieColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect VehicleColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect StorageColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect ItemColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect BedColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect FriendColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect generatorColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect claimflagColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);

        private Rect MiscSelectWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 95, 400);
        private Rect MiscChatWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect MiscVehicleWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect MiscInteractWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect MiscSettingsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect MiscCameraWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect MiscOtherWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);

        private Rect KeybindWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 400, 400);
        private Rect WeaponsWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 400, 400);
        private Rect SelectWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 95, 400);
        private Rect AimbotWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 400, 400);
        private Rect PlayersWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 400, 400);
        private Rect VehiclesWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 400, 400);
        private Rect ItemsMenuWin = new Rect((Screen.width / 2) - 200, (Screen.height / 2) - 75, 400, 400);
        private Rect ColorsWin = new Rect((Screen.width / 2) - 100, (Screen.height / 2) - 75, 300, 400);
        private Rect ConfigWin = new Rect(1785, 70, 120, 50);
        #endregion
        #region Events
        void Start()
        {
            defColor = GUI.color;
            instance = this;
        }

        void Update()
        {
            if (Input.GetKeyDown(menuKey))
            {
                if (guiOn == true)
                {
                    if (Provider.isConnected)
                    {
                        PlayerPauseUI.active = false;
                    }
                    guiOn = false;

                }
                else
                {
                    if (Provider.isConnected)
                    {
                        PlayerPauseUI.active = true;
                    }
                    guiOn = true;
                }
            }
            if (spamText)
            {
                ChatManager.sendChat(EChatMode.GLOBAL, cmdString);
            }

            if (chatBind)
            {
                if (Input.GetKeyDown(chatKey))
                {
                    ChatManager.sendChat(EChatMode.GLOBAL, cmdString);
                }
            }

            if (needchanging1)
            {
                if (vehnum == 1) Vehicles.CarEngine = EEngine.CAR;
                if (vehnum == 2) Vehicles.CarEngine = EEngine.BOAT;
                if (vehnum == 3) Vehicles.CarEngine = EEngine.HELICOPTER;
                if (vehnum == 4) Vehicles.CarEngine = EEngine.PLANE;
                if (vehnum == 5) Vehicles.CarEngine = EEngine.BLIMP;
                if (vehnum == 6) { vehnum = 1; Vehicles.CarEngine = EEngine.CAR; }
                needchanging1 = false;
            }

        }

        void OnGUI()
        {
            GUI.Box(VersionBox, Main.Version); //Logo (Top Left)

            //Menu Windows
            if (guiOn)
            {
                if (toolbarInt == 0)
                {
                    KeybindWin = GUILayout.Window(034334, KeybindWin, KeybindWindow, "Keybind Menu");
                }
                if (toolbarInt == 1)
                {
                    SelectWin = GUILayout.Window(63344, SelectWin, SelectionWindow, "Selection");
                    if (toolbar1Int == 0 || toolbar1Int == 6)
                    {
                        PlayerESPWin = GUILayout.Window(03343234, PlayerESPWin, PlayerESPWindow, "Player ESP");
                    }
                    if (toolbar1Int == 1)
                    {
                        ZombieESPWin = GUILayout.Window(031234234, ZombieESPWin, ZombieESPWindow, "Zombie ESP");
                    }
                    if (toolbar1Int == 2)
                    {
                        VehicleESPWin = GUILayout.Window(0333334234, VehicleESPWin, VehicleESPWindow, "Vehicle ESP");
                    }
                    if (toolbar1Int == 3)
                    {
                        BedESPWin = GUILayout.Window(03478434, BedESPWin, BedESPWindow, "Bed ESP");
                    }
                    if (toolbar1Int == 4)
                    {
                        ItemESPWin = GUILayout.Window(0323784234, ItemESPWin, ItemESPWindow, "Item ESP");
                    }
                    if (toolbar1Int == 5)
                    {
                        StorageESPWin = GUILayout.Window(03242334, StorageESPWin, StorageESPWindow, "Storage ESP");
                    }
                    if (toolbar1Int == 7)
                    {
                        claimflagEspWin = GUILayout.Window(289340, claimflagEspWin, claimflagESPWindow, "Claim Flag ESP");
                    }
                    if (toolbar1Int == 8)
                    {
                        generatorESPWin = GUILayout.Window(324221, generatorESPWin, generatorESPWindow, "Generator ESP");
                    }
                }
                if (toolbarInt == 2)
                {
                    AimbotWin = GUILayout.Window(331334, AimbotWin, AimbotWindow, "Aimbot Menu");
                }
                if (toolbarInt == 3)
                {
                    PlayersWin = GUILayout.Window(334296734, PlayersWin, PlayersWindow, "Players Menu");
                }
                if (toolbarInt == 4)
                {
                    WeaponsWin = GUILayout.Window(1234772, WeaponsWin, WeaponsWindow, "Weapons Menu");
                }
                if (toolbarInt == 5)
                {
                    ItemsMenuWin = GUILayout.Window(43437, ItemsMenuWin, ItemsMenuWindow, "Items Menu");
                }
                if (toolbarInt == 6)
                {
                    MiscSelectWin = GUILayout.Window(630144, MiscSelectWin, MiscSelectionWindow, "Selection");
                    if (misctoolbarInt == 0)
                    {
                        MiscVehicleWin = GUILayout.Window(231123, MiscVehicleWin, MiscVehicleWindow, "Vehicles");
                    }
                    if (misctoolbarInt == 1)
                    {
                        MiscChatWin = GUILayout.Window(435322, MiscChatWin, MiscChatWindow, "Chat");
                    }
                    if (misctoolbarInt == 2)
                    {
                        MiscInteractWin = GUILayout.Window(938942, MiscInteractWin, MiscInteractWindow, "Interact");
                    }
                    if (misctoolbarInt == 3)
                    {
                        MiscSettingsWin = GUILayout.Window(034784341, MiscSettingsWin, MiscSettingsWindow, "Settings");
                    }
                    if (misctoolbarInt == 4)
                    {
                        MiscCameraWin = GUILayout.Window(0329430, MiscCameraWin, MiscCameraWindow, "Camera");
                    }
                    if (misctoolbarInt == 5)
                    {
                        MiscOtherWin = GUILayout.Window(0329430, MiscOtherWin, MiscOtherWindow, "Credits");
                    }
                }
                if (toolbarInt == 7)
                {
                    SelectWin = GUILayout.Window(634344, SelectWin, SelectionWindow, "Selection");
                    if (toolbar1Int == 0)
                    {
                        PlayerColorsWin = GUILayout.Window(6311487, PlayerColorsWin, PlayerColorsWindow, "Player Colors");
                    }
                    if (toolbar1Int == 1)
                    {
                        ZombieColorsWin = GUILayout.Window(63464234, ZombieColorsWin, ZombieColorsWindow, "Zombie Colors");
                    }
                    if (toolbar1Int == 2)
                    {
                        VehicleColorsWin = GUILayout.Window(6534334, VehicleColorsWin, VehicleColorsWindow, "Vehicle Colors");
                    }
                    if (toolbar1Int == 3)
                    {
                        BedColorsWin = GUILayout.Window(63997804, BedColorsWin, BedColorsWindow, "Bed Colors");
                    }
                    if (toolbar1Int == 4)
                    {
                        ItemColorsWin = GUILayout.Window(638114, ItemColorsWin, ItemColorsWindow, "Item Colors");
                    }
                    if (toolbar1Int == 5)
                    {
                        StorageColorsWin = GUILayout.Window(324413, StorageColorsWin, StorageColorsWindow, "Storage Colors");
                    }
                    if (toolbar1Int == 6)
                    {
                        FriendColorsWin = GUILayout.Window(36213, FriendColorsWin, FriendColorsWindow, "Friend Colors");
                    }
                    if (toolbar1Int == 7)
                    {
                        claimflagColorsWin = GUILayout.Window(525521, claimflagColorsWin, claimflagColorsWindow, "Claim Flag Colors");
                    }
                    if (toolbar1Int == 8)
                    {
                        generatorColorsWin = GUILayout.Window(673856, generatorColorsWin, generatorColorsWindow, "Generator Colors");
                    }
                }
                NavegationWin = GUILayout.Window(03345634, NavegationWin, NavegationWindow, Main.Version);
                //ConfigWin = GUILayout.Window(09634, ConfigWin, ConfigWindow, "Config");

            }
        }
        #endregion
        #region WindowsEvents
        void ConfigWindow(int WindowID)
        {
            if (GUILayout.Button("Save Config"))
            {
                Configuration.SaveMenu();
            }
            if (GUILayout.Button("Load Config"))
            {
                Configuration.LoadMenu();
            }
        }
        void PlayerESPWindow(int WindowID)
        {
            playerEspEnabled = GUILayout.Toggle(playerEspEnabled, "Enabled");
            if (playerEspEnabled)
            {
                playerEsp = GUILayout.Toggle(playerEsp, "Player Glow");
                player3DBoxes = GUILayout.Toggle(player3DBoxes, "Player Boxes");
                playerLines = GUILayout.Toggle(playerLines, "Player Tracers");
                playerName = GUILayout.Toggle(playerName, "Player Name");
                playerWeapon = GUILayout.Toggle(playerWeapon, "Player Weapon");
                playerDistance = GUILayout.Toggle(playerDistance, "Player Distance");
                GUILayout.Label("Player ESP Range: " + playerEspMaxDistance);
                playerEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(playerEspMaxDistance, 0f, 2000f));
            }
        }
        void ZombieESPWindow(int WindowID)
        {
            zombieEspEnabled = GUILayout.Toggle(zombieEspEnabled, "Enabled");
            if (zombieEspEnabled)
            {
                zombieEsp = GUILayout.Toggle(zombieEsp, "Zombie Glow");
                zombie3DBoxes = GUILayout.Toggle(zombie3DBoxes, "Zombie Boxes");
                zombieName = GUILayout.Toggle(zombieName, "Zombie Name");
                zombieDistance = GUILayout.Toggle(zombieDistance, "Zombie Distance");
                GUILayout.Label("Zombie ESP Range: " + zombieEspMaxDistance);
                zombieEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(zombieEspMaxDistance, 0f, 2000f));
            }

        }
        void claimflagESPWindow(int WindowID)
        {
            claimflagEspEnabled = GUILayout.Toggle(claimflagEspEnabled, "Enabled");
            if (claimflagEspEnabled)
            {
                claimflagEsp = GUILayout.Toggle(claimflagEsp, "Claim Flag Glow");
                claimflag3DBoxes = GUILayout.Toggle(claimflag3DBoxes, "Claim Flag Boxes");
                claimflagName = GUILayout.Toggle(claimflagName, "Claim Flag Name");
                claimflagDistance = GUILayout.Toggle(claimflagDistance, "Claim Flag Distance");
                GUILayout.Label("Claim Flag ESP Range: " + claimflagEspMaxDistance);
                claimflagEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(claimflagEspMaxDistance, 0f, 2000f));
            }

        }
        void generatorESPWindow(int WindowID)
        {
            generatorEspEnabled = GUILayout.Toggle(generatorEspEnabled, "Enabled");
            if (generatorEspEnabled)
            {
                generatorEsp = GUILayout.Toggle(generatorEsp, "Generator Glow");
                generator3DBoxes = GUILayout.Toggle(generator3DBoxes, "Generator Boxes");
                generatorName = GUILayout.Toggle(generatorName, "Generator Name");
                generatorStatus = GUILayout.Toggle(generatorStatus, "Generator Status");
                generatorDistance = GUILayout.Toggle(generatorDistance, "Generator Distance");
                GUILayout.Label("Generator ESP Range: " + generatorEspMaxDistance);
                generatorEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(generatorEspMaxDistance, 0f, 2000f));
            }

        }
        void VehicleESPWindow(int WindowID)
        {
            vehicleEspEnabled = GUILayout.Toggle(vehicleEspEnabled, "Enabled");
            if (vehicleEspEnabled)
            {
                vehicleEsp = GUILayout.Toggle(vehicleEsp, "Vehicle Glow");
                vehicle3DBoxes = GUILayout.Toggle(vehicle3DBoxes, "Vehicle Boxes");
                vehicleName = GUILayout.Toggle(vehicleName, "Vehicle Name");
                vehicleDistance = GUILayout.Toggle(vehicleDistance, "Vehicle Distance");
                isLocked = GUILayout.Toggle(isLocked, "Is Locked");
                onlyShowUnlocked = GUILayout.Toggle(onlyShowUnlocked, "Only Show Unlocked");
                GUILayout.Label("Vehicle ESP Range: " + vehicleEspMaxDistance);
                vehicleEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(vehicleEspMaxDistance, 0f, 2000f));
            }

        }
        void ItemESPWindow(int WindowID)
        {
            itemEspEnabled = GUILayout.Toggle(itemEspEnabled, "Enabled");
            if (itemEspEnabled)
            {
                itemEsp = GUILayout.Toggle(itemEsp, "Item Glow");
                item3DBoxes = GUILayout.Toggle(item3DBoxes, "Item Boxes");
                itemName = GUILayout.Toggle(itemName, "Item Name");
                itemDistance = GUILayout.Toggle(itemDistance, "Item Distance");
                filterItems = GUILayout.Toggle(filterItems, "Filter Items");
                if (filterItems)
                {
                    GUILayout.Label("Item Filters:");
                    scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, GUILayout.Height(150));
                    viewGun = GUILayout.Toggle(viewGun, "View Guns");
                    viewMelee = GUILayout.Toggle(viewMelee, "View Melee");
                    viewAmmo = GUILayout.Toggle(viewAmmo, "View Ammo");
                    viewAttachments = GUILayout.Toggle(viewAttachments, "View Attachments");
                    viewBackpack = GUILayout.Toggle(viewBackpack, "View Backpacks");
                    viewClothing = GUILayout.Toggle(viewClothing, "View Clothing");
                    viewMedical = GUILayout.Toggle(viewMedical, "View Medical");
                    viewFuel = GUILayout.Toggle(viewFuel, "View Fuel");
                    viewThrowable = GUILayout.Toggle(viewThrowable, "View Throwables");
                    viewFoodWater = GUILayout.Toggle(viewFoodWater, "View Food/Water");
                    GUILayout.EndScrollView();
                }
                GUILayout.Label("Item ESP Range: " + itemEspMaxDistance);
                itemEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(itemEspMaxDistance, 0f, 2000f));
            }
        }
        void StorageESPWindow(int WindowID)
        {
            storageEspEnabled = GUILayout.Toggle(storageEspEnabled, "Enabled");
            if (storageEspEnabled)
            {
                storageEsp = GUILayout.Toggle(storageEsp, "Storage Glow");
                storage3DBoxes = GUILayout.Toggle(storage3DBoxes, "Storage Boxes");
                storageName = GUILayout.Toggle(storageName, "Storage Name");
                storageDistance = GUILayout.Toggle(storageDistance, "Storage Distance");
                isOpen = GUILayout.Toggle(isOpen, "Is Open");
                GUILayout.Label("Storage ESP Range: " + storageEspMaxDistance);
                storageEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(storageEspMaxDistance, 0f, 2000f));
            }
        }
        void BedESPWindow(int WindowID)
        {
            bedEspEnabled = GUILayout.Toggle(bedEspEnabled, "Enabled");
            if (bedEspEnabled)
            {
                GUILayout.Label("Beds:");
                bedEsp = GUILayout.Toggle(bedEsp, "Bed Glow");
                bed3DBoxes = GUILayout.Toggle(bed3DBoxes, "Bed Boxes");
                isClaimed = GUILayout.Toggle(isClaimed, "Show Claimed");
                bedDistance = GUILayout.Toggle(bedDistance, "Bed Distance");
                GUILayout.Label("Bed ESP Range: " + bedEspMaxDistance);
                bedEspMaxDistance = (float)Math.Round(GUILayout.HorizontalSlider(bedEspMaxDistance, 0f, 2000f));
            }
        }
        void ZombieColorsWindow(int windowID)
        {
            GUILayout.Label("Zombie Glow");
            GUILayout.Label("Color: " + Math.Round(zombieGlowColor.r * 255) + ", " + Math.Round(zombieGlowColor.g * 255) + ", " + Math.Round(zombieGlowColor.b * 255));
            zombieGlowColor.r = (GUILayout.HorizontalSlider(zombieGlowColor.r, 0f, 1f));
            zombieGlowColor.g = (GUILayout.HorizontalSlider(zombieGlowColor.g, 0f, 1f));
            zombieGlowColor.b = (GUILayout.HorizontalSlider(zombieGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Zombie Labels");
            GUILayout.Label("Color: " + Math.Round(zombieLabelColor.r * 255) + ", " + Math.Round(zombieLabelColor.g * 255) + ", " + Math.Round(zombieLabelColor.b * 255));
            zombieLabelColor.r = (GUILayout.HorizontalSlider(zombieLabelColor.r, 0f, 1f));
            zombieLabelColor.g = (GUILayout.HorizontalSlider(zombieLabelColor.g, 0f, 1f));
            zombieLabelColor.b = (GUILayout.HorizontalSlider(zombieLabelColor.b, 0f, 1f));
        }
        void VehicleColorsWindow(int windowID)
        {
            GUILayout.Label("Vehicle Glow");
            GUILayout.Label("Color: " + Math.Round(vehicleGlowColor.r * 255) + ", " + Math.Round(vehicleGlowColor.g * 255) + ", " + Math.Round(vehicleGlowColor.b * 255));
            vehicleGlowColor.r = (GUILayout.HorizontalSlider(vehicleGlowColor.r, 0f, 1f));
            vehicleGlowColor.g = (GUILayout.HorizontalSlider(vehicleGlowColor.g, 0f, 1f));
            vehicleGlowColor.b = (GUILayout.HorizontalSlider(vehicleGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Vehicle Labels");
            GUILayout.Label("Color: " + Math.Round(vehicleLabelColor.r * 255) + ", " + Math.Round(vehicleLabelColor.g * 255) + ", " + Math.Round(vehicleLabelColor.b * 255));
            vehicleLabelColor.r = (GUILayout.HorizontalSlider(vehicleLabelColor.r, 0f, 1f));
            vehicleLabelColor.g = (GUILayout.HorizontalSlider(vehicleLabelColor.g, 0f, 1f));
            vehicleLabelColor.b = (GUILayout.HorizontalSlider(vehicleLabelColor.b, 0f, 1f));
        }
        void ItemColorsWindow(int windowID)
        {
            GUILayout.Label("Item Glow");
            GUILayout.Label("Color: " + Math.Round(itemGlowColor.r * 255) + ", " + Math.Round(itemGlowColor.g * 255) + ", " + Math.Round(itemGlowColor.b * 255));
            itemGlowColor.r = (GUILayout.HorizontalSlider(itemGlowColor.r, 0f, 1f));
            itemGlowColor.g = (GUILayout.HorizontalSlider(itemGlowColor.g, 0f, 1f));
            itemGlowColor.b = (GUILayout.HorizontalSlider(itemGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Item Labels");
            GUILayout.Label("Color: " + Math.Round(itemLabelColor.r * 255) + ", " + Math.Round(itemLabelColor.g * 255) + ", " + Math.Round(itemLabelColor.b * 255));
            itemLabelColor.r = (GUILayout.HorizontalSlider(itemLabelColor.r, 0f, 1f));
            itemLabelColor.g = (GUILayout.HorizontalSlider(itemLabelColor.g, 0f, 1f));
            itemLabelColor.b = (GUILayout.HorizontalSlider(itemLabelColor.b, 0f, 1f));
        }
        void StorageColorsWindow(int windowID)
        {
            GUILayout.Label("Storage Glow");
            GUILayout.Label("Color: " + Math.Round(storageGlowColor.r * 255) + ", " + Math.Round(storageGlowColor.g * 255) + ", " + Math.Round(storageGlowColor.b * 255));
            storageGlowColor.r = (GUILayout.HorizontalSlider(storageGlowColor.r, 0f, 1f));
            storageGlowColor.g = (GUILayout.HorizontalSlider(storageGlowColor.g, 0f, 1f));
            storageGlowColor.b = (GUILayout.HorizontalSlider(storageGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Storage Labels");
            GUILayout.Label("Color: " + Math.Round(storageLabelColor.r * 255) + ", " + Math.Round(storageLabelColor.g * 255) + ", " + Math.Round(storageLabelColor.b * 255));
            storageLabelColor.r = (GUILayout.HorizontalSlider(storageLabelColor.r, 0f, 1f));
            storageLabelColor.g = (GUILayout.HorizontalSlider(storageLabelColor.g, 0f, 1f));
            storageLabelColor.b = (GUILayout.HorizontalSlider(storageLabelColor.b, 0f, 1f));
        }
        void BedColorsWindow(int windowID)
        {
            GUILayout.Label("Bed Glow");
            GUILayout.Label("Color: " + Math.Round(bedGlowColor.r * 255) + ", " + Math.Round(bedGlowColor.g * 255) + ", " + Math.Round(bedGlowColor.b * 255));
            bedGlowColor.r = (GUILayout.HorizontalSlider(bedGlowColor.r, 0f, 1f));
            bedGlowColor.g = (GUILayout.HorizontalSlider(bedGlowColor.g, 0f, 1f));
            bedGlowColor.b = (GUILayout.HorizontalSlider(bedGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Bed Labels");
            GUILayout.Label("Color: " + Math.Round(bedLabelColor.r * 255) + ", " + Math.Round(bedLabelColor.g * 255) + ", " + Math.Round(bedLabelColor.b * 255));
            bedLabelColor.r = (GUILayout.HorizontalSlider(bedLabelColor.r, 0f, 1f));
            bedLabelColor.g = (GUILayout.HorizontalSlider(bedLabelColor.g, 0f, 1f));
            bedLabelColor.b = (GUILayout.HorizontalSlider(bedLabelColor.b, 0f, 1f));
        }
        void PlayerColorsWindow(int windowID)
        {
            scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, GUILayout.Width(280), GUILayout.Height(360));
            GUILayout.Label("Player Glow");
            GUILayout.Label("Color: " + Math.Round(playerGlowColor.r * 255) + ", " + Math.Round(playerGlowColor.g * 255) + ", " + Math.Round(playerGlowColor.b * 255));
            playerGlowColor.r = (GUILayout.HorizontalSlider(playerGlowColor.r, 0f, 1f));
            playerGlowColor.g = (GUILayout.HorizontalSlider(playerGlowColor.g, 0f, 1f));
            playerGlowColor.b = (GUILayout.HorizontalSlider(playerGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Player Labels");
            GUILayout.Label("Color: " + Math.Round(playerLabelColor.r * 255) + ", " + Math.Round(playerLabelColor.g * 255) + ", " + Math.Round(playerLabelColor.b * 255));
            playerLabelColor.r = (GUILayout.HorizontalSlider(playerLabelColor.r, 0f, 1f));
            playerLabelColor.g = (GUILayout.HorizontalSlider(playerLabelColor.g, 0f, 1f));
            playerLabelColor.b = (GUILayout.HorizontalSlider(playerLabelColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Player Box");
            GUILayout.Label("Color: " + Math.Round(player3DBoxColor.r * 255) + ", " + Math.Round(player3DBoxColor.g * 255) + ", " + Math.Round(player3DBoxColor.b * 255));
            player3DBoxColor.r = (GUILayout.HorizontalSlider(player3DBoxColor.r, 0f, 1f));
            player3DBoxColor.g = (GUILayout.HorizontalSlider(player3DBoxColor.g, 0f, 1f));
            player3DBoxColor.b = (GUILayout.HorizontalSlider(player3DBoxColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Player Tracers");
            GUILayout.Label("Color: " + Math.Round(playerTracerColor.r * 255) + ", " + Math.Round(playerTracerColor.g) * 255 + ", " + Math.Round(playerTracerColor.b * 255));
            playerTracerColor.r = (GUILayout.HorizontalSlider(playerTracerColor.r, 0f, 1f));
            playerTracerColor.g = (GUILayout.HorizontalSlider(playerTracerColor.g, 0f, 1f));
            playerTracerColor.b = (GUILayout.HorizontalSlider(playerTracerColor.b, 0f, 1f));
            GUILayout.EndScrollView();
        }
        void claimflagColorsWindow(int windowID)
        {
            scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, GUILayout.Width(280), GUILayout.Height(360));
            GUILayout.Label("Claimflag Glow");
            GUILayout.Label("Color: " + Math.Round(claimflagGlowColor.r * 255) + ", " + Math.Round(claimflagGlowColor.g * 255) + ", " + Math.Round(claimflagGlowColor.b * 255));
            claimflagGlowColor.r = (GUILayout.HorizontalSlider(claimflagGlowColor.r, 0f, 1f));
            claimflagGlowColor.g = (GUILayout.HorizontalSlider(claimflagGlowColor.g, 0f, 1f));
            claimflagGlowColor.b = (GUILayout.HorizontalSlider(claimflagGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Claimflag Labels");
            GUILayout.Label("Color: " + Math.Round(claimflagLabelColor.r * 255) + ", " + Math.Round(claimflagLabelColor.g * 255) + ", " + Math.Round(claimflagLabelColor.b * 255));
            claimflagLabelColor.r = (GUILayout.HorizontalSlider(claimflagLabelColor.r, 0f, 1f));
            claimflagLabelColor.g = (GUILayout.HorizontalSlider(claimflagLabelColor.g, 0f, 1f));
            claimflagLabelColor.b = (GUILayout.HorizontalSlider(claimflagLabelColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Claimflag Box");
            GUILayout.Label("Color: " + Math.Round(claimflag3DBoxColor.r * 255) + ", " + Math.Round(claimflag3DBoxColor.g * 255) + ", " + Math.Round(claimflag3DBoxColor.b * 255));
            claimflag3DBoxColor.r = (GUILayout.HorizontalSlider(claimflag3DBoxColor.r, 0f, 1f));
            claimflag3DBoxColor.g = (GUILayout.HorizontalSlider(claimflag3DBoxColor.g, 0f, 1f));
            claimflag3DBoxColor.b = (GUILayout.HorizontalSlider(claimflag3DBoxColor.b, 0f, 1f));
            GUILayout.EndScrollView();
        }
        void generatorColorsWindow(int windowID)
        {
            scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, GUILayout.Width(280), GUILayout.Height(360));
            GUILayout.Label("Generator Glow");
            GUILayout.Label("Color: " + Math.Round(generatorGlowColor.r * 255) + ", " + Math.Round(generatorGlowColor.g * 255) + ", " + Math.Round(generatorGlowColor.b * 255));
            generatorGlowColor.r = (GUILayout.HorizontalSlider(generatorGlowColor.r, 0f, 1f));
            generatorGlowColor.g = (GUILayout.HorizontalSlider(generatorGlowColor.g, 0f, 1f));
            generatorGlowColor.b = (GUILayout.HorizontalSlider(generatorGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Generator Labels");
            GUILayout.Label("Color: " + Math.Round(generatorLabelColor.r * 255) + ", " + Math.Round(generatorLabelColor.g * 255) + ", " + Math.Round(generatorLabelColor.b * 255));
            generatorLabelColor.r = (GUILayout.HorizontalSlider(generatorLabelColor.r, 0f, 1f));
            generatorLabelColor.g = (GUILayout.HorizontalSlider(generatorLabelColor.g, 0f, 1f));
            generatorLabelColor.b = (GUILayout.HorizontalSlider(generatorLabelColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Generator Box");
            GUILayout.Label("Color: " + Math.Round(generator3DBoxColor.r * 255) + ", " + Math.Round(generator3DBoxColor.g * 255) + ", " + Math.Round(generator3DBoxColor.b * 255));
            generator3DBoxColor.r = (GUILayout.HorizontalSlider(generator3DBoxColor.r, 0f, 1f));
            generator3DBoxColor.g = (GUILayout.HorizontalSlider(generator3DBoxColor.g, 0f, 1f));
            generator3DBoxColor.b = (GUILayout.HorizontalSlider(generator3DBoxColor.b, 0f, 1f));
            GUILayout.EndScrollView();
        }
        void FriendColorsWindow(int windowID)
        {
            scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, GUILayout.Width(280), GUILayout.Height(360));
            GUILayout.Label("Friend Glow");
            GUILayout.Label("Color: " + Math.Round(friendGlowColor.r * 255) + ", " + Math.Round(friendGlowColor.g * 255) + ", " + Math.Round(friendGlowColor.b * 255));
            friendGlowColor.r = (GUILayout.HorizontalSlider(friendGlowColor.r, 0f, 1f));
            friendGlowColor.g = (GUILayout.HorizontalSlider(friendGlowColor.g, 0f, 1f));
            friendGlowColor.b = (GUILayout.HorizontalSlider(friendGlowColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Friend Labels");
            GUILayout.Label("Color: " + Math.Round(friendLabelColor.r * 255) + ", " + Math.Round(friendLabelColor.g * 255) + ", " + Math.Round(friendLabelColor.b * 255));
            friendLabelColor.r = (GUILayout.HorizontalSlider(friendLabelColor.r, 0f, 1f));
            friendLabelColor.g = (GUILayout.HorizontalSlider(friendLabelColor.g, 0f, 1f));
            friendLabelColor.b = (GUILayout.HorizontalSlider(friendLabelColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Friend 2D Box");
            GUILayout.Label("Color: " + Math.Round(friend2DBoxColor.r * 255) + ", " + Math.Round(friend2DBoxColor.g * 255) + ", " + Math.Round(friend2DBoxColor.b * 255));
            friend2DBoxColor.r = (GUILayout.HorizontalSlider(friend2DBoxColor.r, 0f, 1f));
            friend2DBoxColor.g = (GUILayout.HorizontalSlider(friend2DBoxColor.g, 0f, 1f));
            friend2DBoxColor.b = (GUILayout.HorizontalSlider(friend2DBoxColor.b, 0f, 1f));
            GUILayout.Label("------------------------------------------------------");

            GUILayout.Label("Friend Tracers");
            GUILayout.Label("Color: " + Math.Round(friendTracerColor.r * 255) + ", " + Math.Round(friendTracerColor.g) * 255 + ", " + Math.Round(friendTracerColor.b * 255));
            friendTracerColor.r = (GUILayout.HorizontalSlider(friendTracerColor.r, 0f, 1f));
            friendTracerColor.g = (GUILayout.HorizontalSlider(friendTracerColor.g, 0f, 1f));
            friendTracerColor.b = (GUILayout.HorizontalSlider(friendTracerColor.b, 0f, 1f));
            GUILayout.EndScrollView();
        }
        void WeaponsWindow(int windowID)
        {
            showGunRange = GUILayout.Toggle(showGunRange, "Show Info");
            noSpread = GUILayout.Toggle(noSpread, "No Spread");
            noSway = GUILayout.Toggle(noSway, "No Sway");
            noRecoil = GUILayout.Toggle(noRecoil, "No Recoil");
            LongRangeMelee = GUILayout.Toggle(LongRangeMelee, "Custom Melee Range");
            if (LongRangeMelee)
            {
                MeleeRange = (int)Math.Round(GUILayout.HorizontalSlider(MeleeRange, 1, 6));
                GUILayout.Label("Melee Range: " + MeleeRange);
            }
        }
        void NavegationWindow(int windowID)
        {
            toolbarInt = GUILayout.SelectionGrid(toolbarInt, toolbarStrings, 4);
        }
        void SelectionWindow(int windowID)
        {
            toolbar1Int = GUILayout.SelectionGrid(toolbar1Int, toolbar1Strings, 1);
        }
        void MiscSelectionWindow(int windowID)
        {
            misctoolbarInt = GUILayout.SelectionGrid(misctoolbarInt, misctoolbarStrings, 1);
        }
        void MiscVehicleWindow(int windowID)
        {
            customengine = GUILayout.Toggle(customengine, "Custom Vehicle Engine");
            if (customengine)
            {
                GUILayout.Label("<size=10>Custom engine can cause you to not be able to re-enter a vehicle, I recommend using No-Clip to fly instead</size>");
                if (GUILayout.Button("Vehicle Engine: " + Vehicles.CarEngine))
                {
                    vehnum += 1;
                    needchanging1 = true;
                }
            }
            noclip = GUILayout.Toggle(noclip, "Vehicle No-Clip");
            if (noclip)
            {
                speedMultiplier = GUILayout.HorizontalSlider(speedMultiplier, 0, 10);
                GUILayout.Label("Speed Multiplier: " + speedMultiplier);
            }
        }
        void MiscChatWindow(int windowID)
        {
            chatBind = GUILayout.Toggle(chatBind, "Use Keybind (" + chatKey.ToString() + ")");
            spamText = GUILayout.Toggle(spamText, "Spam Text");
            if (GUILayout.Button("Enter Chat")) ChatManager.sendChat(EChatMode.GLOBAL, cmdString);
            cmdString = GUILayout.TextField(cmdString);
            GUILayout.Label("<size=10>Tip: You can accept tpa's while dead by putting /tpa a in the text input</size>");
        }
        void MiscInteractWindow(int windowID)
        {
            InteractThroughWalls = GUILayout.Toggle(InteractThroughWalls, "Interact Through Walls");
        }
        void MiscOtherWindow(int windowID)
        {
            GUILayout.Label("Cheat By: Coopyy#6398");
            //GUILayout.Label("Bypass By: Thanking");
            GUI.color = Color.green;
            if (GUILayout.Button("Visit Binjector Website"))
            {
                System.Diagnostics.Process.Start("http://binjector.fun");
            }
            Color clr;
            ColorUtility.TryParseHtmlString("#7289da", out clr);
            GUI.color = clr;
            if (GUILayout.Button("Visit Our Discord Server"))
            {
                System.Diagnostics.Process.Start("https://discord.gg/AmRZqhE");
            }
            GUI.color = Color.grey;
            if (GUILayout.Button("View Cheat Source Code"))
            {
                System.Diagnostics.Process.Start("https://github.com/Coopyy/Binjector");
            }
            GUI.color = defColor;
        }
        void MiscSettingsWindow(int windowID)
        {
            Functions.fontsize = (int)Math.Round(GUILayout.HorizontalSlider(Functions.fontsize, 1, 30));
            GUILayout.Label("Label Size: " + Functions.fontsize);
        }
        void MiscCameraWindow(int windowID)
        {
            freeCam = GUILayout.Toggle(freeCam, "Freecam");
        }
        void AimbotWindow(int windowID)
        {
            aimEnabled = GUILayout.Toggle(aimEnabled, "Aimbot On");
            aimOnFire = GUILayout.Toggle(aimOnFire, "Aimbot On Fire");
            FOVAim = GUILayout.Toggle(FOVAim, "FOV Aim");
            silentAim = GUILayout.Toggle(silentAim, "Silent Aim");
            if (silentAim)
            {
                GUILayout.Label("<size=10>For some reason, silent aim is more effective when shooting at the ground</size>");
            }
            launchAmount = (float)Math.Round(GUILayout.HorizontalSlider(launchAmount, 0, 30));
            GUILayout.Label("Ragdoll Launch: " + launchAmount);
        }
        void KeybindWindow(int windowID)
        {
            #region MenuKey
            GUILayout.BeginHorizontal();
            GUILayout.Box("Menu Key: " + menuKey.ToString(), GUILayout.Width(200));
            if (GUILayout.Button("Reset", GUILayout.Width(85)))
            {
                menuKey = KeyCode.F1;
            }
            if (GUILayout.Button("Bind", GUILayout.Width(85)))
            {
                bindingMenu = true;
                menuKey = KeyCode.None;
            }
            GUILayout.EndHorizontal();
            #endregion
            #region AimbotKey
            GUILayout.BeginHorizontal();
            GUILayout.Box("Aimbot Key: " + aimKey.ToString(), GUILayout.Width(200));
            if (GUILayout.Button("Reset", GUILayout.Width(85)))
            {
                aimKey = KeyCode.F2;
            }
            if (GUILayout.Button("Bind", GUILayout.Width(85)))
            {
                bindingAim = true;
                aimKey = KeyCode.None;
            }
            GUILayout.EndHorizontal();
            #endregion
            #region ChatKey
            GUILayout.BeginHorizontal();
            GUILayout.Box("Chat Key: " + chatKey.ToString(), GUILayout.Width(200));
            if (GUILayout.Button("Reset", GUILayout.Width(85)))
            {
                chatKey = KeyCode.F3;
            }
            if (GUILayout.Button("Bind", GUILayout.Width(85)))
            {
                bindingChat = true;
                chatKey = KeyCode.None;
            }
            GUILayout.EndHorizontal();
            #endregion
            #region ItemKey
            GUILayout.BeginHorizontal();
            GUILayout.Box("Auto Item Key: " + itemKey.ToString(), GUILayout.Width(200));
            if (GUILayout.Button("Reset", GUILayout.Width(85)))
            {
                itemKey = KeyCode.F4;
            }
            if (GUILayout.Button("Bind", GUILayout.Width(85)))
            {
                bindingItem = true;
                itemKey = KeyCode.None;
            }
            GUILayout.EndHorizontal();
            #endregion
        }
        void PlayersWindow(int windowID)
        {
            if (Provider.isConnected && !Provider.isLoading)
            {
                GUILayout.Label("<size=10>Players in your group will automatically be your friend</size>");
                scrollPosition1 = GUILayout.BeginScrollView(scrollPosition1, GUILayout.Width(380), GUILayout.Height(360));
                players = Provider.clients.ToArray();
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].player != Player.player)
                    {
                        GUILayout.BeginHorizontal();
                        if (players[i].isAdmin)
                        {
                            GUI.color = Color.cyan;
                            GUILayout.Box(players[i].playerID.characterName, GUILayout.Width(225));
                            GUI.color = defColor;
                        }
                        else
                        {
                            GUILayout.Box(players[i].playerID.characterName, GUILayout.Width(225));
                        }

                        if (!Functions.isFriend(players[i].playerID.steamID.ToString()))
                        {
                            if (GUILayout.Button("Add Friend", GUILayout.Width(120)))
                            {
                                friends.Add(players[i].playerID.steamID.ToString());
                            }
                        }
                        else
                        {
                            GUI.color = Color.green;
                            if (GUILayout.Button("Remove Friend", GUILayout.Width(120)))
                            {
                                friends.Remove(players[i].playerID.steamID.ToString());
                            }
                            GUI.color = defColor;
                        }

                        GUILayout.EndHorizontal();
                    }
                }
                GUILayout.EndScrollView();
            }
            else
            {
                GUILayout.Label("Not in Server");
            }

        }
        void ItemsMenuWindow(int windowID)
        {
            autoItemPickup = GUILayout.Toggle(autoItemPickup, "Auto Item Pickup");
            GUILayout.Label("Item Filters:");
            pickupAll = GUILayout.Toggle(pickupAll, "Pick up All");
            pickupGun = GUILayout.Toggle(pickupGun, "Pick up Guns");
            pickupMelee = GUILayout.Toggle(pickupMelee, "Pick up Melee");
            pickupAmmo = GUILayout.Toggle(pickupAmmo, "Pick up Ammo");
            pickupAttachments = GUILayout.Toggle(pickupAttachments, "Pick up Attachments");
            pickupBackpack = GUILayout.Toggle(pickupBackpack, "Pick up Backpacks");
            pickupClothing = GUILayout.Toggle(pickupClothing, "Pick up Clothing");
            pickupMedical = GUILayout.Toggle(pickupMedical, "Pick up Medical");
            pickupFuel = GUILayout.Toggle(pickupFuel, "Pick up Fuel");
            pickupThrowable = GUILayout.Toggle(pickupThrowable, "Pick up Throwables");
            pickupFoodWater = GUILayout.Toggle(pickupFoodWater, "Pick up Food/Water");
            GUI.DragWindow();
        }
        #endregion
    }
}