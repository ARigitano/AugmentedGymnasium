using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A chair for the musical chairs game.
/// </summary>
public class Chair : MonoBehaviour
{
    /// <summary>
    /// List of the players on the chair.
    /// </summary>
    List<GameObject> _occupants = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerArea" && _occupants.Count == 0 && MusicalChairs.instance.canSit)
        {
            other.GetComponent<TrackerCircle>().isSafe = true;
            _occupants.Add(other.gameObject);
            MusicalChairs.instance.safeChairs++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerArea")
        {
            other.GetComponent<TrackerCircle>().isSafe = false;
        }
    }
}
