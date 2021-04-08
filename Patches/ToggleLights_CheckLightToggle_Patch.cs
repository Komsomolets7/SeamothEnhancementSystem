using Harmony;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(ToggleLights))]  // Patch for the ToggleLights class.
    [HarmonyPatch("CheckLightToggle")]        // The SetLightsActive class's CheckLightToggle method.
    internal class ToggleLights_CheckLightToggle_Patch
    {
        [HarmonyPrefix]      // Harmony postfix
        public static bool Prefix(ToggleLights __instance)
        {
            if (SeamothInfo.preventLightToggle)
                return false;
            else
                return true;
        }
    }
}
