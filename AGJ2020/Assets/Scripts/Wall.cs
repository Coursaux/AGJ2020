using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    PlayerController player;
    Head head;
    [SerializeField] float damage = 30f;

    ClipPlayer clipPlayer;
    AudioSource audioSource;

    [SerializeField] AudioClip treeHit;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        clipPlayer = FindObjectOfType<ClipPlayer>();
        audioSource = clipPlayer.GetComponent<AudioSource>();
        FetchHead();
    }
    void Update()
    {
        if (head == null) FetchHead();
    }

    private void FetchHead()
    {
        head = player.head;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (player.GetSpeed() > 0f)
        {
            player.SetSpeed(0f);
            player.SetNegativeSpeed(4f);
        } else if (player.GetNegativeSpeed() > 0)
        {
            player.SetNegativeSpeed(0f);
            player.SetSpeed(4f);
        }
        audioSource.PlayOneShot(treeHit);
        player.GetComponentInChildren<HealthManager>().TakeDamage(damage);

    }
}
