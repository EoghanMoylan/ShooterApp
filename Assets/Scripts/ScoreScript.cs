using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

    public void OnGUI()
    {
        GUILayout.Label((PlayerPrefs.GetInt("Score").ToString()));
    }
}
