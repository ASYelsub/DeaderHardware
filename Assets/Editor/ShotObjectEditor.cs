using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CustomEditor(typeof(ShotObject))]
public class ShotObjectEditor : Editor {
    #if UNITY_EDITOR
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        ShotObject myScript = (ShotObject)target;
        if (GUILayout.Button("Set Shot")) {
            myScript.SetShot();
        }
    }
    #endif
}

[CustomEditor(typeof(TriggerSystem_CameraStatic))]
public class ShotObjectEditor2 : Editor {
    #if UNITY_EDITOR
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        TriggerSystem_CameraStatic myScript = (TriggerSystem_CameraStatic)target;
        if (GUILayout.Button("Set Shot")) {
            myScript.SetShot();
        }
    }
    #endif
}
