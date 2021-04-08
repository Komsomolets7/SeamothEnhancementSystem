using UnityEngine;
using UnityEngine.UI;

namespace SeamothEnhancementSystem.ManageGUI
{
    class PrepareGUISprite
    {
        public static GameObject PrepareGuiElement(GameObject thisGameObject, string thisSpriteName, Vector3 thisPosition, Vector2 thisSize)
        {
            Sprite thisSprite = thisGameObject.GetComponent<Sprite>();
            if (thisSprite == null)
                thisSprite = MainPatcher.assetBundle.LoadAsset<Sprite>(thisSpriteName);

            Image BackgroundUIImage = thisGameObject.GetComponent<Image>();
            if (BackgroundUIImage == null)
                thisGameObject.gameObject.AddComponent<Image>().sprite = thisSprite;
            BackgroundUIImage = thisGameObject.GetComponent<Image>();

            RectTransform componentGUI = BackgroundUIImage.GetComponent<RectTransform>();

            componentGUI.localPosition = thisPosition;
            componentGUI.sizeDelta = thisSize;

            return thisGameObject;
        }
    }
}
