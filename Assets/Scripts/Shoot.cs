﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public float bulletLife;
   // private Vector3 newPosition;
    private Vector2 myPos;
    public AudioClip gunSound;
    private AudioSource shot;
    void Start()
    {
        shot = gameObject.GetComponent<AudioSource>();
    }

	// Update is called once per frame
	void Update () 
    {
        myPos = transform.position;
	    if(Input.GetMouseButtonDown(0))
        {
           
            shoot();
        }
	}
    void shoot()
    {
        shot.PlayOneShot(gunSound);
        Vector2 cursorInWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorInWorldPos - myPos;
        direction.Normalize();
        GameObject projectile = (GameObject)Instantiate(bullet, myPos, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction * 400;
        Destroy(projectile, bulletLife);
    }
}
