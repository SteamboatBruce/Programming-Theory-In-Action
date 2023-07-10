using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CyclistController : MonoBehaviour
{

    GameObject seat;
    Camera m_Camera;

    GameObject selectedCycle; //bwd set this dynamically based on mouse click
    public RidingSkills.SKILLLEVEL skillLevel = RidingSkills.SKILLLEVEL.BEGINNER;

    //public RidingSkills.SKILLLEVEL SkillLevel
    //{
    //    get
    //    {
    //        return skillLevel;
    //    }
    //    set
    //    {
    //        skillLevel = value;
    //        Rider.RidingSkills.SkillLevel = skillLevel;
    //    }
    //}

    public Cyclist rider = new Cyclist();
    public Cyclist Rider { get { return rider; } }

    CycleController cycleController;

    Vector3 initialPosition;
    Quaternion initialRotation;
    Transform initialParent;

    private void Awake()
    {
        m_Camera = Camera.main;
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        initialParent = transform;
    }

    public void Start()
    {
        Rider.RidingSkills.SkillLevel = skillLevel;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                GameObject target = hit.collider.gameObject;
                if (target.CompareTag("Cycle"))
                {
                    cycleController = target.GetComponent<CycleController>();
                    if (cycleController.cycle.Mount(Rider))
                    {
                        // Rider is allowed to get on cycle.  Put him there.
                        selectedCycle = target;
                        GetOnSelectedCycle();
                    }
                    else
                    {
                        // Not allowed on Cycle.
                        //bwd show an error message.
                        GetComponent<AudioSource>().Play();
                        StartCoroutine(ShakeCyclist());
                    }
                }
                else if (target.CompareTag("Rider"))
                {
                    CyclistController controller = target.GetComponent<CyclistController>();
                    // Change skill level;
                    controller.Rider.RidingSkills.SkillLevel = controller.Rider.RidingSkills.GetNextSkillLevel();
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

        void Dismount()
        {
            cycleController.cycle.Dismount();
            transform.SetParent(initialParent);
            transform.SetPositionAndRotation(initialPosition, initialRotation);

        }

        void GetOnSelectedCycle()
        {
            seat = selectedCycle.GetComponent<CycleController>().seat;
            transform.SetParent(selectedCycle.transform);
            transform.localPosition = seat.transform.localPosition;
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), Vector3.forward);
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

