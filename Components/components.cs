using System.Collections;
using System.Collections.Generic;
using System.Numerics;


public class DataComponent
{
  public DataComponent() { }
}


public class PositionComponent : DataComponent
{
  public Vector3 data;
  public static PositionComponent From(Vector3 v)
  {
    return new PositionComponent()
    {
      data = v
    };
  }
}