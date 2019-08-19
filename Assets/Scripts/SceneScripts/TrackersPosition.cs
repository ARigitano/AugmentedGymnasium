using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackersPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject _textPrefab;
    private List<GameObject> _positionTexts = new List<GameObject>();
       
    public void NewPositionText()
    {
        GameObject positionText = Instantiate(_textPrefab, transform.position, transform.rotation);
        positionText.name = "Vive Tracker" + TrackersManager.instance.trackers.Count.ToString();
        positionText.transform.SetParent(this.transform);
        
        _positionTexts.Add(positionText);
    }

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
        for (int i = 0; i < _positionTexts.Count; i++)
        {
            _positionTexts[i].GetComponent<Text>().text = TrackersManager.instance.trackers[i].name + "\nx=" 
                + TrackersManager.instance.trackers[i].transform.position.x.ToString() + " " 
                + "y=" + TrackersManager.instance.trackers[i].transform.position.y.ToString() + " " 
                + "z=" + TrackersManager.instance.trackers[i].transform.position.z.ToString();
        }
    }
}
