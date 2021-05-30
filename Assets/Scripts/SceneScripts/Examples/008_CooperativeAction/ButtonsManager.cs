using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the buttons for a cooperative action door.
/// </summary>
public class ButtonsManager : MonoBehaviour
{
    /// <summary>
    /// The door gameObject.
    /// </summary>
    [SerializeField]
    private GameObject _door;
    /// <summary>
    /// List of all the buttons required for the opening of the door.
    /// </summary>
    private CooperativeButton[] _buttons;
    /// <summary>
    /// Number of buttons pressed so far.
    /// </summary>
    public int nbButtonsPressed = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _buttons = GameObject.FindObjectsOfType<CooperativeButton>();
    }

    /// <summary>
    /// Checks if the door can be opened.
    /// </summary>
    public void OpenDoor()
    {
        nbButtonsPressed++;

        if(nbButtonsPressed >= _buttons.Length)
        {
            _door.SetActive(false);
        }
    }

    /// <summary>
    /// Closes the door.
    /// </summary>
    public void CloseDoor()
    {
        nbButtonsPressed--;

        _door.SetActive(true);
    }
}
