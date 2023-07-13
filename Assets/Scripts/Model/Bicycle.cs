using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bicycle : Cycle // INHERITANCE
{
    public Bicycle()
    {
        MinimumSkillLevel = RidingSkills.SKILLLEVEL.AVERAGE;
    }
}
