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

[CustomEditor(typeof(TriggerSystem_CameraStatic))]
public class ShotObjectEditor2 : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        TriggerSystem_CameraStatic myScript = (TriggerSystem_CameraStatic)target;
        if (GUILayout.Button("Set Shot")) {
            myScript.SetShot();
        }
    }
}
