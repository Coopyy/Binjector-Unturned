//use this to shortern code
using System.Reflection;

namespace Binjector.Variables
{
    public class ReflectionVariables
    {
        public static BindingFlags PublicInstance = BindingFlags.Public | BindingFlags.Instance;
        public static BindingFlags PublicStatic = BindingFlags.Public | BindingFlags.Static;
        public static BindingFlags PrivateInstance = BindingFlags.NonPublic | BindingFlags.Instance;
        public static BindingFlags PrivateStatic = BindingFlags.NonPublic | BindingFlags.Static;

        public static BindingFlags EverythingStatic =
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Public;

        public static BindingFlags EverythingInstance =
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public;

        public static BindingFlags Everything =
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static;


    }
}