using UnityEngine;
using System.Collections;

public class CapitalHealth : MonoBehaviour {

    //determines the capital ship script is attached to is alliance
    public bool weAreAlliance;
    //determines if player is alliance
    private bool isAlliance;
    public GameObject healthBar;
    public int health = 100;
    public GameObject deathExplosion;
	
	// Update is called once per frame
	void Update () 
    {
        if (PlayerPrefs.GetInt("isAlliance") == 1)
        {
            isAlliance = true;
        }
        else
        {
            isAlliance = false;
        }
	  if(health == 0)
        {
            StartCoroutine(Die());
        }
	
	}
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(weAreAlliance != isAlliance)
        {
            if (coll.gameObject.tag == "Ammo")
            {
                health--;
                UpdateHealthBar(0.01f);
            }
        }
        
    }
    private void UpdateHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    IEnumerator Die()
    {
        //Saves the current score and level to be used in the "death scene"
        int score = PlayerPrefs.GetInt("Score");
        score += 500;
        PlayerPrefs.SetInt("Score", score);
        GameObject explosionClone;
        explosionClone = (Instantiate(deathExplosion, gameObject.transform.position, Quaternion.identity)) as GameObject;
        Destroy(explosionClone, 0.3f);
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
        int waveNumber = PlayerPrefs.GetInt("WaveNumber");
        waveNumber++;
        PlayerPrefs.SetInt("WaveNumber", waveNumber);
        Application.LoadLevel("Main");
    }
}
