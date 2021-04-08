using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageModeIcons
    {
        // Manage Seamoth engine Mode icons
        internal static void ManageMode() // Seamoth energy saving mode on
        {
            if (SeamothInfo.electronicModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                if (SeamothInfo.ModeGreenOn)
                {
                    if (ManageAllGUIElements.ModeGrayUIGameObject != null)
                        ManageAllGUIElements.ModeGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.ModeTurboUIGameObject != null)
                        ManageAllGUIElements.ModeTurboUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.ModeGreenUIGameObject == null)
                        ManageAllGUIElements.ModeGreenUIGameObject = PrepareGUIObjects.PrepareGUIObject("ModeGreenUI", GearInfo.mode_Position);
                    if (ManageAllGUIElements.ModeGreenUIGameObject != null)
                        ManageAllGUIElements.ModeGreenUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.ModeGreenUIGameObject, "mode_green_100x100", GearInfo.mode_Position, GearInfo.mode_Size);

                    if (ManageAllGUIElements.ModeGreenUIGameObject != null)
                        ManageAllGUIElements.ModeGreenUIGameObject.SetActive(true);
                }
                else // Seamoth turbo mode on
                {
                    if (ManageAllGUIElements.ModeGrayUIGameObject != null)
                        ManageAllGUIElements.ModeGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.ModeGreenUIGameObject != null)
                        ManageAllGUIElements.ModeGreenUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.ModeTurboUIGameObject == null)
                        ManageAllGUIElements.ModeTurboUIGameObject = PrepareGUIObjects.PrepareGUIObject("ModeTurboUI", GearInfo.mode_Position);
                    if (ManageAllGUIElements.ModeTurboUIGameObject != null)
                        ManageAllGUIElements.ModeTurboUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.ModeTurboUIGameObject, "mode_turbo_100x100", GearInfo.mode_Position, GearInfo.mode_Size);

                    if (ManageAllGUIElements.ModeTurboUIGameObject != null)
                        ManageAllGUIElements.ModeTurboUIGameObject.SetActive(true);
                }
            }
            else
            {
                if (ManageAllGUIElements.ModeGreenUIGameObject != null)
                    ManageAllGUIElements.ModeGreenUIGameObject.SetActive(false);
                if (ManageAllGUIElements.ModeTurboUIGameObject != null)
                    ManageAllGUIElements.ModeTurboUIGameObject.SetActive(false);

                if (ManageAllGUIElements.ModeGrayUIGameObject == null)
                    ManageAllGUIElements.ModeGrayUIGameObject = PrepareGUIObjects.PrepareGUIObject("ModeGrayUI", GearInfo.mode_Position);
                if (ManageAllGUIElements.ModeGrayUIGameObject != null)
                    ManageAllGUIElements.ModeGrayUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.ModeGrayUIGameObject, "mode_gray_100x100", GearInfo.mode_Position, GearInfo.mode_Size);

                if (ManageAllGUIElements.ModeGrayUIGameObject != null)
                    ManageAllGUIElements.ModeGrayUIGameObject.SetActive(true);
            }
        }
    }
}
