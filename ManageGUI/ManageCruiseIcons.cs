using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageCruiseIcons
    {
        // Manage Cruise Control icons
        internal static void ManageCruiseControl()
        {
            if (SeamothInfo.electronicModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                if (SeamothInfo.CruiseControlOn)
                {
                    if (ManageAllGUIElements.CruiseGrayUIGameObject != null)
                        ManageAllGUIElements.CruiseGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CruiseOffUIGameObject != null)
                        ManageAllGUIElements.CruiseOffUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.CruiseOnUIGameObject == null)
                        ManageAllGUIElements.CruiseOnUIGameObject = PrepareGUIObjects.PrepareGUIObject("CruiseOnUI", GearInfo.cruise_Position);
                    if (ManageAllGUIElements.CruiseOnUIGameObject != null)
                        ManageAllGUIElements.CruiseOnUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CruiseOnUIGameObject, "cruise_control_on_100x100", GearInfo.cruise_Position, GearInfo.cruise_Size);

                    if (ManageAllGUIElements.CruiseOnUIGameObject != null)
                        ManageAllGUIElements.CruiseOnUIGameObject.SetActive(true);
                }
                else
                {
                    if (ManageAllGUIElements.CruiseGrayUIGameObject != null)
                        ManageAllGUIElements.CruiseGrayUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.CruiseOnUIGameObject != null)
                        ManageAllGUIElements.CruiseOnUIGameObject.SetActive(false);

                    if (ManageAllGUIElements.CruiseOffUIGameObject == null)
                        ManageAllGUIElements.CruiseOffUIGameObject = PrepareGUIObjects.PrepareGUIObject("CruiseOffUI", GearInfo.cruise_Position);
                    if (ManageAllGUIElements.CruiseOffUIGameObject != null)
                        ManageAllGUIElements.CruiseOffUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CruiseOffUIGameObject, "cruise_control_off_100x100", GearInfo.cruise_Position, GearInfo.cruise_Size);

                    if (ManageAllGUIElements.CruiseOffUIGameObject != null)
                        ManageAllGUIElements.CruiseOffUIGameObject.SetActive(true);
                }
            }
            else
            {
                if (ManageAllGUIElements.CruiseOffUIGameObject != null)
                    ManageAllGUIElements.CruiseOffUIGameObject.SetActive(false);
                if (ManageAllGUIElements.CruiseOnUIGameObject != null)
                    ManageAllGUIElements.CruiseOnUIGameObject.SetActive(false);

                if (ManageAllGUIElements.CruiseGrayUIGameObject == null)
                    ManageAllGUIElements.CruiseGrayUIGameObject = PrepareGUIObjects.PrepareGUIObject("CruiseGrayUI", GearInfo.cruise_Position);
                if (ManageAllGUIElements.CruiseGrayUIGameObject != null)
                    ManageAllGUIElements.CruiseGrayUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.CruiseGrayUIGameObject, "cruise_control_gray_100x100", GearInfo.cruise_Position, GearInfo.cruise_Size);

                if (ManageAllGUIElements.CruiseGrayUIGameObject != null)
                    ManageAllGUIElements.CruiseGrayUIGameObject.SetActive(true);
            }
        }
    }
}
