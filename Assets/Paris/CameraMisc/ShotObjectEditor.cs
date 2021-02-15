using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShotObject))]
public class ShotObjectEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        ShotObject myScript = (ShotObject)target;
        if (GUILayout.Button("Set Shot")) {
            myScript.SetShot();
        }
    }
}
