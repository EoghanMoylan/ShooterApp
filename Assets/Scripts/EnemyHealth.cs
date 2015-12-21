using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int health = 3;
    public GameObject deathExplosion;
    public GameObject healthBar;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        if(PlayerPrefs.GetInt("isAlliance") == 1)
        {
            anim.SetBool("isAlliance", true);
        }
        else
        {
            anim.SetBool("isAlliance", false);
        }
    }
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
            UpdateHealthBar(0.33f);
            anim.SetTrigger("isDamaged");
        }
    }
    private void UpdateHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(healthBar.transform.localScale.x - myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }
    IEnumerator Die()
    {
        int score = PlayerPrefs.GetInt("Score");
        score += 10;
        PlayerPrefs.SetInt("Score", score);
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        GameObject explosionClone;
        explosionClone = (Instantiate(deathExplosion, this.gameObject.transform.position, Quaternion.identity)) as GameObject;
        Destroy(explosionClone, 0.3f);
        yield return new WaitForSeconds(0.3f);
        // Restart the level when the music is finished.
        Destroy(gameObject);
    }
}
