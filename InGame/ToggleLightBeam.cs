using UnityEngine;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.Patches;

namespace SeamothEnhancementSystem.InGame
{
    class ToggleLightBeam
    {
        // Set Low / High beam for lights
        public static void ToggleLoHighBeam(SeaMoth thisSeamoth)
        {
            Light[] componentsInChildren = thisSeamoth.lightsParent.GetComponentsInChildren<Light>();

            if (componentsInChildren != null)
            {
                if (Vehicle_Update_Patch.HighBeamOn)
                {
                    if (!Vehicle_Update_Patch.HighBeamIsSet)
                    {
                        foreach (Light light in componentsInChildren)
                        {
                            light.spotAngle = SeamothInfo.thisLightHighSpotAngle;
                            light.intensity = SeamothInfo.thisLightHighIntensity;
                            light.range = SeamothInfo.thisLightHighRange;
                            Vehicle_Update_Patch.HighBeamIsSet = true;
                            Vehicle_Update_Patch.LowBeamIsSet = false;
                        }
                    }
                }
                else
                {
                    if (!Vehicle_Update_Patch.LowBeamIsSet)
                    {
                        foreach (Light light in componentsInChildren)
                        {
                            light.spotAngle = SeamothInfo.thisLightLowSpotAngle;
                            light.intensity = SeamothInfo.thisLightLowIntensity;
                            light.range = SeamothInfo.thisLightLowRange;
                            Vehicle_Update_Patch.LowBeamIsSet = true;
                            Vehicle_Update_Patch.HighBeamIsSet = false;
                        }
                    }
                }
            }
        }        
    }
}
