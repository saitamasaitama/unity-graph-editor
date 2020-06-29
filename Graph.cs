using System.Collections;
using System.Collections.Generic;
using System;
using System.Numerics;
using Edges = System.Collections.Generic.List<
    System.Collections.Generic.KeyValuePair<Graph, Graph>
  >;
using EdgeIndexes= System.Collections.Generic.List<
    System.Collections.Generic.KeyValuePair<int, int>
  >;


public class Graph : List<Graph>
{
  public int id;
  private static int SerialNo = 0;
  private static int searchCount = 0;

  public Graph()
  {
    this.id = SerialNo;
    SerialNo++;
  }


  protected Dictionary<Type, DataComponent>
    components = new Dictionary<Type, DataComponent>();


  //そのグラフと結合しているIDのリスト（ユニーク)  

  



  public DataComponent GetComponent<T>()
    where T : DataComponent
  {
    //componentsを検索する
    return components[typeof(T)] ?? null;
  }

  public T AddComponent<T>()
    where T:DataComponent,new()
  {
    return new T();
  }

  //基礎コンポーネントのGetter
  public Vector3 Position
  {
    get
    {
      Type k = typeof(PositionComponent);
      if (components.ContainsKey(k)){
        
        return  (components[k] as PositionComponent).data;

      }
      else throw new NotImplementedException("Object don't has Position");
    }
  }
 
  public List<Graph> FindAllGraph(
    List<Graph> result = null)
  {
    if (result == null)
    {
      result = new List<Graph>();
    }

    foreach(Graph g in this)
    {
      if (result.Contains(g)) continue;
      result.Add(g);
      result = g.FindAllGraph(result);
    }

    return result;
  }

  public void eachAll(
    Action<Graph> GraphAction,
    Action<Graph,Graph> EdgeAction,
    List<Graph> sensordGraph=null,
    Dictionary<int,
      Dictionary<int, 
        bool
      >>  sensordEdge=null    
    )
  {
    
    if (sensordEdge == null)
    {
      sensordEdge = new Dictionary<int, Dictionary<int, bool>>();
    }
    if (sensordGraph == null)
    {
      sensordGraph = new List<Graph>() ;
    }

    Graph from = this;


    foreach (Graph to in this)
    {

      if (sensordGraph.Contains(to))
      {
        continue;
      }
      //エッジのインデックスを集めてソート
      int[] indexes = new int[] { from.id, to.id };
      Array.Sort(indexes);

      int first = indexes[0];
      int second = indexes[1];

      if (!sensordEdge.ContainsKey(first))
      {
        sensordEdge.Add(first, new Dictionary<int, bool>());
      }

      if (!sensordEdge[first].ContainsKey(second))
      {
        //Edgeを記述
        sensordEdge[first].Add(second, true);
        EdgeAction(from, to);

      }
      else
      {
        continue;

      }
      //終了条件は？

      to.eachAll(
        GraphAction,
        EdgeAction,
        sensordGraph,
        sensordEdge
        );
    }
    //自分は検索済み
    sensordGraph.Add(this);
    GraphAction(this);

  }
  
  public static Graph operator +(Graph A,Graph B)
  {
    A.Add(B);
    B.Add(A);
    return A;
  }

  public static Graph operator -(Graph A, Graph B)
  {  
    
    if (A.Contains(B))
    {
      A.Remove(B);
    }
    if (B.Contains(A))
    {
      B.Remove(A);
    }    
    return A;
  }

  public override string ToString() => $@"ID = {this.id} HAS = {this.Count}";



}


public class PositionGraph : Graph
{
  public static PositionGraph From(Vector3 v)=> 
    new PositionGraph() { 
      components=
      new Dictionary<Type, DataComponent>() {
        {
          typeof(PositionComponent),          
          PositionComponent.From(v)
        }
      }
  };
 
}








