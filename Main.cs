using Binjector.Utilities;
using System;
using System.Threading;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Binjector
{
	public static class Main
	{
        public static string Version = "Binjector 2.0.0";
        public static GameObject LoadObj;
		public static void Load()
		{
			try
			{
				LoadObj = new GameObject("Manager");
				UnityEngine.Object.DontDestroyOnLoad(Main.LoadObj);
				LoadObj.AddComponent<Manager>();
				Debug.Log("Binjector successfully loaded");
				Debug.Log(Version + "- By: Coopyy");
			}
			catch (Exception error)
			{
				Debug.Log("An error has occured. If you believe this is a bug, please report it on the issue tracker");
				Debug.Log(error);
			}
            
		}
		
	}
}
