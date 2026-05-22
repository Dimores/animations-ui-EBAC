using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NaughtyAttributes;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float delay = .1f;
    public string textToType = "Lorem ipsum dolor sit amet";

    private void Awake()
    {
        textMesh.text = "";
    }

    [Button]
    public void StartType()
    {
        StartCoroutine(Type(textToType));
    }

    IEnumerator Type(string s)
    {
        textMesh.text = "";

        foreach (char c in s.ToCharArray())
        {
            textMesh.text += c;
            yield return new WaitForSeconds(delay);
        }
    }
}
