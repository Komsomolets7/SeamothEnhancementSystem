using UnityEngine;
using UnityEngine.UI;
using SeamothEnhancementSystem.InGame;
using SeamothEnhancementSystem.InfoObjects;
using SeamothEnhancementSystem.Configuration;

namespace SeamothEnhancementSystem.ManageGUI
{
    internal static class PrepareGUITxt
    {
        public static GameObject PrepareTxtElement(GameObject thisGameObject, float fontModifier, bool setTxtColor, bool moduleIn, Color thisTxtColor, Vector3 thisPosition, Vector2 thisSize)
        {
            thisGameObject.transform.SetParent(ManageAllGUIElements.gameObject.transform, false);
            Text text = thisGameObject.GetComponent<Text>();

            if (text == null)
                text = thisGameObject.gameObject.AddComponent<Text>();

            text.font = Player.main.textStyle.font;
            text.fontSize = Mathf.RoundToInt(Config.VehicleFontSizeSliderValue / fontModifier); // eg 1.5f
            text.alignment = TextAnchor.MiddleCenter;

            if (setTxtColor)
            {
                if (!moduleIn && SeamothInfo.seamothLinkModuleIn) // eg !SeamothInfo.mechanicalModuleIn
                    text.color = Color.grey;
                //else if (thisGuiType == "gear")
                else if (thisGameObject == GameObject.Find("GearTextUI"))
                {
                    if (Config.SeamothGearValue == 6f)
                        text.color = Color.red;
                    else if (Config.SeamothGearValue == 5f)
                        text.color = Color.yellow;
                    else
                        text.color = Color.white;
                }
                else
                    text.color = thisTxtColor;
            }
            else
                text.color = Color.white;

            RectTransform componentGUI = text.GetComponent<RectTransform>();
            componentGUI.localPosition = thisPosition;
            componentGUI.sizeDelta = thisSize;
            GearInfo.gameObject = thisGameObject;

            return thisGameObject;
        }


    }
}
