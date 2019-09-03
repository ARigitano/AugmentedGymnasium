using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects if the player is on a platform or falling into the void.
/// </summary>
public class PlatformDetection : MonoBehaviour
{
    /// <summary>
    /// Layer for the platforms.
    /// </summary>
    [SerializeField]
    private LayerMask _platformLayer;
    /// <summary>
    /// Layer for the void.
    /// </summary>
    [SerializeField]
    private LayerMask _voidLayer;
    /// <summary>
    /// Void gameobject.
    /// </summary>
    [SerializeField]
    private GameObject _void;
    /// <summary>
    /// Height between the void and the feet of the player at the beginning of the game.
    /// </summary>
    private float _originalDistance;
    /// <summary>
    /// Height of a jump.
    /// </summary>
    [SerializeField]
    private float _jump = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _originalDistance = Mathf.Pow(this.gameObject.transform.position.z + _void.transform.position.z, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, 50, _platformLayer))
        {
            Debug.Log("Player is on platform.");
        }
        else if (Physics.Raycast(transform.position, forward, out hit, 50, _voidLayer))
        {
            Debug.Log("Player is not on platform.");

            float currentDistance = Mathf.Pow(this.gameObject.transform.position.z + _void.transform.position.z, 2f);

            if (currentDistance <= _originalDistance + _jump)
            {
                Debug.Log("Player is losing score.");
                GetComponent<TrackerCircle>().score--;
            }
            else
            {
                Debug.Log("Not losing score.");
            }
        }
    }
}
