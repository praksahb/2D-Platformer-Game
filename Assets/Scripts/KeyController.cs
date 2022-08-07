using UnityEngine;

public class KeyController : MonoBehaviour
{
    private Animator keyAnimator;
    private bool isKeyReadyToMove = false;
    private int moveKeyUpwards = 2;
   

    private void Awake()
    {
        keyAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isKeyReadyToMove)
            MoveKeyUpwards();
    }
    private void MoveKeyUpwards()
    {
        //move character horizontally
        Vector3 position = transform.position;
        position.y += moveKeyUpwards * Time.deltaTime;
        transform.position = position;
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerController playerController = collider.gameObject.GetComponent<PlayerController>();
        if(playerController != null)
        {
            keyAnimator.SetBool("isCollected", true);
            //move key upwards
            isKeyReadyToMove = true;
            playerController.PickUpKey();
            //destroy key after 0.5 seconds
            Destroy(gameObject, 0.5f);
        }
    }
}
