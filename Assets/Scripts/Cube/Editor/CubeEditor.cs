using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Cube))]
public class CubeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Cube myCube = (Cube)target;

        myCube.cubePrefab = (GameObject)EditorGUILayout.ObjectField("Cube Prefab", myCube.cubePrefab, typeof(GameObject), true);
        myCube.moveSpeed = EditorGUILayout.FloatField("Move Speed", myCube.moveSpeed);
        myCube.rotationSpeed = EditorGUILayout.FloatField("Rotation Speed", myCube.rotationSpeed);

        if(myCube.moveSpeed <= 0)
        {
            EditorGUILayout.HelpBox("Move Speed must be greater than 0", MessageType.Warning);
        }

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);

        buttonStyle.normal.textColor = Color.white;
        buttonStyle.fontStyle = FontStyle.Bold;
        buttonStyle.fontSize = 14;

        GUI.backgroundColor = Color.green;

        if (GUILayout.Button("Create Cube", buttonStyle))
        {
            myCube.CreateCube();
        }
    }
}
