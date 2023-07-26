using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    protected PlayerController PlayerController;
    protected PlayerParameters PlayerParameters;
    protected Transform CameraHolder;
    protected PlayerInputSystem InputSystem;
    protected Rigidbody Rigidbody;

    public void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        PlayerParameters = GetComponent<PlayerParameters>();
        InputSystem = PlayerController.InputSystem;
        Rigidbody = PlayerController.Rigidbody;
        CameraHolder = PlayerController.CameraHolder;
        PlayerController.AddCondition(this);
    }
}