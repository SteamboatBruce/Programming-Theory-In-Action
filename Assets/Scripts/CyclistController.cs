using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CyclistController : MonoBehaviour
{

    GameObject seat;
    Camera m_Camera;

    GameObject selectedCycle; //bwd set this dynamically based on mouse click
    public RidingSkills.SKILLLEVEL skillLevel = RidingSkills.SKILLLEVEL.BEGINNER;

    public AudioClip changeSkillClip;
    public AudioClip mountClip;
    public AudioClip dismountClip;
    public AudioClip skillMismatchClip;

    public Cyclist rider = new Cyclist();
    public Cyclist Rider { get { return rider; } }

    CycleController cycleController;

    Vector3 initialPosition;
    Quaternion initialRotation;
    Transform initialParent;

    AudioSource audioSource;

    private void Awake()
    {
        m_Camera = Camera.main;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialParent = transform;

        audioSource = GetComponent<AudioSource>();
    }

    public void Start()
    {
        Rider.RidingSkills.SkillLevel = skillLevel;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) {
            if (cycleController != null) {
                // Move cycle forward
                cycleController.MoveForward();
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (cycleController != null)
            {
                // Move cycle backward
                cycleController.MoveBackward();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject target = hit.collider.gameObject;
                if (target.CompareTag("Cycle"))
                {
                    CycleController targetCycleController = target.GetComponent<CycleController>();
                    if (targetCycleController.Mount(Rider))
                    {

                        Dismount(false);
                        // Rider is allowed to get on cycle.  Put him there.
                        cycleController = targetCycleController;
                        selectedCycle = target;
                        GetOnSelectedCycle();
                    }
                    else
                    {
                        // Not allowed on Cycle.
                        //bwd show an error message?
                        audioSource.PlayOneShot(skillMismatchClip);
                        StartCoroutine(ShakeCyclist());
                    }
                }
                else if (target.CompareTag("Rider"))
                {
                    CyclistController cyclistController = target.GetComponent<CyclistController>();

                    // Change skill level;
                    cyclistController.Rider.RidingSkills.SkillLevel = cyclistController.Rider.RidingSkills.GetNextSkillLevel();
                    audioSource.PlayOneShot(changeSkillClip);

                    // If currently on a bike, kick off if no longer has approriate skill;
                    if (cyclistController.gameObject.transform.parent != null)
                    {
                        GameObject parentObject = cyclistController.gameObject.transform.parent.gameObject;
                        if (parentObject != null && parentObject.CompareTag("Cycle"))
                        {
                            // Already on cycle.  Can we ride it?
                            if (!parentObject.GetComponent<CycleController>().CanBeRiddenBy(cyclistController.rider))
                            {
                                // Nope, can't ride.
                                Dismount(playClip: false);
                                audioSource.PlayOneShot(skillMismatchClip);
                                StartCoroutine(ShakeCyclist());
                            }
                        }
                    }
                }
                else
                {
                    // No cycle clicked.  Dismount to original position
                    Dismount();
                }
            }
            else
            {
                Dismount();
            }
        }

        void Dismount(bool playClip = true)
        {
            if (cycleController != null)
            {
                cycleController.Dismount();
                cycleController = null; //No longer on a bike
                transform.SetParent(initialParent);
                transform.SetPositionAndRotation(initialPosition, initialRotation);
                if (playClip)
                {
                    audioSource.PlayOneShot(dismountClip);
                }
            }

        }

        void GetOnSelectedCycle()
        {
            seat = selectedCycle.GetComponent<CycleController>().seat;
            transform.SetParent(selectedCycle.transform);
            transform.localPosition = seat.transform.localPosition;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), Vector3.forward);
            audioSource.PlayOneShot(mountClip);
        }

        IEnumerator ShakeCyclist()
        {

            for (int i = 0; i < 10; i++)
            {
                bool isEven = i % 2 == 0;
                transform.Rotate(new Vector3(0, 15 * (isEven ? 1 : -1), 0));
                transform.Translate(new Vector3(0, 0.1f * (isEven ? 1 : -1),0));


                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
    }



}

