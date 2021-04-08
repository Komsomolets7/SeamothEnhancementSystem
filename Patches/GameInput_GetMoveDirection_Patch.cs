using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(GameInput))]  // Patch for the GameInput class.
    [HarmonyPatch("GetMoveDirection")]        // The GameInput class's GetMoveDirection method.
    internal class GameInput_GetMoveDirection_Patch
    {
        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(ref Vector3 __result)
        {
            if (SeamothInfo.electronicModuleIn)
            {
                if (Player.main.currentMountedVehicle != null && SeamothInfo.CruiseControlOn)
                    __result = new Vector3(__result.x, __result.y, 1f);
                else if (SeamothInfo.CruiseControlOn) // turns Cruise Control off when not piloting
                    SeamothInfo.CruiseControlOn = false;
            }
        }
    }
}
