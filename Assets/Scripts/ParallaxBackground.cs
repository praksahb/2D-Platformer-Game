using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraLastPosition;
    public float parallaxFactor;

    //public CameraController cameraController;

    private float deltaMovementHorizontal;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraLastPosition = cameraTransform.position;
    }

    void Update()
    {
        //Debug.Log("delta in parallax script: " + deltaMovementHorizontal);
        Vector3 position = transform.position;
        position.x += parallaxFactor * CameraController.deltaMovementHorizontal;
        transform.position = position;
    }

    void FixedUpdate()
    {

    }

    public void GetDeltaMovement(float value)
    {
        deltaMovementHorizontal = value;
    }

    void LateUpdate()
    {
        //Vector3 deltaMovement = cameraTransform.position - cameraLastPosition;
        //transform.position += deltaMovement * parallaxFactor;
        //cameraLastPosition = cameraTransform.position;
        //Debug.Log("Camera posi: " + cameraTransform.position);
    }
}
