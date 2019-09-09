using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script of a coin for the scoring scene.
/// </summary>
public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerArea")
        {
            other.GetComponent<TrackerCircle>().score++;
            Destroy(gameObject);
        }
    }
}
