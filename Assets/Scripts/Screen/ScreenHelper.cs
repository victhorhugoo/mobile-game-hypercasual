using System.Collections;
using System.Collections.Generic;
using Screens;
using UnityEngine;

namespace screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick()
        {
            ScreenManager.Instance.ShowByType(screenType);
        }
    }
}