using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    private Vector3 cameraLastPosition;
    public Vector2 parallaxFactor;

    private Vector2 backgroundParallaxFactor;
    private Vector2 midgroundParallaxFactor;
    private Vector2 cloudParallaxFactor;

    //public CameraController cameraController;

    void Awake()
    {
        SetParallaxFactorAccordingToLayerOrder();
    }

    private void SetParallaxFactorAccordingToLayerOrder()
    {
        switch (gameObject.layer)
        {
            case 20:
                //will follow camera
                parallaxFactor.Set(1f, 1f);
                break;
            case 12:
                //clouds
                parallaxFactor.Set(0.8f, 0.4f);
                break;
            case 10:
                //distant mountains
                parallaxFactor.Set(0.4f, 0.3f);
                break;
            case 9:
                //Foreground move ahead of camera
                parallaxFactor.Set(-0.4f, 0f);
                break;
            default:
                //no parallax effect
                parallaxFactor.Set(0f, 0f);
                break;
        }
    }

    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraLastPosition = cameraTransform.position;
    }

    void Update()
    {
        MoveGameObject();

    }

    void LateUpdate()
    {
        //MoveGameObject();
    }

    private void MoveGameObject()
    {
        Vector3 deltaMovement = cameraTransform.position - cameraLastPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxFactor.x, deltaMovement.y * parallaxFactor.y);
        cameraLastPosition = cameraTransform.position;
    }

    ////modify transform values of gameObject
    //private void ApplyDeltaValues()
    //{
    //    Vector3 position = transform.position;
    //    position += ModifyDeltaValues(PlayerController.PlayerDeltaMovement);
    //    transform.position = position;
    //}

    //Vector3 ModifyDeltaValues(Vector3 delta)
    //{
    //    //delta = PlayerController.PlayerDeltaMovement;
    //    delta.x *= parallaxFactor.x;
    //    delta.y *= parallaxFactor.y;
    //    return delta;
    //}

}
