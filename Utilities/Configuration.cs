using System.IO;
using UnityEngine;

namespace Binjector.Utilities
{
    public class Configuration
    {
        public static void SaveMenu()
        {
            MenuGUI info = new MenuGUI();
            //string json = JsonConvert.SerializeObject(info);
            //File.WriteAllText(string.Format("{0}/Binjector.config", Application.dataPath), json);
        }

        public static void LoadMenu()
        {
            if(File.Exists("../../config.json"))
            {
                string file = System.IO.File.ReadAllText("binjector.json");
                //MenuGUI m = JsonConvert.DeserializeObject<MenuGUI>(file);
            }
        }
    }
}
