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
        var dir = target.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 40 * Time.deltaTime);
	}
}
