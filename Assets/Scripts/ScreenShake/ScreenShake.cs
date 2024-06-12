using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{

    public static ScreenShake screenShake;
    public float shakeDuration;
    private float currentShakeDuration;
    private Vector3 originalPosition;
    private float shakeIntensity;

    void Start()
    {
        currentShakeDuration = shakeDuration;
        originalPosition = transform.localPosition;
    }

    private void Awake()
    {
        screenShake = this;
    }

    private void Update()
    {

        if (currentShakeDuration > 0)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * shakeIntensity;

            transform.localPosition = originalPosition + shakeOffset;

            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0f;
            transform.localPosition = originalPosition;
        }
    }

    public void ShakeScreen(float intensity, float duration)
    {
        shakeIntensity = intensity;
        currentShakeDuration = duration;
        shakeDuration = duration;
    }
}


