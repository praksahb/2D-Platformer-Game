using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horizontal, vertical;

    //public ParallaxBackground parallaxBackground;

    public int cameraMoveSpeed;

    public static float deltaMovementHorizontal;
    public static float deltaMovementVertical;

    public static Vector3 deltaMovement;

    // Start is called before the first frame update
    void Start()
    {
        deltaMovement = new Vector3(deltaMovementHorizontal, deltaMovementVertical, deltaMovement.z);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //move camera horizontally
        Vector3 position = transform.position;
        deltaMovementHorizontal = horizontal * cameraMoveSpeed * Time.deltaTime;
        deltaMovementVertical = vertical * cameraMoveSpeed * Time.deltaTime;
        //Debug.Log("delta in camera script: " + deltaMovementHorizontal);
        position += new Vector3(deltaMovementHorizontal, deltaMovementVertical);
        transform.position = position;
        //parallaxBackground.GetDeltaMovement(deltaMovementHorizontal);
    }

    public float SendDeltaMovementValue(float value)
    {
        return value;
    }
}
