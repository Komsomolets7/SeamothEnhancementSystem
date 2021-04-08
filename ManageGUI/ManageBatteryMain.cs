using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.InGame;

namespace SeamothEnhancementSystem.ManageGUI
{
    class ManageBatteryMain
    {
        internal static void ManageBattery()
        {
            if (SeamothInfo.electricalModuleIn && SeamothInfo.seamothLinkModuleIn)
            {
                // display active battery slot
                if (ManageAllGUIElements.BatterySlotGrayUIGameObject != null)
                    ManageAllGUIElements.BatterySlotGrayUIGameObject.SetActive(false);

                if (ManageAllGUIElements.BatterySlotUIGameObject == null)
                    ManageAllGUIElements.BatterySlotUIGameObject = PrepareGUIObjects.PrepareGUIObject("BatterySlotUI", GearInfo.battery_Position);
                if (ManageAllGUIElements.BatterySlotUIGameObject != null)
                    ManageAllGUIElements.BatterySlotUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BatterySlotUIGameObject, "battery_slot_100x100", GearInfo.battery_Position, GearInfo.battery_Size);

                if (ManageAllGUIElements.BatterySlotUIGameObject != null)
                    ManageAllGUIElements.BatterySlotUIGameObject.SetActive(true);

                // display inserted battery
                if (SeamothInfo.BatteryInSlot == 1) // battery in the slot
                {
                    if (ManageAllGUIElements.BatteryUnitUIGameObject == null)
                        ManageAllGUIElements.BatteryUnitUIGameObject = PrepareGUIObjects.PrepareGUIObject("BatteryUnitUI", GearInfo.battery_Position);
                    if (ManageAllGUIElements.BatteryUnitUIGameObject != null)
                        ManageAllGUIElements.BatteryUnitUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BatteryUnitUIGameObject, "battery_unit_100x100", GearInfo.battery_Position, GearInfo.battery_Size);

                    if (ManageAllGUIElements.BatteryUnitUIGameObject != null)
                        ManageAllGUIElements.BatteryUnitUIGameObject.SetActive(true);
                }
                else // battery NOT in the slot
                {
                    if (ManageAllGUIElements.BatteryUnitUIGameObject != null)
                        ManageAllGUIElements.BatteryUnitUIGameObject.SetActive(false);
                }

                // display battery swap arrows
                // no batteries in inventory
                if (SeamothInfo.TotalBatteryCount == 0) // No batteries - hide all battery arrows
                {
                    if (ManageAllGUIElements.BatteryArrowsUIGameObject != null)
                        ManageAllGUIElements.BatteryArrowsUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.BatteryInUIGameObject != null)
                        ManageAllGUIElements.BatteryInUIGameObject.SetActive(false);
                    if (ManageAllGUIElements.BatteryOutUIGameObject != null)
                        ManageAllGUIElements.BatteryOutUIGameObject.SetActive(false);
                }
                else if (SeamothInfo.TotalBatteryCount == 1) // There is only one battery
                {
                    // Battery is in the slot, display only arrow OUT
                    if (SeamothInfo.BatteryInSlot == 1) // battery is in the slot but not in inventory, display arrow OUT
                        ManageBatteryHelpers.BatteryShowOut();
                    else // Battery is in inventory, display only arrow IN
                        ManageBatteryHelpers.BatteryShowIn();
                }
                else // There is more than one battery
                {
                    if (SeamothInfo.BatteryInSlot == 1) // Battery is in the slot, display DOUBLE arrow
                        ManageBatteryHelpers.BatteryShowArrows();
                    else // Battery is in storage, display only arrow IN
                        ManageBatteryHelpers.BatteryShowIn();
                }
            }
            else
            {
                // display inactive battery slot
                if (ManageAllGUIElements.BatterySlotUIGameObject != null)
                    ManageAllGUIElements.BatterySlotUIGameObject.SetActive(false);

                if (ManageAllGUIElements.BatterySlotGrayUIGameObject == null)
                    ManageAllGUIElements.BatterySlotGrayUIGameObject = PrepareGUIObjects.PrepareGUIObject("BatterySlotGrayUI", GearInfo.battery_Position);
                if (ManageAllGUIElements.BatterySlotGrayUIGameObject != null)
                    ManageAllGUIElements.BatterySlotGrayUIGameObject = PrepareGUISprite.PrepareGuiElement(ManageAllGUIElements.BatterySlotGrayUIGameObject, "battery_slot_gray_100x100", GearInfo.battery_Position, GearInfo.battery_Size);

                if (ManageAllGUIElements.BatterySlotGrayUIGameObject != null)
                    ManageAllGUIElements.BatterySlotGrayUIGameObject.SetActive(true);
            }
        }
    }
}
