using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicycle : Cycle
{


    /// <summary>
    /// Attempts to put the 'rider' on the bike.
    /// </summary>
    /// <param name="rider"></param>
    /// <returns>true if rider can mount the bikes, false if not</returns>
    public override bool Mount(Cyclist rider) {
        // bwd verify rider has the skill for this Cycle.

        return true;

    }


}
