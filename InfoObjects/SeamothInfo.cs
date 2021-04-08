using UnityEngine;

namespace SeamothEnhancementSystem.InfoObjects
{
    internal static class SeamothInfo
    {
        internal static bool CruiseControlOn = false;
        internal static bool ModeGreenOn = false; // Starting mode: if set to false, need to also change Vehicle Upadate patch turboPlus from 0f to 2f.
        internal static bool ModeChanged = false;
        internal static bool NoBatteries = false;
        internal static float lastSeamothGearValue = 0f;
        internal static int MainBatteryCount = 0;
        internal static int TotalBatteryCount = 0;
        internal static int BatteryInSlot = 0;

        internal static float timeLastLightToggle = Time.time;
        internal static bool preventLightToggle = false;

        internal static float thisLightLowSpotAngle = 100f;
        internal static float thisLightLowIntensity = 1.0f;
        internal static float thisLightLowRange = 60f;

        internal static float thisLightHighSpotAngle = 50f;
        internal static float thisLightHighIntensity = 1.6f;
        internal static float thisLightHighRange = 180f;

        internal static float timer;

        internal static bool electricalModuleIn, electronicModuleIn, mechanicalModuleIn, seamothLinkModuleIn, mainModuleIn;

        public static void CheckModuleStatus(Vehicle thisSeaMoth)
        {
            if (Player.main != null)
            {
                Inventory playerInventory = Inventory.main;
                seamothLinkModuleIn = playerInventory.equipment.GetCount(Modules.SeamothLink.TechTypeID) > 0;
            }

            mainModuleIn = thisSeaMoth.modules.GetCount(Modules.SeamothEnhancementSystemModule.TechTypeID) > 0;

            if (mainModuleIn)
            {
                electricalModuleIn = true;
                electronicModuleIn = true;
                mechanicalModuleIn = true;
            }
            else
            {
                electricalModuleIn = thisSeaMoth.modules.GetCount(Modules.ElectricalEnhancement.TechTypeID) > 0;
                electronicModuleIn = thisSeaMoth.modules.GetCount(Modules.ElectronicEnhancement.TechTypeID) > 0;
                mechanicalModuleIn = thisSeaMoth.modules.GetCount(Modules.MechanicalEnhancement.TechTypeID) > 0;                
            }
        }
    }
}
