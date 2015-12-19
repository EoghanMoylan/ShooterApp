using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
    public GameObject spawners;
    private int spawnRate = 300;
    private int counter = 1;
    void Start()
    {
        switch (PlayerPrefs.GetInt("WaveNumber"))
        {
            case 1:
                spawnRate = 250;
                break;
            case 2:
                spawnRate = 200;
                break;
            case 3:
                spawnRate = 180;
                break;
            case 4:
                spawnRate = 150;
                break;
            case 5:
                spawnRate = 120;
                break;
            case 6:
                spawnRate = 110;
                break;
            case 7:
                spawnRate = 100;
                break;
            case 8:
                spawnRate = 90;
                break;
            case 9:
                spawnRate = 70;
                break;
            case 10:
                spawnRate = 60;
                break;
            default:
                spawnRate = 300;
                break;
        }
    }
	void Update () 
    {
        if (counter == spawnRate)
        {
            GameObject clone;
            clone = (Instantiate(spawners, transform.position, transform.rotation)) as GameObject;
            clone.ToString();
            counter = 0;
        }
        counter++;
	}
}
