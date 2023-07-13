using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicycleController : CycleController // INHERITANCE
{
    UnicycleController()
        :base()
    {
        cycle = new Unicycle();
    }


    public override void MoveForward() // POLYMORPHISM
    {
        transform.Translate(new Vector3(0, 0, cycle.Speed));
    }
    public override void MoveBackward() // POLYMORPHISM
    {
        transform.Translate(new Vector3(0, 0, -cycle.Speed));
    }
}
