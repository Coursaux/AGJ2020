using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    PlayerController player;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        WinGame();
    }

    private void WinGame()
    {
        player.SetSpeed(0);
        player.playingGame = false;
        player.head.playingGame = false;
        player.GetComponent<MeteorSpawner>().minTime = Mathf.Infinity;
        player.GetComponent<MeteorSpawner>().maxTime = Mathf.Infinity;
        player.GetComponent<HealthManager>().WinGame();
    }
}
