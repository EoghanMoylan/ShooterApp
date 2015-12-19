using UnityEngine;
using System.Collections;

public class EnemyAttacker : MonoBehaviour
{
    public GameObject target;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 5 * Time.deltaTime);

        Debug.Log(transform.position);
	}
}
