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
        player.GetComponent<HealthManager>().WinGame();
    }
}
