using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageKmhTxt
    {
        // Manage km/h text
        internal static void ManageKmhText()
        {
            if (ManageAllGUIElements.KmhTextObject == null)
                ManageAllGUIElements.KmhTextObject = PrepareGUIObjects.PrepareGUIObject("KmhTextUI", GearInfo.kmh_txt_Position);

            // (Object, font size modifier, dual color / gray, is module in, what color if not gray, text type)
            if (ManageAllGUIElements.KmhTextObject != null)
                ManageAllGUIElements.KmhTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.KmhTextObject, 1.5f, true, SeamothInfo.mechanicalModuleIn, Color.yellow, GearInfo.kmh_txt_Position, GearInfo.kmh_txt_Size);

            GearInfo.kmhDisplayText = ManageAllGUIElements.KmhTextObject.GetComponent<Text>();

            string colorStart;
            string colorWhite = "<color=white>";
            string colorGrey = "<color=grey>";
            string colorEnd = "</color>";

            if (SeamothInfo.mechanicalModuleIn && SeamothInfo.seamothLinkModuleIn)
                colorStart = colorWhite;
            else
                colorStart = colorGrey;

            if (Config.ShowSpeedKmhToggleValue)
                GearInfo.kmhDisplayText.text = (colorStart + "km/h" + colorEnd);
            else
                GearInfo.kmhDisplayText.text = (colorStart + "nm/h" + colorEnd);

            if (ManageAllGUIElements.KmhTextObject != null)
                ManageAllGUIElements.KmhTextObject.SetActive(true);
        }
    }
}
