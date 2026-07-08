using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField(myTarget.carPrefab, typeof(GameObject), true);
        myTarget.speed = EditorGUILayout.IntField("minha velocidade", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("minha marcha", myTarget.gear);

        EditorGUILayout.LabelField("minha velocidade", myTarget.TotalSpeed.ToString());
        EditorGUILayout.HelpBox("Calcule a velocidade do carro", MessageType.Info);

        if(myTarget.TotalSpeed > 200)
        {
            EditorGUILayout.HelpBox("A velocidade total do carro é maior que 200", MessageType.Warning);
        }

        if(GUILayout.Button("Create Car"))
        {
            myTarget.CreateCar();
        }
    }
}