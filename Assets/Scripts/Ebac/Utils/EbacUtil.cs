using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

namespace Ebac.Core.Utils
{
    public static class EbacUtil
    {
        [UnityEditor.MenuItem("Ebac/Utils/Play Particles")]
        public static void PlayParticles()
        {
            GameManager.Instance.PlayParticles();
        }

        public static T GetRandom<T>(this T[] array)
        {
            if (array.Length == 0)
                return default(T);

            return array[Random.Range(0, array.Length)];
        }

        public static T GetRandom<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default(T);

            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomButNotTheSame<T>(this List<T> list, T unique)
        {
            if (list.Count == 1)
                return unique;

            int randomIndex = Random.Range(0, list.Count);
            return list[randomIndex];
        }

        public static void Scale(List<GameObject> objectsToScale, float duration, float delayInEach = 0f)
        {
            for (int i = 0; i < objectsToScale.Count; i++)
            {
                objectsToScale[i].transform.DOScale(1, duration).SetDelay(delayInEach * i);
            }
        }
    }
}
