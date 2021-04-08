using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageBatteryHelpers
    {
        // Manage Battery Icons        
        internal static void BatteryShowIn()
        {
            if (ManageAllGUIElements.BatterySlotGrayUIGameObject != null)
                ManageAllGUIElements.BatterySlotGrayUIGameObject.SetActive(false);
            if (ManageAllGUIElements.BatteryOutUIGameObject != null)
                ManageAllGUIElements.BatteryOutUIGameObject.SetActive(false);
            if (ManageAllGUIElements.BatteryArrowsUIGameObject != null)
                ManageAllGUIElements.BatteryArrowsUIGameObject.SetActive(false);

            if (ManageAllGUIElements.BatteryInUIGameObject == null)
                ManageAllGUIElements.BatteryInUIGameObject = PrepareGUIObjects.PrepareGUIObject("BatteryInUI", GearInfo.battery_Position);
            if (ManageAllGUIElements.BatteryInUIGameObject != null)
                ManageAllGUIElements.BatteryInUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BatteryInUIGameObject, "battery_in_100x100", GearInfo.battery_Position, GearInfo.battery_Size);

            if (ManageAllGUIElements.BatteryInUIGameObject != null)
                ManageAllGUIElements.BatteryInUIGameObject.SetActive(true);
        }

        internal static void BatteryShowOut()
        {
            if (ManageAllGUIElements.BatterySlotGrayUIGameObject != null)
                ManageAllGUIElements.BatterySlotGrayUIGameObject.SetActive(false);
            if (ManageAllGUIElements.BatteryInUIGameObject != null)
                ManageAllGUIElements.BatteryInUIGameObject.SetActive(false);
            if (ManageAllGUIElements.BatteryArrowsUIGameObject != null)
                ManageAllGUIElements.BatteryArrowsUIGameObject.SetActive(false);

            if (ManageAllGUIElements.BatteryOutUIGameObject == null)
                ManageAllGUIElements.BatteryOutUIGameObject = PrepareGUIObjects.PrepareGUIObject("BatteryOutUI", GearInfo.battery_Position);
            if (ManageAllGUIElements.BatteryOutUIGameObject != null)
                ManageAllGUIElements.BatteryOutUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BatteryOutUIGameObject, "battery_out_100x100", GearInfo.battery_Position, GearInfo.battery_Size);

            if (ManageAllGUIElements.BatteryOutUIGameObject != null)
                ManageAllGUIElements.BatteryOutUIGameObject.SetActive(true);
        }

        internal static void BatteryShowArrows()
        {
            if (ManageAllGUIElements.BatterySlotGrayUIGameObject != null)
                ManageAllGUIElements.BatterySlotGrayUIGameObject.SetActive(false);
            if (ManageAllGUIElements.BatteryInUIGameObject != null)
                ManageAllGUIElements.BatteryInUIGameObject.SetActive(false);
            if (ManageAllGUIElements.BatteryOutUIGameObject != null)
                ManageAllGUIElements.BatteryOutUIGameObject.SetActive(false);

            if (ManageAllGUIElements.BatteryArrowsUIGameObject == null)
                ManageAllGUIElements.BatteryArrowsUIGameObject = PrepareGUIObjects.PrepareGUIObject("BatteryArrowsUI", GearInfo.battery_Position);
            if (ManageAllGUIElements.BatteryArrowsUIGameObject != null)
                ManageAllGUIElements.BatteryArrowsUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BatteryArrowsUIGameObject, "battery_arrows_100x100", GearInfo.battery_Position, GearInfo.battery_Size);

            if (ManageAllGUIElements.BatteryArrowsUIGameObject != null)
                ManageAllGUIElements.BatteryArrowsUIGameObject.SetActive(true);
        }
    }
}
