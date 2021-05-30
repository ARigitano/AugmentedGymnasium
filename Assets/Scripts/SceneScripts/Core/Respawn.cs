using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A zone in which a dead player can go to respawn.
/// </summary>
public class Respawn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerArea")
        {
            other.GetComponent<TrackerCircle>().life = other.GetComponent<TrackerCircle>().lifeMax;
        }
    }
}
