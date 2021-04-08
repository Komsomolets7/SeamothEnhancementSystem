using UnityEngine;
using SMLHelper.V2.Utility;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorGearKeys
    {
        public static void MonitorGearKeysDown()
        {
            // Detect key press and set variable (march up) to set Seamoth gear
            if (KeyCodeUtils.GetKeyDown(Config.GearUpKeybindValue))
            {
                var gearVal = Config.SeamothGearValue + 1f;
                if (SeamothInfo.ModeGreenOn)
                    if (gearVal > 5f) return;
                if (!SeamothInfo.ModeGreenOn)
                    if (gearVal > 6f) return;
                Config.SeamothGearValue = gearVal;
                PlayerPrefs.SetFloat("SeamothGearValueSlider", gearVal);

            } // end if (KeyCodeUtils.GetKeyDown(KeyCode.LeftShift))

            // Detect key press and set variable (march down) to set Seamoth gear
            if (KeyCodeUtils.GetKeyDown(Config.GearDownKeybindValue))
            {
                var gearVal = Config.SeamothGearValue - 1f;
                if (gearVal < 1f) return;
                Config.SeamothGearValue = gearVal;
                PlayerPrefs.SetFloat("SeamothGearValueSlider", gearVal);

            } // end if (KeyCodeUtils.GetKeyDown(KeyCode.LeftControl))
        }
    }
}
