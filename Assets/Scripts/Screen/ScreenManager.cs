using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;
using JetBrains.Annotations;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBase;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if (_currentScreen != null)
            {
                _currentScreen.Hide();
            }

            var nextScreen = screenBase.Find(x => x.screenType == type);
            
            nextScreen.Show();
            _currentScreen = nextScreen;
            
        }
        
        public void HideAll()
        {
            foreach (var screen in screenBase)
            {
                screen.Hide();
            }
        }
    }

}
