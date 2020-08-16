using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    PlayerController player;

    ClipPlayer clipPlayer;
    AudioSource audioSource;

    [SerializeField] AudioClip winSound;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        clipPlayer = FindObjectOfType<ClipPlayer>();
        audioSource = clipPlayer.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        WinGame();
    }

    private void WinGame()
    {
        player.SetSpeed(0);
        audioSource.PlayOneShot(winSound);
        player.playingGame = false;
        player.head.playingGame = false;
        player.GetComponent<MeteorSpawner>().minTime = Mathf.Infinity;
        player.GetComponent<MeteorSpawner>().maxTime = Mathf.Infinity;
        player.GetComponent<HealthManager>().WinGame();
    }
}
