using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclist
{

    private RidingSkills _ridingSkills = new RidingSkills();

    // ENCAPSULATION
    public RidingSkills RidingSkills { get { return _ridingSkills; } set { _ridingSkills = value; } }

    public Cyclist(RidingSkills.SKILLLEVEL initialSkill = RidingSkills.SKILLLEVEL.BEGINNER) {
        _ridingSkills.SkillLevel = initialSkill;
    }
}
