using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraLastPosition;
    public float parallaxFactor;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraLastPosition = cameraTransform.position;
    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - cameraLastPosition;
        transform.position += deltaMovement * parallaxFactor;
        cameraLastPosition = cameraTransform.position;
    }
}
