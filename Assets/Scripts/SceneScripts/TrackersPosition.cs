using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackersPosition : MonoBehaviour
{

    private List<Text> positionTexts = new List<Text>();
       
    public void NewPositionText()
    {
        GameObject positionText = new GameObject("ViveTrackerPosition");
        positionText.transform.SetParent(this.transform);
        positionText.transform.position = new Vector3(0f, 0f, 0f);

        Text newText = positionText.AddComponent<Text>();
        newText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        newText.color = Color.black;
        newText.text = "ViveTracker";
        positionTexts.Add(newText);
    }

    private void Update()
    {

    }
}
