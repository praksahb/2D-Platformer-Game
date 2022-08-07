using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horizontal, vertical;

    //public ParallaxBackground parallaxBackground;

    public int cameraMoveSpeed;

    public static float deltaMovementHorizontal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //move camera horizontally
        Vector3 position = transform.position;
        deltaMovementHorizontal = horizontal * cameraMoveSpeed * Time.deltaTime;
        //Debug.Log("delta in camera script: " + deltaMovementHorizontal);
        position.x += deltaMovementHorizontal;
        transform.position = position;
        //parallaxBackground.GetDeltaMovement(deltaMovementHorizontal);
    }

    public float SendDeltaMovementValue(float value)
    {
        return value;
    }
}
