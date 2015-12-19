using UnityEngine;
using System.Collections;

public class CollisionStuff : MonoBehaviour 
{
    public GameObject cliffExplosion;
    public GameObject houseExplosion;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(gameObject.tag == "ammo")
        {
            Destroy(gameObject,0.01f);
        }
        if(gameObject.tag == "cliffs" && coll.gameObject.tag=="ammo")
        {
            GameObject explosionClone;
            explosionClone = (Instantiate(cliffExplosion, coll.gameObject.transform.position, Quaternion.identity)) as GameObject;
            Destroy(explosionClone, 0.3f);
        }
        if (gameObject.tag == "house" && coll.gameObject.tag == "ammo")
        {
            GameObject explosionClone;
            explosionClone = (Instantiate(houseExplosion, coll.gameObject.transform.position, Quaternion.identity)) as GameObject;
            Debug.Log("HERE WE IS");
            Destroy(explosionClone, 0.3f);
        }

    }
}
