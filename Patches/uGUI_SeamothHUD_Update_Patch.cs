using System.Text;
using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.Patches
{
    [HarmonyPatch(typeof(uGUI_SeamothHUD))]  // Patch for the uGUI_SeamothHUD class.
    [HarmonyPatch("Update")]        // The uGUI_SeamothHUD class's Update method.
    internal class uGUI_SeamothHUD_Update_Patch
    {
        // Change vanilla uGUI_SeamothHUD operation.
        [HarmonyPostfix]      // Harmony postfix
        public static void Postfix(uGUI_SeamothHUD __instance)
        {
            Player main = Player.main;
            if (main != null)
            {
                Vehicle thisSeamoth = (main.GetVehicle() as SeaMoth);

                string colorStart;
                string colorStartDesc;
                string colorWhite = "<color=white>";
                string colorGrey = "<color=grey>";
                string colorYellow = "<color=yellow>";
                string colorRed = "<color=red>";
                string colorEnd = "</color>";
                string normalFont = "<size=" + Config.VehicleFontSizeSliderValue.ToString() + ">";
                string smallFont = "<size=" + (Config.VehicleFontSizeSliderValue / 1.5).ToString() + ">";

                if (SeamothInfo.seamothLinkModuleIn)
                    colorStartDesc = colorYellow;
                else
                    colorStartDesc = colorGrey;

                // ################################################
                // Health display     
                // ################################################

                if (thisSeamoth != null)
                {
                    LiveMixin thisLiveMixin = thisSeamoth.GetComponent<LiveMixin>();
                    float healthStatus = thisLiveMixin.GetHealthFraction();
                    StringBuilder stringBuilder = new StringBuilder();

                    // Run only if Electronic Enhancement Module is loaded
                    if (SeamothInfo.electronicModuleIn)
                    {


                        if (Config.MarchThroughHealthValue == 1f) // display maximum health (mh) allways in default colours
                        {
                            float thisMaxHealth = thisLiveMixin.data.maxHealth;
                            stringBuilder.Append(normalFont);
                            stringBuilder.Append(Mathf.Round(thisMaxHealth).ToString());
                            stringBuilder.Append("</size>");
                            stringBuilder.Append(smallFont);
                            stringBuilder.Append(colorStartDesc + "mh" + colorEnd);
                            stringBuilder.Append("</size>");
                            __instance.textHealth.text = stringBuilder.ToString();
                        }
                        else if (Config.MarchThroughHealthValue == 2f) // display health and change colours if damaged as per mod options settings
                        {
                            float thisHealth = thisLiveMixin.health;

                            // Set warning colours of health status as per mod options
                            if (healthStatus * 100f <= Mathf.Floor(Config.HealthLowerLimitSliderValue))
                                colorStart = colorRed;
                            else if (healthStatus * 100f > Mathf.Floor(Config.HealthLowerLimitSliderValue) && healthStatus * 100f <= Mathf.Floor(Config.HealthUpperLimitSliderValue))
                                colorStart = colorYellow;
                            else
                                colorStart = colorWhite;

                            stringBuilder.Append(normalFont);
                            stringBuilder.Append(colorStart + Mathf.Round(thisHealth).ToString() + colorEnd);
                            stringBuilder.Append("</size>");
                            stringBuilder.Append(smallFont);
                            stringBuilder.Append(colorStartDesc + "h" + colorEnd);
                            stringBuilder.Append("</size>");
                            __instance.textHealth.text = stringBuilder.ToString();
                        }
                        else // display health status as a % and change colours if damaged as per mod options settings
                        {
                            // Set warning colours of health status as per mod options
                            if (SeamothInfo.seamothLinkModuleIn)
                            {
                                if (healthStatus * 100f <= Mathf.Floor(Config.HealthLowerLimitSliderValue))
                                    colorStart = colorRed;
                                else if (healthStatus * 100f > Mathf.Floor(Config.HealthLowerLimitSliderValue) && healthStatus * 100f <= Mathf.Floor(Config.HealthUpperLimitSliderValue))
                                    colorStart = colorYellow;
                                else
                                    colorStart = colorWhite;
                            }
                            else
                                colorStart = colorWhite;

                            stringBuilder.Append(normalFont);
                            stringBuilder.Append(colorStart + Mathf.Round(healthStatus * 100f).ToString() + colorEnd);
                            stringBuilder.Append("</size>");
                            stringBuilder.Append(smallFont);
                            stringBuilder.Append(colorStartDesc + "%" + colorEnd);
                            stringBuilder.Append("</size>");

                            __instance.textHealth.text = stringBuilder.ToString();
                        }
                    } // end if (upgradeLoaded)
                    else // display as per vanilla game
                    {
                        stringBuilder.Append(Mathf.Round(healthStatus * 100f).ToString());
                        __instance.textHealth.text = stringBuilder.ToString();
                    }

                } // end if (thisSeamoth != null)


                // ################################################
                // Power display
                // ################################################

                if (thisSeamoth != null)
                {
                    EnergyMixin thisEnergyMixing = thisSeamoth.GetComponent<EnergyMixin>();
                    EnergyInterface thisEnergyInterface = thisEnergyMixing.GetComponent<EnergyInterface>();
                    thisEnergyInterface.GetValues(out float charge, out float capacity);
                    StringBuilder stringBuilder = new StringBuilder();

                    // Run only if Electronic Enhancement Module is loaded
                    if (SeamothInfo.electronicModuleIn)
                    {
                        if (Config.MarchThroughPowerValue == 1f) // display maximum cell charge capacity in units(mu) allways in default colours
                        {
                            stringBuilder.Append(normalFont);
                            if (capacity > 999f)
                                stringBuilder.Append(capacity.ToString("0E+0")); // Displays vehicle cell capacity in scientif number format
                            else
                                stringBuilder.Append(capacity.ToString()); // Displays vehicle cell capacity
                            stringBuilder.Append("</size>");
                            stringBuilder.Append(smallFont);
                            stringBuilder.Append(colorStartDesc + "mu" + colorEnd);
                            stringBuilder.Append("</size>");
                        }
                        else if (Config.MarchThroughPowerValue == 2f) // display cell charge capacity in units(u) and change colours as per mod options settings
                        {
                            // Set warning colours of charge status as per mod options
                            if (SeamothInfo.seamothLinkModuleIn)
                            {
                                if (charge / capacity * 100f <= Mathf.Floor(Config.PowerLowerLimitSliderValue) || SeamothInfo.BatteryInSlot == 0)
                                    colorStart = colorRed;
                                else if (charge / capacity * 100f > Mathf.Floor(Config.PowerLowerLimitSliderValue) && charge / capacity * 100f <= Mathf.Floor(Config.PowerUpperLimitSliderValue))
                                    colorStart = colorYellow;
                                else
                                    colorStart = colorWhite;
                            }
                            else
                                colorStart = colorWhite;

                            if (charge > 20f)
                            {
                                stringBuilder.Append(normalFont);
                                stringBuilder.Append(colorStart);
                                if (charge > 999f)
                                    stringBuilder.Append(Mathf.RoundToInt(charge).ToString("0E+0")); // Displays vehicle cell charge in scientif number format
                                else
                                    stringBuilder.Append(Mathf.RoundToInt(charge).ToString()); // Displays vehicle cell charge
                                stringBuilder.Append(colorEnd);
                                stringBuilder.Append("</size>");
                                stringBuilder.Append(smallFont);
                                stringBuilder.Append(colorStartDesc + "u" + colorEnd);
                                stringBuilder.Append("</size>");
                            }
                            else
                            {
                                // blinking HUD value
                                SeamothInfo.timer = SeamothInfo.timer + Time.deltaTime;
                                if (SeamothInfo.timer >= 0.5)
                                {
                                    stringBuilder.Append(normalFont);
                                    stringBuilder.Append(colorStart);
                                    if (charge > 999f)
                                        stringBuilder.Append(Mathf.RoundToInt(charge).ToString("0E+0")); // Displays vehicle cell charge in scientif number format
                                    else
                                        stringBuilder.Append(Mathf.RoundToInt(charge).ToString()); // Displays vehicle cell charge
                                    stringBuilder.Append(colorEnd);
                                    stringBuilder.Append("</size>");
                                    stringBuilder.Append(smallFont);
                                    stringBuilder.Append(colorStartDesc + "u" + colorEnd);
                                    stringBuilder.Append("</size>");
                                }
                                if (SeamothInfo.timer >= 3)
                                {
                                    SeamothInfo.timer = 0;
                                }
                            }

                        }
                        else // display cell charge in % and change colours as per mod options settings
                        {
                            // Set warning colours of charge status as per mod options
                            if (SeamothInfo.seamothLinkModuleIn)
                            {
                                if (charge / capacity * 100f <= Mathf.Floor(Config.PowerLowerLimitSliderValue))
                                    colorStart = colorRed;
                                else if (charge / capacity * 100f > Mathf.Floor(Config.PowerLowerLimitSliderValue) && charge / capacity * 100f <= Mathf.Floor(Config.PowerUpperLimitSliderValue))
                                    colorStart = colorYellow;
                                else
                                    colorStart = colorWhite;
                            }
                            else
                                colorStart = colorWhite;

                            if (charge > 20f)
                            {
                                stringBuilder.Append(normalFont + colorStart + Mathf.RoundToInt(charge / capacity * 100f).ToString() + colorEnd + "</size>"); // Displays battery charge
                                stringBuilder.Append(smallFont);
                                stringBuilder.Append(colorStartDesc + "%" + colorEnd);
                                stringBuilder.Append("</size>");
                            }
                            else
                            {
                                SeamothInfo.timer = SeamothInfo.timer + Time.deltaTime;
                                if (SeamothInfo.timer >= 0.5)
                                {
                                    stringBuilder.Append(normalFont + colorStart + Mathf.RoundToInt(charge / capacity * 100f).ToString() + colorEnd + "</size>");
                                    stringBuilder.Append(smallFont);
                                    stringBuilder.Append(colorStartDesc + "%" + colorEnd);
                                    stringBuilder.Append("</size>");
                                }
                                if (SeamothInfo.timer >= 3)
                                {
                                    SeamothInfo.timer = 0;
                                }
                            }

                        } // end else

                        __instance.textPower.text = stringBuilder.ToString();
                    } // end if (upgradeLoaded)  
                    else // display as per vanilla game
                    {
                        stringBuilder.Append(Mathf.RoundToInt(charge / capacity * 100f).ToString());
                        __instance.textPower.text = stringBuilder.ToString();
                    }

                } // end if (thisSeamoth != null)


                // ################################################
                // Temperature display
                // ################################################

                if (thisSeamoth != null)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    int waterTemp = Traverse.Create(__instance).Field("lastTemperature").GetValue<int>();

                    if (SeamothInfo.electronicModuleIn)
                    {
                        // Set warning colours of water temperature as per mod options
                        if (SeamothInfo.seamothLinkModuleIn)
                        {
                            if (waterTemp <= Mathf.Floor(Config.TempMothLowerLimitSliderValue))
                                colorStart = colorWhite;
                            else if (waterTemp > Mathf.Floor(Config.TempMothLowerLimitSliderValue) && waterTemp <= Mathf.Floor(Config.TempMothUpperLimitSliderValue))
                                colorStart = colorYellow;
                            else
                                colorStart = colorRed;
                        }
                        else
                            colorStart = colorWhite;

                        // Set font size and colour
                        stringBuilder.Append("<size=" + Config.VehicleFontSizeSliderValue.ToString() + ">");
                        stringBuilder.Append(colorStart + waterTemp.ToString() + colorEnd);
                        stringBuilder.Append("</size>");
                        __instance.textTemperature.text = stringBuilder.ToString();
                    } // end if (upgradeLoaded)
                    else // display as per vanilla game
                    {
                        stringBuilder.Append(waterTemp.ToString());
                        __instance.textTemperature.text = stringBuilder.ToString();
                    }

                } // end if (thisSeamoth != null)

            } // end if (main != null)

        } // end public static void Postfix(uGUI_SeamothHUD __instance)

    } // internal class uGUI_SeamothHUD_Update_Patch

}
