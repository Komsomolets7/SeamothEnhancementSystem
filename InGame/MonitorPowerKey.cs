using UnityEngine;
using SMLHelper.V2.Utility;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorPowerKey
    {
        public static void MonitorPowerKeyDown()
        {
            // Detect key press and set variable to cycle through power display (mu, u, %)
            if (KeyCodeUtils.GetKeyDown(Config.PowerKeybindValue))
            {
                switch (Config.MarchThroughPowerValue)
                {
                    case 1:
                        Config.MarchThroughPowerValue = 2f;
                        PlayerPrefs.SetFloat("MarchThroughPowerValueSlider", 2f);
                        break;
                    case 2:
                        Config.MarchThroughPowerValue = 3f;
                        PlayerPrefs.SetFloat("MarchThroughPowerValueSlider", 3f);
                        break;
                    default:
                        Config.MarchThroughPowerValue = 1f;
                        PlayerPrefs.SetFloat("MarchThroughPowerValueSlider", 1f);
                        break;
                }
            }
        }
    }
}
