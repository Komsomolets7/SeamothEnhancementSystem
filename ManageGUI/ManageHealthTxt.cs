using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageHealthTxt
    {
        // Manage add-on health text description
        internal static void ManageHealthText()
        {
            if (ManageAllGUIElements.HealthTextObject == null)
                ManageAllGUIElements.HealthTextObject = PrepareGUIObjects.PrepareGUIObject("HealthTextUI", GearInfo.health_txt_Position);

            // (Object, font size modifier, dual color / gray, is module in, what color if not gray, text type)
            if (ManageAllGUIElements.HealthTextObject != null)
                ManageAllGUIElements.HealthTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.HealthTextObject, 2f, false, SeamothInfo.electronicModuleIn, Color.white, GearInfo.health_txt_Position, GearInfo.health_txt_Size);

            GearInfo.healthDisplayText = ManageAllGUIElements.HealthTextObject.GetComponent<Text>();

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

                if (Config.MarchThroughHealthValue == 1f)
                    GearInfo.healthDisplayText.text = (colorStartDesc + "Health max units" + colorEnd);
                else if (Config.MarchThroughHealthValue == 2f)
                    GearInfo.healthDisplayText.text = (colorStartDesc + "Health units" + colorEnd);
                else
                    GearInfo.healthDisplayText.text = (colorStartDesc + "Health %" + colorEnd);

                if (ManageAllGUIElements.HealthTextObject != null)
                    ManageAllGUIElements.HealthTextObject.SetActive(true);
            }
            else
            {
                if (ManageAllGUIElements.HealthTextObject != null)
                    ManageAllGUIElements.HealthTextObject.SetActive(false);
            }
        }
    }
}
