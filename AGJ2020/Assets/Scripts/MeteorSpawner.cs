using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public float maxTime = 30;
    public float minTime = 10;

    public float spawnHeight = 100;
    public float spawnDistanceRange = 10;

    private float lastSpawn = 0;
    private float nextSpawn = 5;

    public GameObject meteor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawn();
    }

    void spawn()
    {
        nextSpawn = Random.Range(minTime, maxTime);
        if (Time.time > lastSpawn + nextSpawn)
        {
            Vector3 position = transform.position;

            position.x += Random.Range(-spawnDistanceRange, spawnDistanceRange);
            position.y += spawnHeight;

            Instantiate(meteor, position, Quaternion.identity);

            lastSpawn = Time.time;
            nextSpawn = Random.Range(minTime, maxTime);
        }
    }
}
