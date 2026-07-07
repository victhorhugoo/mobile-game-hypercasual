using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

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

        public bool startHided = false;

        [Header("Animation")]
        public float delayBetweenObjects = .05f;
        public float animationDuration = .3f;

        private void Start()
        {
            if (startHided)
            {
                HideObjects();
            }
        }

        [ Button ]
        protected virtual void Show()
        {
            Debug.Log("Show");
            ShowObjects();
        }
        
        [Button]
        protected virtual void Hide()
        {
            Debug.Log("Hide");
            HideObjects();
        }

        private void ShowObjects()
        {
            for(int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];
                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
            Invoke(nameof(StartType), listOfObjects.Count * delayBetweenObjects);
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }
    }
}