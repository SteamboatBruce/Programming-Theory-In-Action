using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicycleController : CycleController
{
    UnicycleController()
        :base()
    {
        cycle = new Unicycle();
    }


    public override void MoveForward()
    {
        transform.Translate(new Vector3(0, 0, cycle.Speed));
    }
    public override void MoveBackward()
    {
        transform.Translate(new Vector3(0, 0, -cycle.Speed));
    }
}
