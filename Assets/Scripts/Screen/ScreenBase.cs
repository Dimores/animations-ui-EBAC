using DG.Tweening;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Screens
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;

        public List<Transform> listOfObjects;
        public List<Typper> listOfPhrases;

        public bool startHiden = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObjects = .5f;

        private void Start()
        {
            if (startHiden) Hide();
        }

        private void StartType()
        {
            listOfPhrases.ForEach(i => i.StartType());
        }

        [Button]
        protected virtual void Show()
        {
            if (!EditorApplication.isPlaying) return;
            ShowObjects();
        }

        [Button]
        protected virtual void Hide()
        {
            ForceHideObjects();
        }

        private void ForceHideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];
                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), listOfObjects.Count * delayBetweenObjects);
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }
    }
}

