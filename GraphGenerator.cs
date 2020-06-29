using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Numerics;
using Vector3 = System.Numerics.Vector3;

public class GraphGenerator : MonoBehaviour
{
  public int count = 10;
  public Bounds bound;
  [Range(1,10)]
  public int nearJoint = 2;



  public void GenerateRandomGraph()
  {
    var result = new GameObject("GeneratedGraph");

    var graph = result.AddComponent<GraphBehaviour>();

    graph.graph = PositionGraph.From(Vector3.Zero);
    Graph zero = graph.graph;
    List<Graph> all = graph.all;


    for (int i = 0; i < count; i++)
    {
      Graph g = PositionGraph.From(RandomPos());
      zero += g;
      all.Add(g);
      
    }

    //Debug.Log($"ZERO= {zero.id} ");

    //ループしつつ最近点２個のみの接続とする
    for(int i = count-1; 0 <= i; i--)
    {
      
      //pick
      var origin=zero[i];
      //find2
      var picks= 
        zero.Where(A => 
        A != origin 
        && A != zero        
        )
        .OrderBy(B =>
        {

          var d= Vector3.Distance(
          origin.Position,
          B.Position);
          return d;
        }
)
        .Take(nearJoint)
        .ToList();

      Debug.Log($"{origin.id} =>{string.Join(",", picks.Select(pick => pick.id).ToArray())}");


      foreach(Graph pick in picks)
      {
        origin += pick;
      }

    }

    //zeroと縁を切る
    Debug.Log($"Zeroと縁切り {zero.Count}");
    //zeroと近傍のみ接続
    zero
      .Where(A => A != zero)
      .OrderByDescending(B =>
      {
        var d = Vector3.Distance(
        zero.Position,
        B.Position);
        return d;
      })
      //近傍以外
      .Take(zero.Count - nearJoint)
      .ToList()
      .ForEach(g => zero -= g);

  }

  private void OnDrawGizmos()
  {
    Gizmos.color = Color.red * 0.25f;


    Gizmos.DrawCube(bound.center, bound.size);
  }


  private Vector3 RandomPos()
  =>new Vector3(
      UnityEngine.Random.Range(bound.min.x, bound.max.x),
      UnityEngine.Random.Range(bound.min.y, bound.max.y),
      UnityEngine.Random.Range(bound.min.z, bound.max.z)
      );
}
