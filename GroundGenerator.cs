using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Numerics;
using Vector3 = System.Numerics.Vector3;

public class GroundGenerator : MonoBehaviour
{
  [Range(1,50000)]
  public int count = 10;
  public Rect rect;
  //[Range(1,10)]
  //public int nearJoint = 2;



  public void GenerateRandomGraph()
  {
    //平面にグラフを敷き、ボロノイ図を作成した後に
    //ボロノイ図のブロックをいくつかクラスタにし、
    //クラスタの辺を道路とする
    var result = new GameObject($"GroundGraph-{count}");
    var graph = result.AddComponent<BolonoiGraphBehaviour>();

    
    
    List<Graph> all = graph.all;

    for(int i = 0; i < count; i++)
    {
      all.Add(PositionGraph.From(RandomPos()));

    }

  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.blue * 0.25f;

    Gizmos.DrawCube(rect.center, new UnityEngine.Vector3(
      rect.width,
      1f,
      rect.height
      ));
    //Gizmos.DrawCube(bound.center, bound.size);
  }


  private Vector3 RandomPos()
  =>new Vector3(
      UnityEngine.Random.Range(rect.left,rect.right),
      0,
      UnityEngine.Random.Range(rect.bottom, rect.top)
      );
}


