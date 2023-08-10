using UnityEngine;
public abstract class Menu : MonoBehaviour
{
    protected PlayerInputSystem PlayerInputSystem;
    private void Awake()
    {
        PlayerInputSystem = new PlayerInputSystem();
        PlayerInputSystem.UI.Choosing.performed += ctx => Selected();
    }
    protected virtual void Selected()
    { 
    }
    private void OnEnable()
    {
        PlayerInputSystem.Enable();
    }
    private void OnDisable()
    {
        PlayerInputSystem.Disable();
    }
}
