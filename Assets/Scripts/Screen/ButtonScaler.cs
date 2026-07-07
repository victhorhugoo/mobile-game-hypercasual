using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ButtonScaler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float finalScale = 1.2f;
    public float scaleDuration = .1f;

    private Vector3 _defaultScale;
    private Tween _currentTween;

    private void Awake()
    {
        _defaultScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Pointer entered the button!");
        _currentTween = transform.DOScale(_defaultScale * finalScale, scaleDuration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Pointer exited the button!");
        _currentTween.Kill();
        transform.localScale = _defaultScale;
    }
}
