using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageBackgroundImg
    {
        // Manage Background icon        
        internal static void ManageBackground()
        {
            if (SeamothInfo.electricalModuleIn || SeamothInfo.electronicModuleIn || SeamothInfo.mechanicalModuleIn)
            {
                if (ManageAllGUIElements.BackgroundUIGameObject == null)
                    ManageAllGUIElements.BackgroundUIGameObject = PrepareGUIObjects.PrepareGUIObject("BackgroundUI", GearInfo.gear_txt_Position);

                if (ManageAllGUIElements.BackgroundUIGameObject != null)
                    ManageAllGUIElements.BackgroundUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BackgroundUIGameObject, "background_343x104", GearInfo.background_Position, GearInfo.background_Size);

                if (ManageAllGUIElements.BackgroundUIGameObject != null)
                    ManageAllGUIElements.BackgroundUIGameObject.SetActive(true);
            }
        }
    }
}
