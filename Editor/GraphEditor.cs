using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GraphBehaviour))]
public class GraphEditor : Editor
{

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    var t = target as GraphBehaviour;


    if (GUILayout.Button("実行"))
    {



    }

  }


}
