using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManagePowerTxt
    {
        // Manage add-on power text description
        internal static void ManagePowerText()
        {
            if (ManageAllGUIElements.PowerTextObject == null)
                ManageAllGUIElements.PowerTextObject = PrepareGUIObjects.PrepareGUIObject("PowerTextUI", GearInfo.power_txt_Position);

            // (Object, font size modifier, dual color / gray, is module in, what color if not gray, text type)
            if (ManageAllGUIElements.PowerTextObject != null)
                ManageAllGUIElements.PowerTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.PowerTextObject, 2f, false, SeamothInfo.electronicModuleIn, Color.white, GearInfo.power_txt_Position, GearInfo.power_txt_Size);

            GearInfo.powerDisplayText = ManageAllGUIElements.PowerTextObject.GetComponent<Text>();

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

                if (Config.MarchThroughPowerValue == 1f)
                    GearInfo.powerDisplayText.text = (colorStartDesc + "Power max units" + colorEnd);
                else if (Config.MarchThroughPowerValue == 2f)
                    GearInfo.powerDisplayText.text = (colorStartDesc + "Power units" + colorEnd);
                else
                    GearInfo.powerDisplayText.text = (colorStartDesc + "Power %" + colorEnd);

                if (ManageAllGUIElements.PowerTextObject != null)
                    ManageAllGUIElements.PowerTextObject.SetActive(true);
            }
            else
            {
                if (ManageAllGUIElements.PowerTextObject != null)
                    ManageAllGUIElements.PowerTextObject.SetActive(false);
            }
        }
    }
}
