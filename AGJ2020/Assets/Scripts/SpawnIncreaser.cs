using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIncreaser : MonoBehaviour
{
    PlayerController player;
    MeteorSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spawner = player.GetComponent<MeteorSpawner>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        spawner.minTime = 0.1f;
        spawner.maxTime = 1f;
    }
}
