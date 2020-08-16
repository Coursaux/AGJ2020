                        using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float damage = 0.5f;

    ClipPlayer clipPlayer;
    AudioSource audioSource;

    [SerializeField] AudioClip fireBurn;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = fireBurn;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Character")
        {   
            collision.gameObject.GetComponentInChildren<HealthManager>().TakeDamage(damage);
        }
    }
}
