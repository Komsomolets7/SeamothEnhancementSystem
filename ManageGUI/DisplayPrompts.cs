using System.Text;
using Harmony;
using UnityEngine;
using SeamothEnhancementSystem.Configuration;
using SeamothEnhancementSystem.Patches;
using SeamothEnhancementSystem.InfoObjects;


namespace SeamothEnhancementSystem.ManageGUI
{
    class DisplayPrompts
    {
        public static string colorGrey = "<color=grey>";
        public static string colorYellow = "<color=yellow>";
        public static string colorRed = "<color=red>";
        public static string colorEnd = "</color>";

        // Run only if Seamoth Link is missing
        public static void DisplayNoLinkPrompts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
            string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

            stringBuilder.Append(colorRed + "No Seamoth link chip" + colorEnd);
            stringBuilder.Append('\n');

            stringBuilder.Append(thisText1);
            string result = stringBuilder.ToString();
            HandReticle.main.SetUseTextRaw(result, thisText2);
        }



        // ##########################################
        // Electrical prompts for Lights and Battery
        // ##########################################
        public static void DisplayElectricalPrompts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
            string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

            if (!Vehicle_Update_Patch.LightsAreOn)
            {
                stringBuilder.Append("Lights on ");
                string displayRightMouseButton = uGUI.GetDisplayTextForBinding("MouseButtonRight");
                stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", displayRightMouseButton);
            }
            else
            {
                if (Vehicle_Update_Patch.HighBeamOn)
                    stringBuilder.Append("Light Lo ");
                else
                    stringBuilder.Append("Light Hi ");
                stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.LightsLoHiKeybindValue.ToString());
                stringBuilder.Append(" off ");
                string displayRightMouseButton = uGUI.GetDisplayTextForBinding("MouseButtonRight");
                stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", displayRightMouseButton);
            }

            stringBuilder.Append(" Battery ");
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", uGUI.GetDisplayTextForBinding("R"));
            stringBuilder.Append('\n');

            stringBuilder.Append(thisText2);
            string result = stringBuilder.ToString();
            HandReticle.main.SetUseTextRaw(thisText1, result);
        }


        public static void DisplayInsertBattery()
        {
            if (Config.ShowKeyPromptToggleValue)
            {
                StringBuilder stringBuilder = new StringBuilder();
                string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
                string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

                stringBuilder.Append(colorRed + "Insert main battery " + colorEnd);
                stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", uGUI.GetDisplayTextForBinding("R"));
                stringBuilder.Append('\n');

                stringBuilder.Append(thisText1);
                string result = stringBuilder.ToString();
                HandReticle.main.SetUseTextRaw(result, thisText2);
            }
        }


        public static void DisplayNoBattery()
        {
            if (Config.ShowKeyPromptToggleValue)
            {
                StringBuilder stringBuilder = new StringBuilder();
                string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
                string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

                stringBuilder.Append(colorRed + "No battery" + colorEnd);
                stringBuilder.Append('\n');
                stringBuilder.Append(thisText1);
                string result = stringBuilder.ToString();
                HandReticle.main.SetUseTextRaw(result, thisText2);
            }
        }


        public static void DisplayBatteryPrompts()
        {
            StringBuilder stringBuilder = new StringBuilder(); ;
            stringBuilder.AppendFormat("{0} ", Language.main.Get("ItemSelectorPrevious"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>) ", uGUI.GetDisplayTextForBinding("MouseWheelDown"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>) ", KeyCode.S);
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", KeyCode.A);
            stringBuilder.AppendFormat(", {0} ", Language.main.Get("ItemSelectorNext"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>) ", uGUI.GetDisplayTextForBinding("MouseWheelUp"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>) ", KeyCode.W);
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", KeyCode.D);
            stringBuilder.AppendFormat("\n{0} ", Language.main.Get("ItelSelectorSelect"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", uGUI.GetDisplayTextForBinding("MouseButtonLeft"));
            stringBuilder.AppendFormat(", {0} ", Language.main.Get("ItemSelectorCancel"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>) ", uGUI.GetDisplayTextForBinding("MouseButtonRight"));
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>) ", KeyCode.E);
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", KeyCode.Escape);
            HandReticle.main.SetUseTextRaw("", stringBuilder.ToString());
        }


        // ######################################################################
        // Electronic prompts for Cruise Control, Mode and Health and Power info
        // ######################################################################
        public static void DisplayElectronicPrompts(float thisCharge)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
            string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

            stringBuilder.Append(" Cruise ");

            if (SeamothInfo.CruiseControlOn)
                stringBuilder.Append(colorYellow + "off " + colorEnd);
            else
                stringBuilder.Append("on ");

            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.CruiseKeybindValue.ToString());

            if (thisCharge > 20f)
            {
                if (SeamothInfo.ModeGreenOn)
                    stringBuilder.Append(" Turbo mode ");
                else
                    stringBuilder.Append(" Green mode ");
                stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.ModeKeybindValue.ToString());
            }

            stringBuilder.Append('\n');
            stringBuilder.Append("Cycle health ");
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.HealthKeybindValue.ToString());
            stringBuilder.Append(" power ");
            stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.PowerKeybindValue.ToString());
            stringBuilder.Append('\n');

            stringBuilder.Append(thisText2);
            string result = stringBuilder.ToString();
            HandReticle.main.SetUseTextRaw(thisText1, result);
        }


        // #############################
        // Mechanical prompts for Gears
        // #############################
        public static void DisplayMechanicalPrompts()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string thisText1 = Traverse.Create(HandReticle.main).Field("useText1").GetValue<string>();
            string thisText2 = Traverse.Create(HandReticle.main).Field("useText2").GetValue<string>();

            switch (Config.SeamothGearValue)
            {
                case 1:
                    stringBuilder.Append("Gear up ");
                    stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearUpKeybindValue.ToString());
                    break;
                case 6:
                    stringBuilder.Append("Gear down ");
                    stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearDownKeybindValue.ToString());
                    break;
                default:
                    stringBuilder.Append("Gear up ");
                    stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearUpKeybindValue.ToString());
                    stringBuilder.Append(" down ");
                    stringBuilder.AppendFormat("(<color=#ADF8FFFF>{0}</color>)", Config.GearDownKeybindValue.ToString());
                    break;
            }

            stringBuilder.Append('\n');
            stringBuilder.Append(thisText2);
            string result = stringBuilder.ToString();
            HandReticle.main.SetUseTextRaw(thisText1, result);
        }
    }
}
