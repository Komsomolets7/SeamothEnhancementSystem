using SeamothEnhancementSystem.Patches;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageLightIcons
    {
        // Manage Lights icons
        internal static void ManageLights()
        {
            if (SeamothInfo.electricalModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                Vehicle thisSeamoth = (Player.main.GetVehicle() as SeaMoth);
                ToggleLights thisToggleLights = thisSeamoth.GetComponentInChildren<ToggleLights>();
                bool LightsAreOn = false;
                if (thisToggleLights != null)
                    LightsAreOn = thisToggleLights.GetLightsActive();

                if (!LightsAreOn) // lights are off
                {
                    if (!Vehicle_Update_Patch.HighBeamOn) // low beam on
                    {
                        if (ManageAllGUIElements.LightGrayUIGameObject != null)
                            ManageAllGUIElements.LightGrayUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightLowOnUIGameObject != null)
                            ManageAllGUIElements.LightLowOnUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightHighOffUIGameObject != null)
                            ManageAllGUIElements.LightHighOffUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightHighOnUIGameObject != null)
                            ManageAllGUIElements.LightHighOnUIGameObject.SetActive(false);

                        if (ManageAllGUIElements.LightLowOffUIGameObject == null)
                            ManageAllGUIElements.LightLowOffUIGameObject = PrepareGUIObjects.PrepareGUIObject("LightLowOffUI", GearInfo.light_Position);
                        if (ManageAllGUIElements.LightLowOffUIGameObject != null)
                            ManageAllGUIElements.LightLowOffUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.LightLowOffUIGameObject, "light_low_off_100x100", GearInfo.light_Position, GearInfo.light_Size);

                        if (ManageAllGUIElements.LightLowOffUIGameObject != null)
                            ManageAllGUIElements.LightLowOffUIGameObject.SetActive(true);
                    }
                    else // high beam on
                    {
                        if (ManageAllGUIElements.LightGrayUIGameObject != null)
                            ManageAllGUIElements.LightGrayUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightHighOnUIGameObject != null)
                            ManageAllGUIElements.LightHighOnUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightLowOffUIGameObject != null)
                            ManageAllGUIElements.LightLowOffUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightLowOnUIGameObject != null)
                            ManageAllGUIElements.LightLowOnUIGameObject.SetActive(false);

                        if (ManageAllGUIElements.LightHighOffUIGameObject == null)
                            ManageAllGUIElements.LightHighOffUIGameObject = PrepareGUIObjects.PrepareGUIObject("LightHighOffUI", GearInfo.light_Position);
                        if (ManageAllGUIElements.LightHighOffUIGameObject != null)
                            ManageAllGUIElements.LightHighOffUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.LightHighOffUIGameObject, "light_high_off_100x100", GearInfo.light_Position, GearInfo.light_Size);

                        if (ManageAllGUIElements.LightHighOffUIGameObject != null)
                            ManageAllGUIElements.LightHighOffUIGameObject.SetActive(true);
                    }
                }
                else // lights are on
                {
                    if (!Vehicle_Update_Patch.HighBeamOn) // low beam on
                    {
                        if (ManageAllGUIElements.LightGrayUIGameObject != null)
                            ManageAllGUIElements.LightGrayUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightHighOffUIGameObject != null)
                            ManageAllGUIElements.LightHighOffUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightHighOnUIGameObject != null)
                            ManageAllGUIElements.LightHighOnUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightLowOffUIGameObject != null)
                            ManageAllGUIElements.LightLowOffUIGameObject.SetActive(false);

                        if (ManageAllGUIElements.LightLowOnUIGameObject == null)
                            ManageAllGUIElements.LightLowOnUIGameObject = PrepareGUIObjects.PrepareGUIObject("LightLowOnUI", GearInfo.light_Position);
                        if (ManageAllGUIElements.LightLowOnUIGameObject != null)
                            ManageAllGUIElements.LightLowOnUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.LightLowOnUIGameObject, "light_low_on_100x100", GearInfo.light_Position, GearInfo.light_Size);

                        if (ManageAllGUIElements.LightLowOnUIGameObject != null)
                            ManageAllGUIElements.LightLowOnUIGameObject.SetActive(true);
                    }
                    else // high beam on
                    {
                        if (ManageAllGUIElements.LightGrayUIGameObject != null)
                            ManageAllGUIElements.LightGrayUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightLowOffUIGameObject != null)
                            ManageAllGUIElements.LightLowOffUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightLowOnUIGameObject != null)
                            ManageAllGUIElements.LightLowOnUIGameObject.SetActive(false);
                        if (ManageAllGUIElements.LightHighOffUIGameObject != null)
                            ManageAllGUIElements.LightHighOffUIGameObject.SetActive(false);

                        if (ManageAllGUIElements.LightHighOnUIGameObject == null)
                            ManageAllGUIElements.LightHighOnUIGameObject = PrepareGUIObjects.PrepareGUIObject("LightHighOnUI", GearInfo.light_Position);
                        if (ManageAllGUIElements.LightHighOnUIGameObject != null)
                            ManageAllGUIElements.LightHighOnUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.LightHighOnUIGameObject, "light_high_on_100x100", GearInfo.light_Position, GearInfo.light_Size);

                        if (ManageAllGUIElements.LightHighOnUIGameObject != null)
                            ManageAllGUIElements.LightHighOnUIGameObject.SetActive(true);
                    }
                }
            }
            else
            {
                if (ManageAllGUIElements.LightLowOnUIGameObject != null)
                    ManageAllGUIElements.LightLowOnUIGameObject.SetActive(false);
                if (ManageAllGUIElements.LightLowOffUIGameObject != null)
                    ManageAllGUIElements.LightLowOffUIGameObject.SetActive(false);
                if (ManageAllGUIElements.LightHighOffUIGameObject != null)
                    ManageAllGUIElements.LightHighOffUIGameObject.SetActive(false);
                if (ManageAllGUIElements.LightHighOnUIGameObject != null)
                    ManageAllGUIElements.LightHighOnUIGameObject.SetActive(false);

                if (ManageAllGUIElements.LightGrayUIGameObject == null)
                    ManageAllGUIElements.LightGrayUIGameObject = PrepareGUIObjects.PrepareGUIObject("LightGrayUI", GearInfo.light_Position);
                if (ManageAllGUIElements.LightGrayUIGameObject != null)
                    ManageAllGUIElements.LightGrayUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.LightGrayUIGameObject, "light_gray_100x100", GearInfo.light_Position, GearInfo.light_Size);

                if (ManageAllGUIElements.LightGrayUIGameObject != null)
                    ManageAllGUIElements.LightGrayUIGameObject.SetActive(true);
            }
        }
    }
}
