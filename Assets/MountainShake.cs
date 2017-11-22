using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainShake : MonoBehaviour
{
    public float shakes = 0f;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;
    Vector3 originalPos;
    bool CameraShaking;

    void Start()
    {
        originalPos = gameObject.transform.position;
        CameraShaking = false;
    }

    public void ShakeMountain(float shaking)
    {
        shakes = shaking;
        originalPos = gameObject.transform.position;
        CameraShaking = true;
    }

    void FixedUpdate()
    {

        if (CameraShaking)
        {
            if (shakes > 0)
            {
                gameObject.transform.position = originalPos + Random.insideUnitSphere * Mathf.Clamp(shakeAmount * shakes, 0, 0.5f);
                shakes -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakes = 0f;
                gameObject.transform.position = originalPos;
                CameraShaking = false;
            }
        }

    }
}
