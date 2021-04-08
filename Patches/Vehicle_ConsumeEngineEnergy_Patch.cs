using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(Vehicle))]  // Patch for the Vehicle class.
    [HarmonyPatch("ConsumeEngineEnergy")]        // The Vehicle class's ConsumeEngineEnergy method.
    internal class Vehicle_ConsumeEngineEnergy_Patch
    {
        [HarmonyPrefix]      // Harmony prefix
        public static bool Prefix(Vehicle __instance, ref float energyCost, ref bool __result)
        {
            float enginePowerRating = Traverse.Create(__instance).Field("enginePowerRating").GetValue<float>();
            EnergyInterface thisEnergyInterface = __instance.GetComponent<EnergyInterface>();
            EnergyMixin thisEnergyMixing = __instance.GetComponent<EnergyMixin>();
            float realEnergyCost = energyCost / enginePowerRating;            

            if (Player.main.currentMountedVehicle != null && Player.main.currentMountedVehicle == __instance)
            {
                if (SeamothInfo.ModeGreenOn) // Only gears 1 to 5 are provided (note that the first number in the division bracket is the desired energy consumption)
                {
                    if (Config.SeamothGearValue == 1f)
                        realEnergyCost = energyCost * (10f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 2f)
                        realEnergyCost = energyCost * (20f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 3f)
                        realEnergyCost = energyCost * (40f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 4f)
                        realEnergyCost = energyCost / enginePowerRating; // Energy consumption is 80 (80f / 80f)
                    else if (Config.SeamothGearValue == 5f)
                        realEnergyCost = energyCost * (120f / 80f) / enginePowerRating;
                }
                else
                { // note that the first number in the division bracket is the desired energy consumption
                    if (Config.SeamothGearValue == 1f)
                        realEnergyCost = energyCost * (10f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 2f)
                        realEnergyCost = energyCost * (30f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 3f)
                        realEnergyCost = energyCost * (60f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 4f)
                        realEnergyCost = energyCost * (100f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 5f)
                        realEnergyCost = energyCost * (150f / 80f) / enginePowerRating;
                    else if (Config.SeamothGearValue == 6f)
                        realEnergyCost = energyCost * (300f / 80f) / enginePowerRating;
                } // end else
                int num;
                float energyCanProvide = thisEnergyInterface.TotalCanProvide(out num);
                __result = thisEnergyMixing.ConsumeEnergy(Mathf.Min(realEnergyCost, energyCanProvide));
                return false;

            } // end if (Player.main.currentMountedVehicle != null)
            return true;

        } // end public static bool Prefix(Vehicle __instance, ref float energyCost, ref bool __result)

    } // end internal class Vehicle_ConsumeEngineEnergy_Patch

}
