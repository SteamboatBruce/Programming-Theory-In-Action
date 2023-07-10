using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnicycleController : CycleController
{
    UnicycleController()
    {
        cycle = new Unicycle();
    }

    public float speed = 0.005f;
    public override void MoveForward()
    {
        transform.Translate(new Vector3(0, 0, speed));
    }
    public override void MoveBackward()
    {
        transform.Translate(new Vector3(0, 0, -speed));
    }
}
