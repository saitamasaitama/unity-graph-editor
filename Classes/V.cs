using System.Collections;
using System.Collections.Generic;
using System.Numerics;

public struct V
{
  public float X, Y, Z;

  public static V From(float X, float Y, float Z)
  => new V()
  {
    X = X,
    Y = Y,
    Z = Z
  };
}

public struct Q
{
  public float X, Y, Z, W;

  public static Q From(float X, float Y, float Z, float W)
  => new Q()
  {
    X = X,
    Y = Y,
    Z = Z,
    W = W
  };
}
