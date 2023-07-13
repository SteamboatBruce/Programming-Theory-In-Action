using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CycleController : MonoBehaviour
{
    public GameObject seat;
    protected Cycle cycle;

    Vector3 initialPosition;


    [SerializeField]
    private float speed = .001f;


    private void Awake()
    {
        initialPosition = transform.position;
        cycle.Speed = speed;
    }

    public void ResetPosition()
    {
        transform.position = initialPosition;
    }

    public virtual void MoveForward()
    {
        // By default, do nothing.  Override for other behavious

    }

    public virtual void MoveBackward()
    {
        // By default, do nothing.  Override for other behavious

    }

    public virtual void Dismount()
    {
        ResetPosition();
        cycle.Dismount();
    }

    public virtual bool Mount(Cyclist rider)
    {
        return cycle.Mount(rider);
    }

    public virtual bool CanBeRiddenBy(Cyclist rider)
    {
        return cycle.CanBeRiddenBy(rider);

    }

}
