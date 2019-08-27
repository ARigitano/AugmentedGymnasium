using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Displays the position of the trackers
/// </summary>
public class TrackersPosition : MonoBehaviour
{
    /// <summary>
    /// Prefab of the position text for a single tracker
    /// </summary>
    [SerializeField]
    private GameObject _textPrefab;
    /// <summary>
    /// List of all the position texts
    /// </summary>
    private List<GameObject> _positionTexts = new List<GameObject>();
       
    /// <summary>
    /// Creates a position text for a new tracker
    /// </summary>
    public void NewPositionText()
    {
        GameObject positionText = Instantiate(_textPrefab, transform.position, transform.rotation);
        positionText.name = "Vive Tracker" + TrackersManager.instance.trackers.Count.ToString();
        positionText.transform.SetParent(this.transform);
        
        _positionTexts.Add(positionText);
    }

    /// <summary>
    /// Removes the position text of a disconnected tracker
    /// </summary>
    public void RemovePositiontext()
    {
        for(int i=0; i<_positionTexts.Count; i++)
        {
            if(_positionTexts[i].name != "TrackersManager.instance.trackers[i].name")
            {
                Destroy(_positionTexts[i].gameObject);
                _positionTexts.RemoveAt(i);
                break;
            }
        }
    }

    private void FixedUpdate()
    {
        //Updates the displayed positions of all the trackers
        for (int i = 0; i < _positionTexts.Count; i++)
        {
            _positionTexts[i].GetComponent<Text>().text = TrackersManager.instance.trackers[i].name + "\nx=" 
                + TrackersManager.instance.trackers[i].transform.position.x.ToString() + " " 
                + "y=" + TrackersManager.instance.trackers[i].transform.position.y.ToString() + " " 
                + "z=" + TrackersManager.instance.trackers[i].transform.position.z.ToString();
        }
    }
}
