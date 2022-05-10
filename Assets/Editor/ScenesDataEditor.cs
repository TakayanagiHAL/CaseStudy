using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScenesData))]
public class ScenesDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var script = (ScenesData)target;

        if (GUILayout.Button("ƒV[ƒ“Enum‚ğì¬", GUILayout.Height(40)))
        {
            string[] enumNames = new string[script.sceneInfo.Count];

            for (int i = 0; i < script.sceneInfo.Count; i++)
            {
                enumNames[i] = script.sceneInfo[i].SCENETYPE;
            }

            GenerateEnum.Go("SCENE_TYPE", enumNames);
        }
    }
}
