using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float damage = 30;

    private CameraFollow camera;

    ClipPlayer clipPlayer;
    AudioSource audioSource;

    [SerializeField] AudioClip meteorCrash;
    [SerializeField] AudioClip meteorFall;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main.GetComponent<CameraFollow>();
        clipPlayer = FindObjectOfType<ClipPlayer>();
        audioSource = clipPlayer.GetComponent<AudioSource>();
        audioSource.PlayOneShot(meteorFall);
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
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        if (camera != null)
        {
            camera.ShakeCamera(0.5f, 0.05f);
            audioSource.PlayOneShot(meteorCrash);
        }
        Destroy(this.gameObject, 2.0f);
        for (int i =0; i < gameObject.transform.childCount; i++)
            Destroy(this.gameObject.transform.GetChild(i).gameObject);
    }
}
