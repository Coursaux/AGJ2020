using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float damage = 20;

    private CameraFollow camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void OnTriggerEnter(Collider collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.name == "Character")                                                                                                                                                                                                               
        {   
            collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);
        }
        this.gameObject.GetComponent<ParticleSystem>().Play();
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        if (camera != null)
        {
            camera.ShakeCamera(0.5f, 0.05f);
        }
        Destroy(this.gameObject, 2.0f);
        for (int i =0; i <= 4; i++)
            Destroy(this.gameObject.transform.GetChild(i).gameObject);
    }
}
