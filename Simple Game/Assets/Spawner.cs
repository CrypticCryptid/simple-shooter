using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawn <= 0)
        {
            Spawn();
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    void Spawn() {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }
}
