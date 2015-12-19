using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float lerpinLad =0;
    private float destinationDistance = 0;
    public GameObject federationSpawnPoint;
    public GameObject allianceSpawnPoint;
    public bool facingRight = true;
    private int health = 1;
    Animator anim;
    Vector3 newPosition;

    void Start()
    {
        newPosition = transform.position;
        anim = GetComponent<Animator>();
        Input.simulateMouseWithTouches = true;
        if (PlayerPrefs.GetInt("isAlliance") == 1)
        {
            anim.SetBool("isAlliance", true);
        }
        else
        {
            anim.SetBool("isAlliance", false);
        }

        if(anim.GetBool("isAlliance")==true)
        {
            transform.position = allianceSpawnPoint.transform.position;
        }
        else
        {
            transform.position = federationSpawnPoint.transform.position;
        }
	}

	void FixedUpdate () 
    {
        destinationDistance = (transform.position.x - newPosition.x);
        if(health == 0)
        {
            StartCoroutine(Die());
        }

        if (destinationDistance > 0 && !facingRight)
        {
            Flip();
        }
        else if (destinationDistance < 0 && facingRight)
        {
            Flip();
        }
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                anim.SetBool("isMoving", true);
                newPosition = hit.point;
                transform.position =  Vector3.MoveTowards(transform.position, newPosition,Mathf.Abs((lerpinLad*destinationDistance)/50));
                Vector3 pos = transform.position;
                pos.z = 0;
                transform.position = pos;
            }
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
	}
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            health--;
        }
    }
    IEnumerator Die()
    {
        //Saves the current score and level to be used in the "death scene"
        yield return new WaitForSeconds(2);
        // Restart the level when the music is finished.
        Application.LoadLevel("GameOver");
    }
}