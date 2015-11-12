using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public float bulletLife;
    public PlayerController hitPoint;

	// Use this for initialization
	void Start () 
    {
        //hitPoint = GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonDown(0))
        {
            shoot();
        }
	}
    void shoot()
    {
        GameObject clone;
        clone = (Instantiate(bullet, transform.position, transform.rotation)) as GameObject;
        Debug.Log("WE HERE");
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(hitPoint.newPosition.x/100, hitPoint.newPosition.y/100));
    

        Destroy(clone, bulletLife);
    }
}
