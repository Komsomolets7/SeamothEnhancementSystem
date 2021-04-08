using Harmony;
using QModManager.API;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(Vehicle))]  // Patch for the Vehicle class.
    [HarmonyPatch("Start")]        // The Vehicle class's Start method.
    internal class Vehicle_Start_Patch
    {
        [HarmonyPrefix]      // Harmony Prefix
        public static void Prefix()
        {
            // Determine if SeaglideMapControls mod is present to apply fix for light switching via SeaglideMapControlLightFix
            IQMod modSeaglideMapControls = QModServices.Main.FindModById("SeaglideMapControls");
            if (modSeaglideMapControls != null && modSeaglideMapControls.IsLoaded)
                OtherModsInfo.SeaglideMapControls = true;
        }
    }
}
