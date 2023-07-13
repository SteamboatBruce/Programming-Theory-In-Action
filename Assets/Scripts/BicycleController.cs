using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleController : CycleController
{
    public AudioClip disallowedClip;

    BicycleController()
        :base()
    {
        cycle = new Bicycle();      
    }

    
    public override void MoveForward() {
        transform.Translate(new Vector3(0, 0, cycle.Speed));
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
