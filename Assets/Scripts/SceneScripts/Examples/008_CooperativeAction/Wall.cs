using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A wall the players can not cross.
/// </summary>
public class Wall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerArea")
        {
            other.gameObject.SetActive(false);
        }
    }
}
