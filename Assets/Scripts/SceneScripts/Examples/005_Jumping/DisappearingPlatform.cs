using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A platform that keeps disappearing then reappearing.
/// </summary>
public class DisappearingPlatform : MonoBehaviour
{
    /// <summary>
    /// The platform.
    /// </summary>
    [SerializeField]
    private GameObject _platform;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappearing());
    }

    /// <summary>
    /// Handles the disappearance and reappearance of the platform.
    /// </summary>
    /// <returns></returns>
    IEnumerator Disappearing()
    {
        while(true)
        {
            _platform.SetActive(true);
            yield return new WaitForSeconds(1f);
            _platform.SetActive(false);
            yield return new WaitForSeconds(3f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
