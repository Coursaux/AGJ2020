using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    bool cameraShaking;

    public void ShakeCamera(float shakeDuration, float shakeIntensity)
    {
        StartCoroutine(ShakeCoroutine(shakeDuration, shakeIntensity));
    }

    IEnumerator ShakeCoroutine(float shakeDuration, float shakeIntensity)
    {
        cameraShaking = true;
        Vector3 originalPosition = transform.position;
        while (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        cameraShaking = false;
    }
}
