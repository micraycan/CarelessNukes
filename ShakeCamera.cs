using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private float shakeDuration;
    private float shakeMagnitude = 0.1f;
    private float dampingSpeed = 2f;
    private Vector3 initialPosition;

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime * dampingSpeed;
        } else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void ScreenShake()
    {
        shakeDuration = 2f;
    }
}
