using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Unicycle : Cycle // INHERITANCE
{
    public Unicycle()
    {
        MinimumSkillLevel = RidingSkills.SKILLLEVEL.ADVANCED;
    }
}
