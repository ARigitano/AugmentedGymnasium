using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An area in which players can not be dealt any damages.
/// </summary>
public class SafeZone : MonoBehaviour
{
    protected void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerArea")
        {
            other.GetComponent<TrackerCircle>().isSafe = true;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerArea")
        {
            other.GetComponent<TrackerCircle>().isSafe = false;
        }
    }
}
