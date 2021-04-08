using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.InGame
{
    class SeaglideMapControlFix
    {
        public static void SeaglideMapControlLightFix(SeaMoth thisSeaMoth)
        {
            // Seaglide Map Controls light toggle fix
            if (Player.main.GetRightHandDown() && SeamothInfo.preventLightToggle && OtherModsInfo.SeaglideMapControls)
            {
                ToggleLights thisToggleLights = thisSeaMoth.GetComponentInChildren<ToggleLights>();
                float thisTLPMCh = Traverse.Create(thisSeaMoth).Field("timeLastPlayerModeChange").GetValue<float>();

                if (!Player.main.GetPDA().isInUse && Time.time > thisTLPMCh + 1f && SeamothInfo.timeLastLightToggle + 0.25f < Time.time)
                {
                    thisToggleLights.SetLightsActive(!thisToggleLights.lightsActive);
                    SeamothInfo.timeLastLightToggle = Time.time;
                    thisToggleLights.lightState++;
                    if (thisToggleLights.lightState == thisToggleLights.maxLightStates)
                    {
                        thisToggleLights.lightState = 0;
                    }
                }
            }
        }
    }
}
