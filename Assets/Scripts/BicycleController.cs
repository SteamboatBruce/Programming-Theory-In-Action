using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : CycleController
{
    public AudioClip disallowedClip;

    BicycleController()
    {
        cycle = new Bicycle();
    }

    public float speed = 0.01f;
    public override void MoveForward() {
        transform.Translate(new Vector3(0, 0, speed));
    }
    public override void MoveBackward()
    {
        // Bikes don't go backwards
        GetComponent<AudioSource>().PlayOneShot(disallowedClip);
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
