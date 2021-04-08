using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageGearsIcons
    {
        // Manage gears icons and text
        internal static void ManageGears()
        {
            if (SeamothInfo.mechanicalModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                if (Config.SeamothGearValue == 6f)
                {
                    if (ManageAllGUIElements.CogsGrayUIGameObject != null)
                        ManageAllGUIElements.CogsGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CogsBlueUIGameObject != null)
                        ManageAllGUIElements.CogsBlueUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CogsYellowUIGameObject != null)
                        ManageAllGUIElements.CogsYellowUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.CogsRedUIGameObject == null)
                        ManageAllGUIElements.CogsRedUIGameObject = PrepareGUIObjects.PrepareGUIObject("CogsRedUI", GearInfo.cogs_Position);
                    if (ManageAllGUIElements.CogsRedUIGameObject != null)
                        ManageAllGUIElements.CogsRedUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CogsRedUIGameObject, "cogs_red_100x100", GearInfo.cogs_Position, GearInfo.cogs_Size);

                    if (ManageAllGUIElements.CogsRedUIGameObject != null)
                        ManageAllGUIElements.CogsRedUIGameObject.SetActive(true);
                }

                if (Config.SeamothGearValue == 5f)
                {
                    if (ManageAllGUIElements.CogsGrayUIGameObject != null)
                        ManageAllGUIElements.CogsGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CogsBlueUIGameObject != null)
                        ManageAllGUIElements.CogsBlueUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CogsRedUIGameObject != null)
                        ManageAllGUIElements.CogsRedUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.CogsYellowUIGameObject == null)
                        ManageAllGUIElements.CogsYellowUIGameObject = PrepareGUIObjects.PrepareGUIObject("CogsYellowUI", GearInfo.cogs_Position);
                    if (ManageAllGUIElements.CogsYellowUIGameObject != null)
                        ManageAllGUIElements.CogsYellowUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CogsYellowUIGameObject, "cogs_yellow_100x100", GearInfo.cogs_Position, GearInfo.cogs_Size);

                    if (ManageAllGUIElements.CogsYellowUIGameObject != null)
                        ManageAllGUIElements.CogsYellowUIGameObject.SetActive(true);
                }

                if (Config.SeamothGearValue < 5f)
                {
                    if (ManageAllGUIElements.CogsGrayUIGameObject != null)
                        ManageAllGUIElements.CogsGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CogsYellowUIGameObject != null)
                        ManageAllGUIElements.CogsYellowUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CogsRedUIGameObject != null)
                        ManageAllGUIElements.CogsRedUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.CogsBlueUIGameObject == null)
                        ManageAllGUIElements.CogsBlueUIGameObject = PrepareGUIObjects.PrepareGUIObject("CogsBlueUI", GearInfo.cogs_Position);
                    if (ManageAllGUIElements.CogsBlueUIGameObject != null)
                        ManageAllGUIElements.CogsBlueUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CogsBlueUIGameObject, "cogs_blue_100x100", GearInfo.cogs_Position, GearInfo.cogs_Size);

                    if (ManageAllGUIElements.CogsBlueUIGameObject != null)
                        ManageAllGUIElements.CogsBlueUIGameObject.SetActive(true);
                }
            }
            else
            {
                if (ManageAllGUIElements.CogsBlueUIGameObject != null)
                    ManageAllGUIElements.CogsBlueUIGameObject.SetActive(false);
                if (ManageAllGUIElements.CogsYellowUIGameObject != null)
                    ManageAllGUIElements.CogsYellowUIGameObject.SetActive(false);
                if (ManageAllGUIElements.CogsRedUIGameObject != null)
                    ManageAllGUIElements.CogsRedUIGameObject.SetActive(false);

                if (ManageAllGUIElements.CogsGrayUIGameObject == null)
                    ManageAllGUIElements.CogsGrayUIGameObject = PrepareGUIObjects.PrepareGUIObject("CogsGrayUI", GearInfo.cogs_Position);
                if (ManageAllGUIElements.CogsGrayUIGameObject != null)
                    ManageAllGUIElements.CogsGrayUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CogsGrayUIGameObject, "cogs_gray_100x100", GearInfo.cogs_Position, GearInfo.cogs_Size);

                if (ManageAllGUIElements.CogsGrayUIGameObject != null)
                    ManageAllGUIElements.CogsGrayUIGameObject.SetActive(true);
            }
        }
    }
}
