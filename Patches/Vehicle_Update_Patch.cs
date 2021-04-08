using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(Vehicle))]  // Patch for the Vehicle class.
    [HarmonyPatch("Update")]        // The Vehicle class's Update method.
    internal class Vehicle_Update_Patch
    {
        internal static bool HighBeamOn = false;
        internal static bool LowBeamIsSet = false;
        internal static bool HighBeamIsSet = false;
        internal static bool LightsAreOn = false;

        public static float largeFactor = 3.5f;
        public static float smallFactor = 1.5f;
        public static float turboPlus = 2f; // starts with value for Turbo mode

        public static float forwardForce = 13f; // (default)
        public static float backwardForce = 5f; // (default)
        public static float sidewardForce = 11.5f;  // (default)
        public static float verticalForce = 11f;  // (default)

        public static float highBeamEnergyCost = 0.05f; // starts with energy cost for Turbo mode


        // ######################################################################
        // Helper method
        // ######################################################################

        public static void ConsumeHighBeamEnergy(Vehicle thisVehicle, float thisEnergyCost)
        {
            EnergyInterface thisEnergyInterface = thisVehicle.GetComponent<EnergyInterface>();
            float amount = DayNightCycle.main.deltaTime * thisEnergyCost;
            thisEnergyInterface.ConsumeEnergy(amount);
        }


        // ######################################################################
        // Patch - Harmony postfix - set speed
        // ######################################################################

        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(Vehicle __instance)
        {
            // Implement energy consumption changes
            Player main = Player.main; // player
            Vehicle thisSeamoth = (__instance as SeaMoth);
            ToggleLights thisToggleLights = __instance.GetComponentInChildren<ToggleLights>();
            
            if (main != null && thisSeamoth != null)
            {
                // SeamothInfo.CheckModuleStatus(thisSeamoth); -> is checked in Player_Update_Patch

                // Line of code below is reserved for future releases to implement further energy savings with VehiclePowerUpgradeModule
                // bool efficiencyLoaded = thisSeamoth.modules.GetCount(TechType.VehiclePowerUpgradeModule) > 0;

                bool playerPiloting = Player.main.GetMode() == Player.Mode.LockedPiloting;

                if (playerPiloting && Player.main.GetVehicle() == thisSeamoth)
                {
                    // set correct speed factor for Green and Turbo modes and energy usage which is lower in Green mode
                    // SeamothInfo.ModeChanged is flagged in MonitorModeKey class
                    if (SeamothInfo.ModeChanged && SeamothInfo.electronicModuleIn)
                    {
                        if (SeamothInfo.ModeGreenOn)
                        {
                            turboPlus = 0f;
                            highBeamEnergyCost = 0.025f;
                        }
                        else
                        {
                            turboPlus = 2f;
                            highBeamEnergyCost = 0.05f;
                        }
                    }
                    
                    // Implement higher energy usage for high beam
                    if (thisToggleLights != null)
                        LightsAreOn = thisToggleLights.GetLightsActive();

                    if (HighBeamOn && LightsAreOn) // && SeamothInfo.electricalModuleIn)
                        ConsumeHighBeamEnergy(__instance, highBeamEnergyCost);

                    // If Electronic module is NOT in we turn Green mode OFF and turn Cruise Control OFF
                    if (!SeamothInfo.electronicModuleIn)
                    {
                        // if (!SeamothInfo.ModeChanged) ; // && !SeamothInfo.ModeChanged)
                        if (SeamothInfo.ModeGreenOn)
                        {
                            SeamothInfo.ModeGreenOn = false;
                            SeamothInfo.ModeChanged = true;
                        }

                        if (SeamothInfo.CruiseControlOn)
                            SeamothInfo.CruiseControlOn = false;
                    }

                    // Set Seamoth gear to 4 if no mechanical module in (speed closest to vanilla)
                    if (!SeamothInfo.mechanicalModuleIn)
                    {
                        if (Config.SeamothGearValue != 4f)
                        {
                            Config.SeamothGearValue = 4f;
                            PlayerPrefs.SetFloat("SeamothGearValueSlider", Config.SeamothGearValue);
                        }
                    }

                    // Set speeds to match gear setting
                    if (SeamothInfo.mechanicalModuleIn || SeamothInfo.electronicModuleIn)
                    {
                        if (Config.SeamothGearValue == 1f && (SeamothInfo.lastSeamothGearValue != 1f || SeamothInfo.ModeChanged))
                        {
                            thisSeamoth.forwardForce = forwardForce - (largeFactor * 3f);
                            thisSeamoth.backwardForce = backwardForce - (smallFactor * 3f);
                            thisSeamoth.sidewardForce = sidewardForce - (largeFactor * 3f);
                            thisSeamoth.verticalForce = verticalForce - (largeFactor * 2.5f);
                            SeamothInfo.lastSeamothGearValue = 1f;
                        }
                        else if (Config.SeamothGearValue == 2f && (SeamothInfo.lastSeamothGearValue != 2f || SeamothInfo.ModeChanged))
                        {
                            thisSeamoth.forwardForce = forwardForce - (largeFactor * 2f) + turboPlus;
                            thisSeamoth.backwardForce = backwardForce - (smallFactor * 2f) + turboPlus;
                            thisSeamoth.sidewardForce = sidewardForce - (largeFactor * 2f) + turboPlus;
                            thisSeamoth.verticalForce = verticalForce - (largeFactor * 2f) + turboPlus;
                            SeamothInfo.lastSeamothGearValue = 2f;
                        }
                        else if (Config.SeamothGearValue == 3f && (SeamothInfo.lastSeamothGearValue != 3f || SeamothInfo.ModeChanged))
                        {
                            thisSeamoth.forwardForce = forwardForce - largeFactor + turboPlus;
                            thisSeamoth.backwardForce = backwardForce - smallFactor + turboPlus;
                            thisSeamoth.sidewardForce = sidewardForce - largeFactor + turboPlus;
                            thisSeamoth.verticalForce = verticalForce - largeFactor + turboPlus;
                            SeamothInfo.lastSeamothGearValue = 3f;
                        }
                        else if (Config.SeamothGearValue == 4f && (SeamothInfo.lastSeamothGearValue != 4f || SeamothInfo.ModeChanged))
                        {
                            thisSeamoth.forwardForce = forwardForce + turboPlus;
                            thisSeamoth.backwardForce = backwardForce + turboPlus;
                            thisSeamoth.sidewardForce = sidewardForce + turboPlus;
                            thisSeamoth.verticalForce = verticalForce + turboPlus;
                            SeamothInfo.lastSeamothGearValue = 4f;
                        }
                        else if (Config.SeamothGearValue == 5f && (SeamothInfo.lastSeamothGearValue != 5f || SeamothInfo.ModeChanged))
                        {
                            thisSeamoth.forwardForce = forwardForce + largeFactor + (turboPlus * 2f);
                            thisSeamoth.backwardForce = backwardForce + smallFactor + (turboPlus * 2f);
                            thisSeamoth.sidewardForce = sidewardForce + largeFactor + (turboPlus * 2f);
                            thisSeamoth.verticalForce = verticalForce + largeFactor + (turboPlus * 2f);
                            SeamothInfo.lastSeamothGearValue = 5f;
                        }
                        else if (Config.SeamothGearValue == 6f && (SeamothInfo.lastSeamothGearValue != 6f || SeamothInfo.ModeChanged))
                        {
                            thisSeamoth.forwardForce = forwardForce + (largeFactor * 2f) + (turboPlus * 2f);
                            thisSeamoth.backwardForce = backwardForce + (smallFactor * 2f) + (turboPlus * 2f);
                            thisSeamoth.sidewardForce = sidewardForce + (largeFactor * 2f) + (turboPlus * 2f);
                            thisSeamoth.verticalForce = verticalForce + (largeFactor * 2f) + (turboPlus * 2f);
                            SeamothInfo.lastSeamothGearValue = 6f;
                        }
                        SeamothInfo.ModeChanged = false;
                    }
                    else // If no Electronic (Green/Turbo) or Mechanical (Gears) modules in, set speeds to vanilla
                    {
                        if (SeamothInfo.lastSeamothGearValue != 0f)
                        {
                            thisSeamoth.forwardForce = forwardForce;
                            thisSeamoth.backwardForce = backwardForce;
                            thisSeamoth.sidewardForce = sidewardForce;
                            thisSeamoth.verticalForce = verticalForce;
                            SeamothInfo.lastSeamothGearValue = 0f;
                        }
                    }
                } // end if (playerPiloting)

            }//end if (main != null)

        } // end public static void Postfix(Vehicle __instance)

    } // end internal class Vehicle_Update_Patch

}
