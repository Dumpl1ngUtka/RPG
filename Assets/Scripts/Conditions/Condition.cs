using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    protected PlayerController PlayerController;
    protected PlayerParameters PlayerParameters;
    protected Transform CameraTransform;
    protected PlayerInputSystem InputSystem;
    protected Rigidbody Rigidbody;

    public void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        PlayerParameters = GetComponent<PlayerParameters>();
        InputSystem = PlayerController.InputSystem;
        Rigidbody = PlayerController.Rigidbody;
        CameraTransform = Camera.main.transform;
        PlayerController.AddCondition(this);
    }
}