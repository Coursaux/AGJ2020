using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    CameraShaker cameraShaker;

    bool cameraShaking = false;


    private void Start()
    {
        cameraShaker = GetComponentInChildren<CameraShaker>();
    }
    // Update is called once per frame
    void Update()
    {
            Vector3 targetPosition = target.TransformPoint(0, 2, -20);
            if (targetPosition.y < 0)
            {
                targetPosition.y = 0;
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

    }

    public void ShakeCamera(float shakeDuration, float shakeIntensity)
    {
        cameraShaker.ShakeCamera(shakeDuration, shakeIntensity);
    }
}