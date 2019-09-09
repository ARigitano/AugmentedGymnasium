using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _door;
    private CooperativeButton[] _buttons;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _buttons = GameObject.FindObjectsOfType<CooperativeButton>();
    }

    public void OpenDoor()
    {
        if()
    }
}
