using SeamothEnhancementSystem.InfoObjects;
using UnityEngine;


namespace SeamothEnhancementSystem.InGame
{
    class MonitorBatteryCount
    {
        public static void MonitorSeamothBatteryCount(SeaMoth thisSeaMoth)
        {
            EnergyMixin energyMixin = thisSeaMoth.gameObject.GetComponent<EnergyMixin>();

            if (energyMixin != null)
            {
                GameObject thisGameObject = energyMixin.GetBattery();

                if (thisGameObject != null)
                    SeamothInfo.BatteryInSlot = 1;
                else
                    SeamothInfo.BatteryInSlot = 0;
            }

            SeamothInfo.MainBatteryCount = 0;

            foreach (InventoryItem item in Inventory.main.container)
            {
                if (energyMixin.Filter(item))
                    SeamothInfo.MainBatteryCount += 1;
            }

            SeamothInfo.TotalBatteryCount = SeamothInfo.BatteryInSlot + SeamothInfo.MainBatteryCount;
        }
    }
}
