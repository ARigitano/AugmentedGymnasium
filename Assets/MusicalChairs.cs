using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicalChairs : MonoBehaviour
{
    private int _nbChairs = 8;
    [SerializeField]
    private GameObject _chairPrefab;
    [SerializeField]
    private float _radius = 5f;
    /// <summary>
    /// Layer of the ground
    /// </summary>
    [SerializeField]
    private LayerMask _ground;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _nbChairs; i++)
        {
            float angle = i * Mathf.PI * 2f / _nbChairs;
            Vector3 position = new Vector3(Mathf.Cos(angle) * _radius, Mathf.Sin(angle) * _radius, transform.position.y);
            GameObject chair = Instantiate(_chairPrefab, position, Quaternion.identity);
            StickGround(chair);
        }
    }

    /// <summary>
    /// Object will position itself on the ground.
    /// </summary>
    private void StickGround(GameObject mesh)
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit, 50, _ground))
        {
            mesh.transform.position = new Vector3(mesh.transform.position.x, mesh.transform.position.y, hit.collider.transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
