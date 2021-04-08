using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    internal static class ManageAllGUIElements
    {
        public static GameObject gameObject = GameObject.Find("HUD");        

        public static GameObject BackgroundUIGameObject = GameObject.Find("BackgroundUI");

        public static GameObject LightGrayUIGameObject = GameObject.Find("LightGrayUI");
        public static GameObject LightLowOffUIGameObject = GameObject.Find("LightLowOffUI");
        public static GameObject LightLowOnUIGameObject = GameObject.Find("LightLowOnUI");
        public static GameObject LightHighOffUIGameObject = GameObject.Find("LightHighOffUI");
        public static GameObject LightHighOnUIGameObject = GameObject.Find("LightHighOnUI");

        public static GameObject BatterySlotGrayUIGameObject = GameObject.Find("BatterySlotGrayUI");
        public static GameObject BatterySlotUIGameObject = GameObject.Find("BatterySlotUI");
        public static GameObject BatteryUnitUIGameObject = GameObject.Find("BatteryUnitUI");
        public static GameObject BatteryArrowsUIGameObject = GameObject.Find("BatteryArrowsUI");
        public static GameObject BatteryInUIGameObject = GameObject.Find("BatteryInUI");
        public static GameObject BatteryOutUIGameObject = GameObject.Find("BatteryOutUI");

        public static GameObject ModeGrayUIGameObject = GameObject.Find("ModeGrayUI");
        public static GameObject ModeGreenUIGameObject = GameObject.Find("ModeGreenUI");
        public static GameObject ModeTurboUIGameObject = GameObject.Find("ModeTurboUI");

        public static GameObject CruiseGrayUIGameObject = GameObject.Find("CruiseGrayUI");
        public static GameObject CruiseOffUIGameObject = GameObject.Find("CruiseOffUI");
        public static GameObject CruiseOnUIGameObject = GameObject.Find("CruiseOnUI");

        public static GameObject CogsGrayUIGameObject = GameObject.Find("CogsGrayUI");
        public static GameObject CogsBlueUIGameObject = GameObject.Find("CogsBlueUI");
        public static GameObject CogsYellowUIGameObject = GameObject.Find("CogsYellowUI");
        public static GameObject CogsRedUIGameObject = GameObject.Find("CogsRedUI");

        public static GameObject GearTextObject = GameObject.Find("GearTextUI");
        public static GameObject CruiseSetTextObject = GameObject.Find("CruiseSetTextUI");
        public static GameObject SpeedNowTextObject = GameObject.Find("SpeedNowTextUI");
        public static GameObject KmhTextObject = GameObject.Find("KmhTextUI");

        public static GameObject HealthTextObject = GameObject.Find("HealthTextUI");
        public static GameObject PowerTextObject = GameObject.Find("PowerTextUI");
        public static GameObject TemperTextObject = GameObject.Find("TemperTextUI");

        public static string colorWhite = "<color=white>";
        public static string colorYellow = "<color=yellow>";
        public static string colorRed = "<color=red>";
        public static string colorEnd = "</color>";


        // Helper methods
        internal static void ManageAllGuiElements()
        {
            ManageBackgroundImg.ManageBackground();
            ManageLightIcons.ManageLights();
            ManageBatteryMain.ManageBattery();
            ManageModeIcons.ManageMode();
            ManageCruiseIcons.ManageCruiseControl();
            ManageCruiseTxt.ManageCruiseText();
            ManageGearsIcons.ManageGears();
            ManageGearTxt.ManageGearText();
            ManageSpeedTxt.ManageSpeedText();
            ManageKmhTxt.ManageKmhText();
            ManageHealthTxt.ManageHealthText();
            ManagePowerTxt.ManagePowerText();
            ManageTemperTxt.ManageTemperText();
        }

        internal static void TurnUIOff()
        {
            if (BackgroundUIGameObject != null)
                BackgroundUIGameObject.SetActive(false);


            if (LightGrayUIGameObject != null)
                LightGrayUIGameObject.SetActive(false);
            if (LightLowOffUIGameObject != null)
                LightLowOffUIGameObject.SetActive(false);
            if (LightLowOnUIGameObject != null)
                LightLowOnUIGameObject.SetActive(false);
            if (LightHighOffUIGameObject != null)
                LightHighOffUIGameObject.SetActive(false);
            if (LightHighOnUIGameObject != null)
                LightHighOnUIGameObject.SetActive(false);


            if (BatterySlotGrayUIGameObject != null)
                BatterySlotGrayUIGameObject.SetActive(false);
            if (BatterySlotUIGameObject != null)
                BatterySlotUIGameObject.SetActive(false);
            if (BatteryUnitUIGameObject != null)
                BatteryUnitUIGameObject.SetActive(false);
            if (BatteryArrowsUIGameObject != null)
                BatteryArrowsUIGameObject.SetActive(false);
            if (BatteryInUIGameObject != null)
                BatteryInUIGameObject.SetActive(false);
            if (BatteryOutUIGameObject != null)
                BatteryOutUIGameObject.SetActive(false);


            if (ModeGrayUIGameObject != null)
                ModeGrayUIGameObject.SetActive(false);
            if (ModeGreenUIGameObject != null)
                ModeGreenUIGameObject.SetActive(false);
            if (ModeTurboUIGameObject != null)
                ModeTurboUIGameObject.SetActive(false);


            if (CruiseGrayUIGameObject != null)
                CruiseGrayUIGameObject.SetActive(false);
            if (CruiseOffUIGameObject != null)
                CruiseOffUIGameObject.SetActive(false);
            if (CruiseOnUIGameObject != null)
                CruiseOnUIGameObject.SetActive(false);

            if (CruiseSetTextObject != null)
                CruiseSetTextObject.SetActive(false);


            if (CogsGrayUIGameObject != null)
                CogsGrayUIGameObject.SetActive(false);
            if (CogsBlueUIGameObject != null)
                CogsBlueUIGameObject.SetActive(false);
            if (CogsYellowUIGameObject != null)
                CogsYellowUIGameObject.SetActive(false);
            if (CogsRedUIGameObject != null)
                CogsRedUIGameObject.SetActive(false);

            if (GearTextObject != null)
                GearTextObject.SetActive(false);


            if (SpeedNowTextObject != null)
                SpeedNowTextObject.SetActive(false);

            if (KmhTextObject != null)
                KmhTextObject.SetActive(false);

            if (HealthTextObject != null)
                HealthTextObject.SetActive(false);
            if (PowerTextObject != null)
                PowerTextObject.SetActive(false);
            if (TemperTextObject != null)
                TemperTextObject.SetActive(false);
        }
    }
}
