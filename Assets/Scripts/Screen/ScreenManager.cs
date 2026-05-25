using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;

        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if(_currentScreen != null) _currentScreen.Hide();

            var nextScreen = screenBases.Find(x => x.screenType == type);

            if (nextScreen != null)
            {
                nextScreen.Show();
            }

            _currentScreen = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach(x => x.Hide());
        }
    }
}
