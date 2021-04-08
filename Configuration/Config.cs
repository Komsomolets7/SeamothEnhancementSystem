using UnityEngine;
using SMLHelper.V2.Utility;


namespace SeamothEnhancementSystem.Configuration
{
    // Mod config to show in Q-Mod options.
    public static class Config
    {
        public static bool ShowCellCapacityValue; // keep as a switch
        public static float MarchThroughHealthValue; // keep as a switch
        public static float MarchThroughPowerValue; // keep as a switch  
        public static float SeamothGearValue; // keep as a switch

        // User changeable values
        public static float VehicleFontSizeSliderValue;

        public static bool ShowKeyPromptToggleValue;
        public static bool ShowSpeedKmhToggleValue;

        public static KeyCode LightsLoHiKeybindValue;
        public static KeyCode CruiseKeybindValue;
        public static KeyCode ModeKeybindValue;

        public static KeyCode GearUpKeybindValue;
        public static KeyCode GearDownKeybindValue;        

        public static KeyCode HealthKeybindValue;
        public static KeyCode PowerKeybindValue;

        public static float HealthLowerLimitSliderValue;
        public static float HealthUpperLimitSliderValue;

        public static float PowerLowerLimitSliderValue;
        public static float PowerUpperLimitSliderValue;

        public static float TempMothLowerLimitSliderValue;
        public static float TempMothUpperLimitSliderValue;

        public static void Load()
        {
            ShowCellCapacityValue = PlayerPrefsExtra.GetBool("ShowCellCapacityToggle", false); // keep as a switch
            MarchThroughHealthValue = PlayerPrefs.GetFloat("MarchThroughHealthValueSlider", 3f);  // keep as a switch
            MarchThroughPowerValue = PlayerPrefs.GetFloat("MarchThroughPowerValueSlider", 3f);  // keep as a switch   
            SeamothGearValue = PlayerPrefs.GetFloat("SeamothGearValueSlider", 1f);  // keep as a switch

            // User changeable values
            VehicleFontSizeSliderValue = PlayerPrefs.GetFloat("VehicleFontSizeSlider", 30f);

            ShowKeyPromptToggleValue = PlayerPrefsExtra.GetBool("ShowKeyPromptToggle", true);
            ShowSpeedKmhToggleValue = PlayerPrefsExtra.GetBool("ShowSpeedKmhToggle", true);

            LightsLoHiKeybindValue = PlayerPrefsExtra.GetKeyCode("LightsLoHiKeybindPress", KeyCode.L);
            CruiseKeybindValue = PlayerPrefsExtra.GetKeyCode("CruiseKeybindPress", KeyCode.Y);
            ModeKeybindValue = PlayerPrefsExtra.GetKeyCode("ModeKeybindPress", KeyCode.T);

            GearUpKeybindValue = PlayerPrefsExtra.GetKeyCode("GearUpKeybindPress", KeyCode.F);
            GearDownKeybindValue = PlayerPrefsExtra.GetKeyCode("GearDownKeybindPress", KeyCode.V);            

            HealthKeybindValue = PlayerPrefsExtra.GetKeyCode("HealthKeybindPress", KeyCode.H);
            PowerKeybindValue = PlayerPrefsExtra.GetKeyCode("PowerKeybindPress", KeyCode.J);

            PowerLowerLimitSliderValue = PlayerPrefs.GetFloat("PowerLowerLimitSlider", 33f);
            PowerUpperLimitSliderValue = PlayerPrefs.GetFloat("PowerUpperLimitSlider", 66f);

            HealthLowerLimitSliderValue = PlayerPrefs.GetFloat("HealthLowerLimitSlider", 33f);
            HealthUpperLimitSliderValue = PlayerPrefs.GetFloat("HealthUpperLimitSlider", 66f);

            TempMothLowerLimitSliderValue = PlayerPrefs.GetFloat("TempMothLowerLimitSlider", 30f);
            TempMothUpperLimitSliderValue = PlayerPrefs.GetFloat("TempMothUpperLimitSlider", 45f);

        } // end public static void Load()

    } // end public static class Config

}
