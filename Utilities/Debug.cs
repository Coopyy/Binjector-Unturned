//
using System;
using SDG.Unturned;

namespace Binjector.Utilities
{
    public class Debug
    {
        public static void Log(object output)
        {
          Debug.Log((object) string.Format("{0}\r\n"));
        }

        public static void ExceptionLog(Exception exception)
        {
            Debug.Log(("An exception has occured" + exception));
        }
    }
}