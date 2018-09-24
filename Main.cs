using Binjector.Utilities;
using System;
using System.Threading;
using UnityEngine;

namespace Binjector
{
	public static class Main
	{
        public static string Version = "Binjector 2.0.0";
        public static GameObject LoadObj;
		public static void Load()
		{
			LoadObj = new GameObject("Manager");
            UnityEngine.Object.DontDestroyOnLoad(Main.LoadObj);
            LoadObj.AddComponent<Manager>();
		}
	}
}
