using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(GraphGenerator))]
public class GraphGeneratorEditor : Editor
{

  public override void OnInspectorGUI()
  {
    base.OnInspectorGUI();
    var t = target as GraphGenerator;


    if (GUILayout.Button("実行"))
    {
      t.GenerateRandomGraph();


    }

  }


  [InitializeOnLoadMethod]
  private static void SceneviewLoad()
  {
    Debug.Log("SceneView Loading");
    SceneView.duringSceneGui += scene =>
    {/*
      Handles.BeginGUI();
      var ButtonWidth = 300.0f;
      if (GUILayout.Button("ボタンラベル", GUILayout.Width(ButtonWidth)))
      {
        // 押されたらダイアログを表示する
        EditorUtility.DisplayDialog("ボタン押した？", "今ボタン押したよね？", "押した");
      }
      Handles.EndGUI();
      */
    };
  }

}
