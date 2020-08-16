using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarPit : MonoBehaviour
{
    public float frictionMultiplier = 1.1f;

    ClipPlayer clipPlayer;
    AudioSource audioSource;

    [SerializeField] AudioClip tarWalk;

    // Start is called before the first frame update
    void Start()
    {
        clipPlayer = FindObjectOfType<ClipPlayer>();
        audioSource = clipPlayer.GetComponent<AudioSource>();
    }

    void OnTriggerStay(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Character")
        {   
            PlayerController controller = collision.gameObject.GetComponent<PlayerController>();
            SlowCharacter(controller);
        }
    }

    void SlowCharacter(PlayerController controller)
    {
        float speed = controller.GetSpeed();
        float negativeSpeed = controller.GetNegativeSpeed();

        if (speed == controller.maxSpeed || negativeSpeed == controller.maxSpeed)
            return;

        controller.SetSpeed(speed/frictionMultiplier);
        controller.SetNegativeSpeed(negativeSpeed/frictionMultiplier);

        if (speed == 0)
        {
            controller.gameObject.GetComponent<HealthManager>().TakeDamage(0.5f);
        } else
        {
            audioSource.PlayOneShot(tarWalk);
        }
    }
}
