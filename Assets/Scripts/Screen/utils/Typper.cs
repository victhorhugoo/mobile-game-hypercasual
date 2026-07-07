using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using NaughtyAttributes;

public class Typper : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenletters = .1f;
    public string phrase;

    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach (char l in s.ToCharArray())
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenletters);
        }
    }

    private void Awake()
    {
        textMesh.text = "";
    }

    [Button]
    public void StartType()
    {
        StartCoroutine(Type(phrase));
    }

    
}
