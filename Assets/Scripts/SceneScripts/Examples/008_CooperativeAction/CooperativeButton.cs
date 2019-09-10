using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// One of the buttons required to open a door.
/// </summary>
public class CooperativeButton : MonoBehaviour
{
    /// <summary>
    /// The buttons manager.
    /// </summary>
    private ButtonsManager _manager;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.FindObjectOfType<ButtonsManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerArea")
        {
            _manager.OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerArea")
        {
            _manager.CloseDoor();
        }
    }
}
