using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageGearTxt
    {
        // Manage gears text
        internal static void ManageGearText()
        {
            string colorGrey = "<color=grey>";
            string colorEnd = "</color>";

            if (ManageAllGUIElements.GearTextObject == null)
                ManageAllGUIElements.GearTextObject = PrepareGUIObjects.PrepareGUIObject("GearTextUI", GearInfo.gear_txt_Position);

            // (Object, font size modifier, dual color / gray, is module in, what color if not gray, text type)
            if (ManageAllGUIElements.GearTextObject != null)
                ManageAllGUIElements.GearTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.GearTextObject, 1.5f, true, SeamothInfo.mechanicalModuleIn, Color.white, GearInfo.gear_txt_Position, GearInfo.gear_txt_Size);

            GearInfo.gearDisplayText = ManageAllGUIElements.GearTextObject.GetComponent<Text>();

            string gearTxt;
            if (SeamothInfo.mechanicalModuleIn && SeamothInfo.seamothLinkModuleIn)
                gearTxt = Config.SeamothGearValue.ToString();
            else
                gearTxt = colorGrey + Config.SeamothGearValue.ToString() + colorEnd;

            GearInfo.gearDisplayText.text = gearTxt; // + "(" + Player.main.GetVehicle().forwardForce.ToString() + ")"; // for checking forward force

            if (ManageAllGUIElements.GearTextObject != null)
                ManageAllGUIElements.GearTextObject.SetActive(true);
        }
    }
}
