using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TricycleController : CycleController
{
    TricycleController()
    {
        cycle = new Tricycle();
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
