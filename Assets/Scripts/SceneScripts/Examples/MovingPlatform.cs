using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A platforms that keeps moving between several positions.
/// </summary>
public class MovingPlatform : MonoBehaviour
{
    /// <summary>
    /// The platform.
    /// </summary>
    [SerializeField]
    private GameObject _platform;
    /// <summary>
    /// All the position throught which the platform will move.
    /// </summary>
    [SerializeField]
    private GameObject[] _position;
    /// <summary>
    /// Movement speed of the platform.
    /// </summary>
    [SerializeField]
    private float _speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Moving());
    }

    /// <summary>
    /// Handles the movement of the platform.
    /// </summary>
    /// <returns></returns>
    IEnumerator Moving()
    {
        int i = 0;
        while (true)
        { 
            while (_platform.transform.position != _position[i].transform.position)
            { 
                _platform.transform.position = Vector3.MoveTowards(_platform.transform.position, _position[i].transform.position, _speed);
                yield return null;
            }

            Debug.Log("yoyoyoy");

            if (i < _position.Length - 1)
                i++;
            else
                i = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
