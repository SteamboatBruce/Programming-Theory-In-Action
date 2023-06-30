using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclist : MonoBehaviour
{
    public enum Skill { BEGINNER, AVERAGE, ADVANCED };

    [SerializeField] 
    private Skill _skillLevel = Skill.BEGINNER;
    public Skill SkillLevel { get { return _skillLevel; } }

    GameObject seat;

    public GameObject selectedBike; //bwd set this dynamically based on mouse click

    public string SkillLevelText
    {
        get
        {
            switch (_skillLevel)
            {
                case Skill.BEGINNER:
                    return "Beginner";
                case Skill.AVERAGE:
                    return "Average";
                case Skill.ADVANCED:
                    return "Advanced";
                default:
                    return "Unknown";
            }
        }
    }

    public Cyclist() { }

    public void Start()
    {
        seat = selectedBike.GetComponent<Cycle>().seat;
        transform.SetParent(selectedBike.transform);
        transform.localPosition = seat.transform.localPosition;
        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), Vector3.forward);
       
    }


}
