using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Level))]
public class GetPostion : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var myScript = target as Level;

        if (GUILayout.Button("Set Position"))
        {
            myScript.spwanPosition = myScript.transform.position;

        }
    }
}
