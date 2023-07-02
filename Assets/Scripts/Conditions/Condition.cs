using UnityEngine;

public abstract class Condition : MonoBehaviour
{
    protected PlayerController PlayerController;
    protected PlayerParameters Player;
    protected Transform CameraHolder;
    protected PlayerInputSystem InputSystem;
    protected Rigidbody Rigidbody;

    public void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        Player = GetComponent<PlayerParameters>();
        InputSystem = PlayerController.InputSystem;
        Rigidbody = PlayerController.Rigidbody;
        CameraHolder = PlayerController.CameraHolder;
        PlayerController.AddCondition(this);
    }
}
