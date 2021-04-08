using UnityEngine;
using SMLHelper.V2.Utility;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.InfoObjects;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorCruiseKey
    {
        public static void MonitorCruiseKeyDown()
        {
            // Detect key press and set variable to toggle Cruise Control on / off
            // Turn cruise off if forward or reverse buttonis pressed
            if (KeyCodeUtils.GetKeyDown(KeyCode.W) || KeyCodeUtils.GetKeyDown(KeyCode.S))
                SeamothInfo.CruiseControlOn = false;

            // Toggle cruise control
            if (KeyCodeUtils.GetKeyDown(Config.CruiseKeybindValue))
            {
                if (SeamothInfo.CruiseControlOn)
                    SeamothInfo.CruiseControlOn = false;
                else
                    SeamothInfo.CruiseControlOn = true;
            }
        }
    }
}
