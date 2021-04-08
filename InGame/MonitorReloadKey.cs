using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorReloadKey
    {
        // Detect (R) key press and display battery management interface

        public static void MonitorReloadKeyDown(SeaMoth thisSeaMoth)
        {
            // check if the reload button is pressed
            if (GameInput.GetButtonDown(GameInput.Button.Reload))
            {
                // check if the player is inside the seamoth to avoid NREs all over the place
                if (Player.main.GetVehicle() is SeaMoth)
                {
                    //  get the energy mixin component that's attached to the seamoth
                    EnergyMixin energyMixin = thisSeaMoth.gameObject.GetComponent<EnergyMixin>();
                    if (energyMixin != null)
                        energyMixin.InitiateReload();
                }
                SeamothInfo.preventLightToggle = true;
            }
        }
    }
}
