using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PieceType))]
[CanEditMultipleObjects]

public class PieceTypeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PieceType script = (PieceType)target;
        if (script.slideMoves) // if bool is true, show other fields
        {
            script.slideMovesList = EditorGUILayout.Vector3IntField("Moves:", new Vector3Int(0, 0, 0));

        }
    }
}