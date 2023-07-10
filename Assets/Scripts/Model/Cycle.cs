using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cycle
{
    Cyclist _rider;

    RidingSkills.SKILLLEVEL _minimumSkillLevel;
    public RidingSkills.SKILLLEVEL MinimumSkillLevel
    {
        get
        {
            return _minimumSkillLevel;
        }
        set
        {
            _minimumSkillLevel = value;
        }
    }

    /// <summary>
    /// Attempts to put the 'rider' on the bike.
    /// </summary>
    /// <param name="rider"></param>
    /// <returns>true if rider can mount the bikes, false if not</returns>
    public virtual bool Mount(Cyclist rider)
    { 

        if (rider.RidingSkills.SkillLevel >= MinimumSkillLevel)
        {
            _rider = rider;

            return true;
        }
        else
        {
            return false;
        }

    }

    public virtual void Dismount()
    {

        _rider = null;

    }
}
