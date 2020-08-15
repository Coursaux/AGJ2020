using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public float tiltFactor = 1f;
    [SerializeField] float upAcceleration = 0.001f;
    [SerializeField] float downAcceleration = 0.001f;

    [SerializeField] float randomFactor = 0.5f;
    [SerializeField] float speedFactor = 0.1f;

    float currentUpAcceleration = 0f;
    float currentDownAcceleration = 0f;


    // Start is called before the first frame update
    void Start()                                                                                                 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTiltFactor();
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0f, 0f, -90f), Quaternion.Euler(0f, 0f, 90f), tiltFactor);
    }

    private void UpdateTiltFactor()
    {
        ProcessTiltInput();
        AddRandomTilt();
        AddSpeedTilt();
        tiltFactor += (currentDownAcceleration - currentUpAcceleration) * Time.deltaTime;
        tiltFactor = Mathf.Clamp(tiltFactor, 0f, 1f);
        currentUpAcceleration = Mathf.Clamp(currentUpAcceleration, -1f, 1f);
        currentDownAcceleration = Mathf.Clamp(currentDownAcceleration, -1f, 1f);
    }

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

    private void AddSpeedTilt()
    {
        //float speed = FindObjectOfType<Legs>().GetSpeedFactor(); float between -1f and 1f;
        float speed = 0f;
        float randomSpeedValue = 0f;
        if (speed > 0)
        {
            randomSpeedValue = Random.Range(0f, speed);
        }
        else
        {
            randomSpeedValue = Random.Range(speed, 0f);
        }
        tiltFactor += randomSpeedValue * speedFactor;
    }

    public float GetTiltFactor() // returns value between 0 and 1;
    {
        return tiltFactor;
    }

}
