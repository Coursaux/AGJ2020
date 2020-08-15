using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarPit : MonoBehaviour
{
    public float frictionMultiplier = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
