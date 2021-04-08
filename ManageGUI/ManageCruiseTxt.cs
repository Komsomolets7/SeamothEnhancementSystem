using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageCruiseTxt
    {
        // Manage Cruise Control text
        internal static void ManageCruiseText()
        {
            if (SeamothInfo.CruiseControlOn && SeamothInfo.electronicModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                if (ManageAllGUIElements.CruiseSetTextObject == null)
                    ManageAllGUIElements.CruiseSetTextObject = PrepareGUIObjects.PrepareGUIObject("CruiseSetTextUI", GearInfo.cruise_txt_Position);

                // (Object, font size modifier, dual color / gray, is module in, what color if not gray, text type)
                if (ManageAllGUIElements.CruiseSetTextObject != null)
                    ManageAllGUIElements.CruiseSetTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.CruiseSetTextObject, 1.5f, true, SeamothInfo.electronicModuleIn, Color.white, GearInfo.cruise_txt_Position, GearInfo.cruise_txt_Size);

                GearInfo.cruiseDisplayText = ManageAllGUIElements.CruiseSetTextObject.GetComponent<Text>();

                // ("F1") displays 1 decimal place
                if (Config.SeamothGearValue == 5f)
                    GearInfo.cruiseDisplayText.text = GearInfo.colorYellow + Player.main.GetVehicle().forwardForce.ToString("F1") + GearInfo.colorEnd;
                else if (Config.SeamothGearValue == 6f)
                    GearInfo.cruiseDisplayText.text = GearInfo.colorRed + Player.main.GetVehicle().forwardForce.ToString("F1") + GearInfo.colorEnd;
                else
                    GearInfo.cruiseDisplayText.text = Player.main.GetVehicle().forwardForce.ToString("F1");

                if (ManageAllGUIElements.CruiseSetTextObject != null)
                    ManageAllGUIElements.CruiseSetTextObject.SetActive(true);
            }
            else
            {
                if (ManageAllGUIElements.CruiseSetTextObject != null)
                    ManageAllGUIElements.CruiseSetTextObject.SetActive(false);
            }
        }
    }
}
