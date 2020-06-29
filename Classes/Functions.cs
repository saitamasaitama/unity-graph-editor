using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Functions
{


  public static void CircleEach(
    float radius,//半径
    float step, //刻み
    Action<float,float> action
    )
  {

    for(float d = 0 ; d < radius; d += step)
    {
      //最初の点をプロット
      
      //円周を計算
      float round =(float)(d * 2 * Math.PI);
      for (float r = 0;
          r < round;  
          r+=step
          )
      {
        float radian = (float)((r / round)*2*Math.PI);

        action(d, radian);
      }
    }


  }
}
