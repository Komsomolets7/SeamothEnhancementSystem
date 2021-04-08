using UnityEngine;
using SMLHelper.V2.Utility;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.InGame
{
    class MonitorHealthKey
    {
        public static void MonitorHealthKeyDown()
        {
            // Detect key press and set variable to cycle through health display (mh, h, %)
            if (KeyCodeUtils.GetKeyDown(Config.HealthKeybindValue))
            {
                switch (Config.MarchThroughHealthValue)
                {
                    case 1:
                        Config.MarchThroughHealthValue = 2f;
                        PlayerPrefs.SetFloat("MarchThroughHealthValueSlider", 2f);
                        break;
                    case 2:
                        Config.MarchThroughHealthValue = 3f;
                        PlayerPrefs.SetFloat("MarchThroughHealthValueSlider", 3f);
                        break;
                    default:
                        Config.MarchThroughHealthValue = 1f;
                        PlayerPrefs.SetFloat("MarchThroughHealthValueSlider", 1f);
                        break;
                }
            }
        }
    }
}
