using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GroundGenerator))]
public class GroundGeneratorEditor : Editor
{

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    var t = target as GroundGenerator;


    if (GUILayout.Button("Generate"))
    {
      t.GenerateRandomGraph();
    }

  }

}
