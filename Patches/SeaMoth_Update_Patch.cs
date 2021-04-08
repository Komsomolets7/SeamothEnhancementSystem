using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.ManageGUI;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(SeaMoth))]  // Patch for the SeaMoth class.
    [HarmonyPatch("Update")]        // The SeaMoth class's Update method.
    internal class SeaMoth_Update_Patch
    {
        // Change vanilla Seamoth operation.
        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(SeaMoth __instance)
        {
            if (__instance.GetPilotingMode())
            {
                EnergyMixin thisEnergyMixing = __instance.GetComponent<EnergyMixin>();
                EnergyInterface thisEnergyInterface = thisEnergyMixing.GetComponent<EnergyInterface>();
                thisEnergyInterface.GetValues(out float charge, out float capacity);

                // Display if Player has no Seamoth Link Chip
                if (Config.ShowKeyPromptToggleValue)
                {
                    if (SeamothInfo.electricalModuleIn || SeamothInfo.electronicModuleIn || SeamothInfo.mechanicalModuleIn)
                    {
                        if (!SeamothInfo.seamothLinkModuleIn && !Subtitles.main.popup.isShowingMessage)
                        {
                            DisplayPrompts.DisplayNoLinkPrompts();
                        }
                    }
                }

                // If Seamoth without battery, and electricalModuleIn, show change battery prompt only
                // Display order 1. ELectrical, 2. Electronic, 3. Mechanical (each line adds itself up to the top of player prompts)

                // ###########
                // Mechanical
                // ###########
                if (SeamothInfo.mechanicalModuleIn && SeamothInfo.seamothLinkModuleIn && !FPSInputModule.current.lockMovement && SeamothInfo.BatteryInSlot == 1)
                {
                    // Detect key press and set variable (march up) to set Seamoth gear
                    MonitorGearKeys.MonitorGearKeysDown();

                    if (!Subtitles.main.popup.isShowingMessage && Config.ShowKeyPromptToggleValue && SeamothInfo.BatteryInSlot == 1)
                        DisplayPrompts.DisplayMechanicalPrompts();
                }

                // ###########
                // Electronic
                // ###########

                // Adjust gear if SeamothInfo.seamothLinkModuleIn not in
                if (!SeamothInfo.seamothLinkModuleIn && Config.SeamothGearValue != 4f)
                {
                    Config.SeamothGearValue = 4f;
                    PlayerPrefs.SetFloat("SeamothGearValueSlider", Config.SeamothGearValue);
                }

                if (SeamothInfo.electronicModuleIn && SeamothInfo.seamothLinkModuleIn && !FPSInputModule.current.lockMovement && SeamothInfo.BatteryInSlot == 1)
                {
                    // Detect key press and set variable to toggle Cruise Control on / off 
                    MonitorCruiseKey.MonitorCruiseKeyDown();

                    // Detect key press and set variable to toggle Turbo on / off
                    if (charge > 20f)
                    MonitorModeKey.MonitorModeKeyDown();
                    else
                    {
                        if (!SeamothInfo.ModeGreenOn)
                        {
                            SeamothInfo.ModeGreenOn = true;
                            SeamothInfo.ModeChanged = true;
                        }
                    }

                    // Adjust gear for Green Mode
                    if (SeamothInfo.ModeGreenOn && Config.SeamothGearValue == 6f)
                    {
                        Config.SeamothGearValue = 5f;
                        PlayerPrefs.SetFloat("SeamothGearValueSlider", Config.SeamothGearValue);
                    }

                    // Detect key press and set variable to cycle through health display (mh, h, %)
                    MonitorHealthKey.MonitorHealthKeyDown();

                    // Detect key press and set variable to cycle through power display (mu, u, %)
                    MonitorPowerKey.MonitorPowerKeyDown();

                    if (!Subtitles.main.popup.isShowingMessage && Config.ShowKeyPromptToggleValue)
                        DisplayPrompts.DisplayElectronicPrompts(charge);

                } // end if (SeamothInfo.electronicModuleIn)


                // ###########
                // Electrical
                // ###########
                if (SeamothInfo.electricalModuleIn && SeamothInfo.seamothLinkModuleIn && !FPSInputModule.current.lockMovement)
                {
                    // Detect key press for the battery reload button
                    MonitorReloadKey.MonitorReloadKeyDown(__instance);

                    if (SeamothInfo.BatteryInSlot == 1)
                    {
                        // Detect key press and set variable to toggle lights Lo / Hi beam 
                        MonitorLightBeamKey.MonitorLightBeamKeyDown(__instance);

                        // Seaglide Map Controls light toggle fix
                        SeaglideMapControlFix.SeaglideMapControlLightFix(__instance);

                        // Show player key prompts
                        if (Player.main != null && !Player.main.GetPDA().isInUse && !FPSInputModule.current.lockMovement)
                        {
                            if (!Subtitles.main.popup.isShowingMessage && Config.ShowKeyPromptToggleValue)
                                DisplayPrompts.DisplayElectricalPrompts();
                            if (SeamothInfo.preventLightToggle == true)
                                SeamothInfo.preventLightToggle = false;
                        }
                    }
                    else
                    {
                        if (SeamothInfo.MainBatteryCount > 0)
                            DisplayPrompts.DisplayInsertBattery();
                        else
                            DisplayPrompts.DisplayNoBattery();
                    }

                    // Display battery prompts when R key was pressed which triggers FPSInputModule.current.lockMovement for 5 seconds
                    if (Player.main != null && FPSInputModule.current.lockMovement)
                        DisplayPrompts.DisplayBatteryPrompts();
                }

                if (!SeamothInfo.electricalModuleIn)
                {
                    // Make new default light mode to be a Low Beam mode
                    if (Vehicle_Update_Patch.HighBeamOn)
                        Vehicle_Update_Patch.HighBeamOn = false;
                }

                // Update batery count
                MonitorBatteryCount.MonitorSeamothBatteryCount(__instance);

                // Apply Low and High beam light toggle
                ToggleLightBeam.ToggleLoHighBeam(__instance);

            } // end if (__instance.GetPilotingMode())

        } // end public static void Postfix(SeaMoth __instance)

    }// end internal class SeaMoth_Update_Patch

}
