using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Board))]
public class BoardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Board board = (Board)target;
        if(GUILayout.Button("Board preview"))
        {
            board.Setup();
        }

        

        if(GUILayout.Button("Clear board"))
        {
            board.ResetBoard();
        }
    }
}
