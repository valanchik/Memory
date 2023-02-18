using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AutoAnchors))]
public class AutoAnchorsEditor : Editor
{
    private AutoAnchors autoAnchors;

    override public void OnInspectorGUI()
    {
        this.autoAnchors = (AutoAnchors)target;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Set anchors"))
            this.autoAnchors.SetAnchors();

        GUILayout.EndHorizontal();
        //DrawDefaultInspector();
    }
}

