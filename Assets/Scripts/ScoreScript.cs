using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {
    public int fontSize = 15;
    private GUIStyle style = new GUIStyle();

    public void OnGUI()
    {
        style.fontSize = fontSize;
        style.normal.textColor = Color.white;
        GUI.Label(new Rect(10, 10, 100, 20), (PlayerPrefs.GetInt("Score").ToString()), style);
    }
}
