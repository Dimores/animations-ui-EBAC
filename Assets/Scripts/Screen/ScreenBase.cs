using DG.Tweening;
using NaughtyAttributes;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
        public Image uiBackground;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObjects = .5f;

        private Dictionary<Transform, Vector3> _defaultScales = new();

        private void Awake()
        {
            _defaultScales.Clear();

            foreach (var obj in listOfObjects)
            {
                if (obj == null) continue;

                if (!_defaultScales.ContainsKey(obj))
                    _defaultScales.Add(obj, obj.localScale);
            }
        }

        private void Start()
        {
            if (startHiden) Hide();
        }

        private void StartType()
        {
            listOfPhrases.ForEach(i => i.StartType());
        }

        private void CleanTexts()
        {
            listOfPhrases.ForEach(i => i.textMesh.text = "");
        }

        [Button]
        public virtual void Show()
        {
            if (!EditorApplication.isPlaying) return;

            gameObject.SetActive(true);

            CleanTexts();
            ShowObjects();
        }

        [Button]
        public virtual void Hide()
        {
            ForceHideObjects();
            uiBackground.enabled = false;
        }

        private void ForceHideObjects()
        {
            foreach (var obj in listOfObjects)
            {
                if (obj == null) continue;

                obj.DOKill();

                if (_defaultScales.TryGetValue(obj, out Vector3 scale))
                {
                    obj.localScale = scale;
                }

                obj.gameObject.SetActive(false);
            }
        }

        private void ShowObjects()
        {
            for (int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                if (obj == null) continue;

                obj.DOKill();

                if (_defaultScales.TryGetValue(obj, out Vector3 scale))
                {
                    obj.localScale = scale;
                }

                obj.gameObject.SetActive(true);

                obj.DOScale(0, animationDuration)
                    .From()
                    .SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), listOfObjects.Count * delayBetweenObjects);

            uiBackground.enabled = true;
        }

        private void ForceShowObjects()
        {
            foreach (var obj in listOfObjects)
            {
                if (obj == null) continue;

                if (_defaultScales.TryGetValue(obj, out Vector3 scale))
                {
                    obj.localScale = scale;
                }

                obj.gameObject.SetActive(true);
            }

            uiBackground.enabled = true;
        }
    }
}