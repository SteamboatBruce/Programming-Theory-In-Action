﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricycleController : CycleController
{
    TricycleController()
        :base()
    {
        cycle = new Tricycle();
    }
 
    public override void MoveForward()
    {
        transform.Translate(new Vector3(0, 0, cycle.Speed));
    }
    public override void MoveBackward()
    {
        transform.Translate(new Vector3(0, 0, -cycle.Speed));
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
