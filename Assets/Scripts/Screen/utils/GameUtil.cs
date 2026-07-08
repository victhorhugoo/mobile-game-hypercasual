using System;
using System.Collections;
using System.Collections.Generic;
using Screens;
using UnityEngine;
using Random = UnityEngine.Random;

public static class GameUtil
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Test/TestGame %p")]
    public static void TestGame()
    {
        Debug.Log("TestGame");
    }
#endif

    /*//public static SphereCollider AddTrigger(Transform parent, float radius = 1)
    
    private static void Scale(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    private static T GetRandom<T>(this List<T> list)
    {
        
        return list[Random.Range(0, list.Count)];
    }

    public static void SetActive(MonoBehaviour mono, float delay, Action callback)
    {


    } */
}