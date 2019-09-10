using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 2D circle displayed at the feet of the player.
/// </summary>
public class TrackerCircle : MonoBehaviour
{
    /// <summary>
    /// Image of the circle
    /// </summary>
    [SerializeField]
    private Image _circle;
    /// <summary>
    /// Layer of the ground
    /// </summary>
    [SerializeField]
    private LayerMask _ground;
    /// <summary>
    /// Has the player's area been deactivated?
    /// </summary>
    public bool isActive = true;
    /// <summary>
    /// Can the player's area be deactivated after a certain condition is met?
    /// </summary>
    public bool isSafe = false;
    /// <summary>
    /// Displays the life of the player.
    /// </summary>
    [SerializeField]
    private Text _lifeText;
    /// <summary>
    /// Life of the player.
    /// </summary>
    public int life = 1000;
    /// <summary>
    /// Maximum life points the players can have.
    /// </summary>
    public int lifeMax = 1000;
    /// <summary>
    /// Displays the score of the player.
    /// </summary>
    [SerializeField]
    private Text _scoreText;
    /// <summary>
    /// Score of the player.
    /// </summary>
    public int score = 0;
    /// <summary>
    /// Is the player alive?
    /// </summary>
    public bool isAlive = true;

    // Start is called before the first frame update
    void Awake()
    {
        _circle.color = new Color(Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f, Random.Range(0, 255) / 255f);

        StickGround(this.gameObject);
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

    private void Update()
    {
        if (_lifeText != null)
        {
            if (life > 0)
                _lifeText.text = life.ToString();
            else
                _lifeText.text = "DEAD";

           
        }

        if (life > 0)
        {
            isAlive = true;
            _circle.enabled = true;
        }
        else
        {
            isAlive = false;
            _circle.enabled = false;
        }

        if(_scoreText != null)
        {
            _scoreText.text = score.ToString();
        }
    }
}
