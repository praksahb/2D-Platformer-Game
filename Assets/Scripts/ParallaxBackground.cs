using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraLastPosition;
    public Vector2 parallaxFactor;

    //public CameraController cameraController;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraLastPosition = cameraTransform.position;
    }

    void Update()
    {
        //ApplyDeltaValues();
    }

    void LateUpdate()
    {
        MoveGameObject();
    }

    private void MoveGameObject()
    {
        Vector3 deltaMovement = cameraTransform.position - cameraLastPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor.x, deltaMovement.y * parallaxFactor.y);
        cameraLastPosition = cameraTransform.position;
    }

    //modify transform values of gameObject
    private void ApplyDeltaValues()
    {
        Vector3 position = transform.position;
        position += ModifyDeltaValues(PlayerController.PlayerDeltaMovement);
        transform.position = position;
    }

    Vector3 ModifyDeltaValues(Vector3 delta)
    {
        //delta = PlayerController.PlayerDeltaMovement;
        delta.x *= parallaxFactor.x;
        delta.y *= parallaxFactor.y;
        return delta;
    }


}
