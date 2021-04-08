using Harmony;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.ManageGUI;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(Player))]  // Patch for the Player class.
    [HarmonyPatch("Update")]        // The Player class's Update method.
    internal class Player_Update_Patch
    {

        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(Player __instance)
        {

            if (__instance != null)
            {
                // Implement GUI gear info text display
                Vehicle thisSeamoth = (__instance.GetVehicle() as SeaMoth);

                if (thisSeamoth != null)
                {
                    SeamothInfo.CheckModuleStatus(thisSeamoth);
                    bool playerPiloting = __instance.GetMode() == Player.Mode.LockedPiloting;
                    
                    if ((SeamothInfo.electricalModuleIn || SeamothInfo.electronicModuleIn || SeamothInfo.mechanicalModuleIn) && playerPiloting && !Player.main.GetPDA().isInUse)
                        ManageAllGUIElements.ManageAllGuiElements();                       
                    else // remove GUI if upgrade not loaded
                        ManageAllGUIElements.TurnUIOff();
                }
                else
                    ManageAllGUIElements.TurnUIOff();

            } // end if (__instance != null)

        } // end public static void Postfix(Player __instance)

    } // end internal class Player_Update_Patch

}
