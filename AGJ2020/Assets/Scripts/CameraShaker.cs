using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;


    public void ShakeCamera(float shakeDuration, float shakeIntensity)
    {
        StartCoroutine(ShakeCoroutine(shakeDuration, shakeIntensity));
    }

    IEnumerator ShakeCoroutine(float shakeDuration, float shakeIntensity)
    {
        Vector3 originalPosition = transform.position;
        while (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
            shakeDuration -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
