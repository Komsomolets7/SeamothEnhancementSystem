using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageTemperTxt
    {
        // Manage add-on temperature text description
        internal static void ManageTemperText()
        {
            if (ManageAllGUIElements.TemperTextObject == null)
                ManageAllGUIElements.TemperTextObject = PrepareGUIObjects.PrepareGUIObject("TemperTextUI", GearInfo.temper_txt_Position);

            if (ManageAllGUIElements.TemperTextObject != null)
                ManageAllGUIElements.TemperTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.TemperTextObject, 2f, false, SeamothInfo.electronicModuleIn, Color.white, GearInfo.temper_txt_Position, GearInfo.temper_txt_Size);

            GearInfo.temperDisplayText = ManageAllGUIElements.TemperTextObject.GetComponent<Text>();

            if (SeamothInfo.electronicModuleIn)
            {
                string colorStartDesc;
                string colorWhite = "<color=white>";
                string colorGrey = "<color=grey>";
                string colorEnd = "</color>";

                if (SeamothInfo.seamothLinkModuleIn)
                    colorStartDesc = colorWhite;
                else
                    colorStartDesc = colorGrey;

                GearInfo.temperDisplayText.text = (colorStartDesc + "Water temp" + colorEnd);

                if (ManageAllGUIElements.TemperTextObject != null)
                    ManageAllGUIElements.TemperTextObject.SetActive(true);
            }
            else
            {
                if (ManageAllGUIElements.TemperTextObject != null)
                    ManageAllGUIElements.TemperTextObject.SetActive(false);
            }
        }
    }
}
