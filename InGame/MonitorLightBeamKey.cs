using SMLHelper.V2.Utility;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.Patches;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorLightBeamKey
    {
        public static void MonitorLightBeamKeyDown(SeaMoth thisSeaMoth)
        {
            // Detect key press and set variable to toggle lights Lo / Hi beam 
            if (KeyCodeUtils.GetKeyDown(Config.LightsLoHiKeybindValue))
            {                
                ToggleLights thisToggleLights = thisSeaMoth.GetComponentInChildren<ToggleLights>();

                if (Vehicle_Update_Patch.HighBeamOn)
                {
                    Utils.PlayEnvSound(thisToggleLights.lightsOffSound, thisToggleLights.lightsOffSound.gameObject.transform.position, 20f);
                    Vehicle_Update_Patch.HighBeamOn = false;
                }
                else
                {
                    Utils.PlayEnvSound(thisToggleLights.lightsOnSound, thisToggleLights.lightsOnSound.gameObject.transform.position, 20f);
                    Vehicle_Update_Patch.HighBeamOn = true;
                }
            }
        }
    }
}
