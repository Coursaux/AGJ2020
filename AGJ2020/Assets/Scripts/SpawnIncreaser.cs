using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIncreaser : MonoBehaviour
{
    PlayerController player;
    MeteorSpawner spawner;

    [SerializeField] float minTime;
    [SerializeField] float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        spawner = player.GetComponent<MeteorSpawner>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        spawner.minTime = minTime;
        spawner.maxTime = maxTime;
    }
}
