using UnityEngine;
using System.Collections;

public class Clickable : MonoBehaviour
{
    public bool isAlliance;

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            Vector2 mousePointer = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(transform.position,mousePointer) < 1)
            {

                if (isAlliance)
                {
                    PlayerPrefs.SetInt("isAlliance", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("isAlliance", 0);
                }

                Application.LoadLevel("Main");
            }
                
        }
    }
}
