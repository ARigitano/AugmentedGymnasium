using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base script for an attack for the dungeon boss.
/// </summary>
public class Attack : MonoBehaviour
{
    /// <summary>
    /// Material of the attack.
    /// </summary>
    protected Material _material;
    /// <summary>
    /// Speed of the attack's effect.
    /// </summary>
    [SerializeField]
    private float _attackSpeed = 0.0001f;
    /// <summary>
    /// Is the attack ready to deal damages?
    /// </summary>
    public bool isReady = false;
    /// <summary>
    /// The amount of damage this attack causes.
    /// </summary>
    protected int damages = 200;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _material = GetComponent<MeshRenderer>().material;
        StartCoroutine(AttackBuilding());
    }

    /// <summary>
    /// Pebuilds the attack.
    /// </summary>
    /// <returns></returns>
    protected IEnumerator AttackBuilding()
    {
        float red = 255f;
        float green = 255f;
        float blue = 255f;

        while (green >= 0f)
        {
            _material.SetColor("_Color", new Color(red / 255f, green / 255f, blue / 255f));
            green--;
            blue--;

            yield return new WaitForSeconds(_attackSpeed);
        }

        isReady = true;
    }

    protected void OnTriggerStay(Collider other)
    {
        if(other.tag == "PlayerArea" && isReady && !other.GetComponent<TrackerCircle>().isSafe)
        {
            other.GetComponent<TrackerCircle>().life -= damages;
        }
    }
}
