﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphBehaviour : MonoBehaviour
{


  public Graph graph=new Graph();
  public List<Graph> all = new List<Graph>();

  public float NodeSize = 0.1f;



  private void OnDrawGizmos()
  {
    
    Gizmos.color = Color.red;
    //四色定理用のカラー
    Color[] NodeColors = new Color[] {
      Color.HSVToRGB(0.00f, 1.2f,1f),
      Color.HSVToRGB(0.25f, 1.2f,1f),
      Color.HSVToRGB(0.5f,  1.2f,1f),
      Color.HSVToRGB(0.75f, 1.2f,1f),
    };
    Color[] LineColors = new Color[] {
      Color.HSVToRGB(0.00f, 0.8f,0.8f),
      Color.HSVToRGB(0.25f, 0.8f,0.8f),
      Color.HSVToRGB(0.5f,  0.8f,0.8f),
      Color.HSVToRGB(0.75f, 0.8f,0.8f),
    };

    
    List<Graph> data = new List<Graph>(all);

    int colorIndex = 0;

    //点を連舵輪んぐ
    foreach(Graph g in all)
    {
      colorIndex++;
      Gizmos.color = NodeColors[colorIndex % 4];
      Gizmos.DrawSphere(V2V(g.Position), NodeSize);



    }
    
    
  }


  private static Vector3 V2V(System.Numerics.Vector3 v)
  {
    return new Vector3(
      v.X,
      v.Y,
      v.Z      
      );
  }


  public void GenerateRandomGraph()
  {

  }

}
