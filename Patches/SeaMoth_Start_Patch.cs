using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(SeaMoth))]  // Patch for the SeaMoth class.
    [HarmonyPatch("Start")]        // The SeaMoth class's Start method.
    internal class SeaMoth_Start_Patch
    {
        [HarmonyPrefix]      // Harmony Prefix
        public static bool Prefix(SeaMoth __instance)
        {
            // Kickstart battery monitoring
            if (__instance.GetPilotingMode())
                MonitorBatteryCount.MonitorSeamothBatteryCount(__instance);
            return true;
        } // end public static void Postfix()

    } // end internal class Vehicle_Start_Patch

}
