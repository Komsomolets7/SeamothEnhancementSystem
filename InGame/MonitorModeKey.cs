using SMLHelper.V2.Utility;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InfoObjects;
using UnityEngine;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorModeKey
    {
        public static void MonitorModeKeyDown()
        {
            // Detect key press and set variable to toggle Seamoth engine Turbo / Green mode

            // Toggle Turbo / Green mode
            if (KeyCodeUtils.GetKeyDown(Config.ModeKeybindValue))
            {
                if (SeamothInfo.ModeGreenOn)
                {
                    if (Config.SeamothGearValue == 6f)
                        Config.SeamothGearValue = 5f;

                        SeamothInfo.ModeGreenOn = false;
                        SeamothInfo.ModeChanged = true;
                        PlayerPrefs.SetFloat("SeamothGearValueSlider", Config.SeamothGearValue);
                }                    
                else
                {
                    SeamothInfo.ModeGreenOn = true;
                    SeamothInfo.ModeChanged = true;
                }                    
            }
        }
    }
}
