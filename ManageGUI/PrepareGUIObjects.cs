using SeamothEnhancementSystem.InGame;
using UnityEngine;

namespace SeamothEnhancementSystem.ManageGUI
{
    class PrepareGUIObjects
    {
        public static GameObject PrepareGUIObject(string thisGameObjectName, Vector3 thisVector3)
        {
            GameObject thisGameObject = new GameObject(thisGameObjectName);
            thisGameObject.transform.SetParent(ManageAllGUIElements.gameObject.transform, false);
            thisGameObject.transform.position = thisVector3;  //GearInfo.light_Position

            return thisGameObject;
        }
    }
}
