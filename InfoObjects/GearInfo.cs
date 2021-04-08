using UnityEngine;
using UnityEngine.UI;

namespace SeamothEnhancementSystem.InfoObjects
{
    internal static class GearInfo
    {
        internal static string colorYellow = "<color=yellow>";
        internal static string colorRed = "<color=red>";
        internal static string colorEnd = "</color>";
        internal static Text cruiseDisplayText;
        internal static Text gearDisplayText;
        internal static Text speedDisplayText;
        internal static Text kmhDisplayText;
        internal static Text healthDisplayText;
        internal static Text powerDisplayText;
        internal static Text temperDisplayText;
        internal static GameObject gameObject;

        // Background
        internal static Vector3 background_Position = new Vector3(735f, -253f, 0f);
        internal static Vector2 background_Size = new Vector2(343f, 104f);

        // Electrical
        internal static Vector3 light_Position = new Vector3(605f, -265f, 0f);
        internal static Vector2 light_Size = new Vector2(40f, 40f);

        internal static Vector3 battery_Position = new Vector3(650f, -265f, 0f);
        internal static Vector2 battery_Size = new Vector2(40f, 40f);

        // Electronic
        internal static Vector3 mode_Position = new Vector3(700f, -265f, 0f);
        internal static Vector2 mode_Size = new Vector2(55f, 55f);

        internal static Vector3 cruise_Position = new Vector3(760f, -249f, 0f);
        internal static Vector2 cruise_Size = new Vector2(45f, 45f);

        internal static Vector3 cruise_txt_Position = new Vector3(770f, -220f, 0f);
        internal static Vector2 cruise_txt_Size = new Vector2(50f, 50f);

        // Mechanical
        internal static Vector3 cogs_Position = new Vector3(815f, -245f, 0f);
        internal static Vector2 cogs_Size = new Vector2(60f, 60f);

        internal static Vector3 gear_txt_Position = new Vector3(807f, -220f, 0f);
        internal static Vector2 gear_txt_Size = new Vector2(100f, 100f);

        internal static Vector3 kmh_txt_Position = new Vector3(855f, -265f, 0f);
        internal static Vector2 kmh_txt_Size = new Vector2(100f, 50f);

        internal static Vector3 speed_txt_Position = new Vector3(865f, -235f, 0f);
        internal static Vector2 speed_txt_Size = new Vector2(100f, 100f);

        // Health - add on description
        internal static Vector3 health_txt_Position = new Vector3(620f, -370f, 0f);
        internal static Vector2 health_txt_Size = new Vector2(150f, 50f);

        // Charge - add on description
        internal static Vector3 power_txt_Position = new Vector3(795f, -343f, 0f);
        internal static Vector2 power_txt_Size = new Vector2(150f, 50f);

        // Temperature - add on description
        internal static Vector3 temper_txt_Position = new Vector3(780f, -409f, 0f);
        internal static Vector2 temper_txt_Size = new Vector2(150f, 50f);


        internal static float? nextEnergyConsumption;
    }
}
