using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    bool cameraShaking = false;


    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (!cameraShaking)
        {
            Vector3 targetPosition = target.TransformPoint(0, 2, -10);
            if (targetPosition.y < 0)
            {
                targetPosition.y = 0;
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        
    }

    public void ShakeCamera(float shakeDuration, float shakeIntensity)
    {
        StartCoroutine(ShakeCoroutine(shakeDuration, shakeIntensity));
    }

    IEnumerator ShakeCoroutine(float shakeDuration, float shakeIntensity)
    {
        cameraShaking = true;
        while(shakeDuration > 0)
        {
            transform.position = transform.position + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        cameraShaking = false;
    }
}