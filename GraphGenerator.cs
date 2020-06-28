using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;

public class GraphGenerator : MonoBehaviour
{
  public int count=100;




  public void GenerateRandomGraph()
  {
    var result = new GameObject("GeneratedGraph");

    var data= result.AddComponent<GraphBehaviour>().graph;

    
    for(int i = 0; i < count; i++)
    {
      data.Add(PositionGraph.From(
        new 
        ));


    }


  }



}
