using UnityEngine;
using System.Collections;

public class CollisionStuff : MonoBehaviour 
{
    public GameObject cliffExplosion;
    public GameObject houseExplosion;
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(gameObject.tag == "Ammo")
        {
            Destroy(gameObject,0.01f);
        }
        if(gameObject.tag == "cliffs" && coll.gameObject.tag=="Ammo")
        {
            GameObject explosionClone;
            explosionClone = (Instantiate(cliffExplosion, coll.gameObject.transform.position, Quaternion.identity)) as GameObject;
            Destroy(explosionClone, 0.3f);
        }
        if (gameObject.tag == "house" && coll.gameObject.tag == "Ammo")
        {
            GameObject explosionClone;
            explosionClone = (Instantiate(houseExplosion, coll.gameObject.transform.position, Quaternion.identity)) as GameObject;
            Destroy(explosionClone, 0.3f);
        }

    }
}
