using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beattimer
{
    private int beatStep;
    private int beatTimeCounter = 0;
    private bool beatCopy;

    public void setBeatStep (int bS)
    {
        beatStep = bS;
    }

    public bool onBeat(bool currentBeat)
    {
        if (beatStep > 0)
        {
            if (currentBeat != beatCopy)
            {
                beatTimeCounter++;
            }

            beatCopy = currentBeat;

            Debug.Log("Counter: " + beatTimeCounter);
            if (beatTimeCounter == beatStep)
            {
                beatTimeCounter = 0;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            beatTimeCounter = 0;
            return false;
        }
    }



}
