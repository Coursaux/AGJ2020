using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWall : MonoBehaviour
{
    public PlayerController player;
    Head head;

    public bool isBreakable;

    [SerializeField] float requiredSpeed = 1f;
    [SerializeField] float requiredTilt = 0.65f;
    [SerializeField] float damage = 30f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        FetchHead();
        isBreakable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (head == null) FetchHead();
        UpdateBreakable();
    }

    private void FetchHead()
    {
        head = player.head;
    }

    private void UpdateBreakable()
    {
        if (isBreakable)
        {
            if (player.GetSpeed() < requiredSpeed || head.GetTilt() > requiredTilt)
            {
                isBreakable = false;
            }
        } else
        {
            if (player.GetSpeed() >= requiredSpeed && head.GetTilt() <= requiredTilt)
            {
                isBreakable = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBreakable)
        {
            player.SetSpeed(player.GetSpeed() / 1.5f);
            Destroy(gameObject);

        } else
        {
            player.SetSpeed(0);
            player.SetNegativeSpeed(4);
            player.GetComponent<HealthManager>().TakeDamage(damage);
        }
    }
}
