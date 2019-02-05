//Add basis of interacting through walls etc. Still got a lot to do
using System.Reflection;
using Binjector.Variables;
using SDG.Unturned;

namespace Binjector.Overrides
{
    public class OV_PlayerInteract
    {
        private static FieldInfo FocusField;
        private static FieldInfo TargetInformation;
        private static FieldInfo InteractableField;
        private static FieldInfo InteractableField2;
        private static FieldInfo PurchaseAssetField;
        
        //Defining
        public static void Initialise()
        {
            FocusField = typeof(PlayerInteract).GetField("focus", ReflectionVariables.PrivateStatic);
            InteractableField = typeof(PlayerInteract).GetField("_interactable", ReflectionVariables.PrivateStatic);
            InteractableField2 =
                typeof(PlayerInteract).GetField("_interactable2", ReflectionVariables.PrivateStatic);
            PurchaseAssetField =
                typeof(PlayerInteract).GetField("purchaseAsset", ReflectionVariables.PrivateStatic);
            TargetInformation = typeof(PlayerInteract).GetField("target", ReflectionVariables.PrivateStatic);
        }



    }
}