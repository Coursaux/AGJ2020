using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float tiltFactor = 0.5f;
    [SerializeField] float upAcceleration = 0.001f;
    [SerializeField] float downAcceleration = 0.001f;

    [SerializeField] float speedFactor = 0.1f;

    public float currentUpAcceleration = 0f;
    public float currentDownAcceleration = 0f;

    HealthManager healthManager;
    [SerializeField] float tiltDamage = 0.5f;


    // Start is called before the first frame update
    void Start()                                                                                                 
    {
        healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTiltFactor();
        CheckTiltDamage();
        //applies the tilt factor to the head
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, -90f), Quaternion.Euler(0f, 0f, 90f), tiltFactor);
    }

    private void UpdateTiltFactor()
    {
        ProcessTiltInput();
        AddRandomTilt();
        AddSpeedTilt();
        tiltFactor += (currentUpAcceleration - currentDownAcceleration) * Time.deltaTime;
        tiltFactor = Mathf.Clamp(tiltFactor, 0f, 0.9f);
        currentUpAcceleration = Mathf.Clamp(currentUpAcceleration, -1f, 1f);
        currentDownAcceleration = Mathf.Clamp(currentDownAcceleration, -1f, 1f);
    }

    //Calculates acceleration from up and down arrow keys
    private void ProcessTiltInput()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentUpAcceleration -= upAcceleration;
            currentDownAcceleration += downAcceleration;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            currentDownAcceleration -= downAcceleration;
            currentUpAcceleration += upAcceleration;

        }
        else
        {
            currentDownAcceleration -= downAcceleration;
            currentUpAcceleration -= upAcceleration;
        }
    }

    //adds a bit of randomness to whatever the direction the head is already tilting
    private void AddRandomTilt()
    {
        if (currentDownAcceleration > currentUpAcceleration)
        {
            currentDownAcceleration += Random.Range(0f, downAcceleration);
        }
        else if (currentUpAcceleration > currentDownAcceleration)
        {
            currentUpAcceleration += Random.Range(0f, upAcceleration);
        }
    }

    //takes the speed from the legs to tilt the head
    private void AddSpeedTilt()
    {
        float speed = FindObjectOfType<PlayerController>().GetSpeedFactor();
        float randomSpeedValue = 0f;
        if (speed > 0)
        { 
            randomSpeedValue = Random.Range(0f, speed);
        }
        else
        {
            randomSpeedValue = Random.Range(speed, 0f);
        }
        tiltFactor -= ((randomSpeedValue) * speedFactor);
    }

    //damages the player if the head is tilted all the way down
    private void CheckTiltDamage()
    {
        if (tiltFactor == 0)
        {
            healthManager.TakeDamage(tiltDamage);
        }
    }
    
    // returns value between 0 and 1;
    public float GetTilt() 
    {
        return tiltFactor;                                                          
    }

}
