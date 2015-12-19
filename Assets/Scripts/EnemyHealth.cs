using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health = 3;
	// Update is called once per frame
	void Update () 
    {
        if(health == 0)
        {
            StartCoroutine(Die());
        }
	
	}
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ammo")
        {
            health--;
        }
    }
    IEnumerator Die()
    {
        int score = PlayerPrefs.GetInt("Score");
        score += 10;
        PlayerPrefs.SetInt("Score", score);
        //Saves the current score and level to be used in the "death scene"
        yield return new WaitForSeconds(0.2f);
        // Restart the level when the music is finished.
        Destroy(gameObject);
    }
}
