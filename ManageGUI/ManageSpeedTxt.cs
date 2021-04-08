using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageSpeedTxt
    {
        // Manage speedometer text
        internal static void ManageSpeedText()
        {            
            string colorGrey = "<color=grey>";
            string colorEnd = "</color>";

            if (ManageAllGUIElements.SpeedNowTextObject == null)
                ManageAllGUIElements.SpeedNowTextObject = PrepareGUIObjects.PrepareGUIObject("SpeedNowTextUI", GearInfo.speed_txt_Position);

            if (ManageAllGUIElements.SpeedNowTextObject != null)
                ManageAllGUIElements.SpeedNowTextObject = PrepareGUITxt.PrepareTxtElement(ManageAllGUIElements.SpeedNowTextObject, 0.65f, true, SeamothInfo.mechanicalModuleIn, Color.white, GearInfo.speed_txt_Position, GearInfo.speed_txt_Size);

            GearInfo.speedDisplayText = ManageAllGUIElements.SpeedNowTextObject.GetComponent<Text>();

            if (SeamothInfo.mechanicalModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                if (Config.ShowSpeedKmhToggleValue)
                    GearInfo.speedDisplayText.text = Mathf.RoundToInt(Player.main.GetVehicle().useRigidbody.velocity.magnitude).ToString();
                else
                    GearInfo.speedDisplayText.text = Mathf.RoundToInt(Player.main.GetVehicle().useRigidbody.velocity.magnitude / 1.852f).ToString();
            }
            else
            {
                GearInfo.speedDisplayText.text = colorGrey + "-" + colorEnd;
            }

            if (ManageAllGUIElements.SpeedNowTextObject != null)
                ManageAllGUIElements.SpeedNowTextObject.SetActive(true);
        }
    }
}
