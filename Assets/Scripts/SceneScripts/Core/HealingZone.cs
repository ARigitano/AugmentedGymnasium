using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An area in which players can stay in to regain their life points over time.
/// </summary>
public class HealingZone : MonoBehaviour
{
    /// <summary>
    /// The speed at which the players regain their life points.
    /// </summary>
    [SerializeField]
    private int _speed = 1;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerArea" && other.GetComponent<TrackerCircle>().life < other.GetComponent<TrackerCircle>(). lifeMax)
        {
            other.GetComponent<TrackerCircle>().life += _speed;
        } 
    }
}
