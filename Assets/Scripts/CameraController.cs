using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float horizontal, vertical;

    public int cameraMoveSpeed;

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
        position.x += horizontal * cameraMoveSpeed * Time.deltaTime;
        transform.position = position;
    }
}
