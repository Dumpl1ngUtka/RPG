using UnityEngine;

public class Menu : MonoBehaviour
{
    private PlayerInputSystem _playerInputSystem;
    public bool IsOpen { get; private set; }

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _playerInputSystem.UI.MenuOpen.performed += ctx => OpenMenu(!IsOpen); 
        //_playerInputSystem.UI.Back.performed += ctx => OpenMenu(false); 
    }

    private void OnEnable()
    {
        _playerInputSystem.Enable();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }

    private void OpenMenu(bool isOpen)
    {
        IsOpen = isOpen;
        if (IsOpen)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
