using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RidingSkills {
    // These are ordered
    public enum SKILLLEVEL { BEGINNER = 10, AVERAGE = 20, ADVANCED = 30 };

    SKILLLEVEL _skillLevel = SKILLLEVEL.BEGINNER;
    public SKILLLEVEL SkillLevel { get { return _skillLevel; } set { _skillLevel = value; } }

    public string SkillLevelText
    {
        get
        {
            switch (_skillLevel)
            {
                case SKILLLEVEL.BEGINNER:
                    return "Beginner";
                case SKILLLEVEL.AVERAGE:
                    return "Average";
                case SKILLLEVEL.ADVANCED:
                    return "Advanced";
                default:
                    return "Unknown";
            }
        }
    }

    public SKILLLEVEL GetNextSkillLevel() {
        switch (_skillLevel)
        {
            case SKILLLEVEL.BEGINNER:
                return SKILLLEVEL.AVERAGE;
            case SKILLLEVEL.AVERAGE:
                return SKILLLEVEL.ADVANCED;
            case SKILLLEVEL.ADVANCED:
                return SKILLLEVEL.BEGINNER;
            default:
                throw new System.Exception("Unknown SKILLLEVEL encountered: " + _skillLevel.ToString());
        }
    }
}
