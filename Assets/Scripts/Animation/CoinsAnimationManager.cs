using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Ebac.core.Singleton;
using UnityEditor.Search;
using UnityEngine;
using DG.Tweening;

public class CoinsAnimationManager : Singleton<CoinsAnimationManager>
{
    public List<ItemCollactableCoin> itens;

    [Header("Animation")]
    public float ScaleDuration = .2f;
    public float ScaleTimeBetweenPieces = .1f;
    public Ease ease = Ease.OutBack;

    private void Start()
    {
        itens = new List<ItemCollactableCoin>();
    }

    
    public void RegisterCoin(ItemCollactableCoin i)
    {
        if (!itens.Contains(i))
        {
            itens.Add(i);
            i.transform.localScale = Vector3.zero;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartAnimations();
        }
    }

    public void StartAnimations()
    {
        StartCoroutine(ScalePieceByTime());
    }

    IEnumerator ScalePieceByTime()
    {
        foreach (var p in itens)
        {
            p.transform.localScale = Vector3.zero;
        }

        yield return null;

        for (int i = 0; i < itens.Count; i++)
        {
            itens[i].transform.DOScale(1, ScaleDuration).SetEase(ease);
            yield return new WaitForSeconds(ScaleTimeBetweenPieces);
        }
    }
}
