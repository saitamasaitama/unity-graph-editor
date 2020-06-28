using System.Collections;
using System.Collections.Generic;
using System;
using System.Numerics;

public class Graph : List<Graph>
{


  protected Dictionary<Type, DataComponent>
    components = new Dictionary<Type, DataComponent>();

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
  public Vector3? Position =>(components[typeof(PositionComponent)] as PositionComponent).data;
  

}

public class PositionGraph : Graph
{
  public static PositionGraph From(Vector3 v)=> 
    new PositionGraph() { 
      components=new Dictionary<Type, DataComponent>() {
        {
          typeof(PositionComponent),          
          PositionComponent.From(v)
        }
      }
  };
 
}


public struct V
{
  public float X, Y, Z;

  public static V From(float X,float Y,float Z)
  => new V()
    {
      X = X,
      Y = Y,
      Z = Z
    };
}

public struct Q
{
  public float X, Y, Z,W;

  public static Q From(float X, float Y, float Z,float W)
  => new Q()
  {
    X = X,
    Y = Y,
    Z = Z,
    W=W
  };
}



