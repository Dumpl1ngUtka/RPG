using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private List<MainMenuCell> _menuTabs;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private Color _selectedColor;
    private int _openMenuTabIndex;
    private PlayerInputSystem _playerInputSystem;

    private void Awake()
    {
        _playerInputSystem = new PlayerInputSystem();
        _playerInputSystem.UI.ChangeTabs.performed += ctx => SelectedTabs();
        _playerInputSystem.UI.Back.performed += ctx => CloseMenu();
    }
    protected void SelectedTabs()
    {
        var direction = (int)_playerInputSystem.UI.ChangeTabs.ReadValue<float>();
        _openMenuTabIndex += direction;
        if (_openMenuTabIndex < 0)
            _openMenuTabIndex = _menuTabs.Count - 1;
        else if (_openMenuTabIndex > _menuTabs.Count - 1)
            _openMenuTabIndex = 0; 
        SwitchTabs();
        ChangeTabsColor();
    }

    private void ChangeTabsColor()
    {
        foreach (var tab in _menuTabs)
            tab.SetColor(_defaultColor);
        _menuTabs[_openMenuTabIndex].SetColor(_selectedColor);
    }

    private void CloseMenu()
    {
        CloseAllTabs();
        gameObject.SetActive(false);
    }    
    
    private void CloseAllTabs()
    {
        foreach (var tab in _menuTabs)
        {
            tab.CloseMenu();
        }
    }
    private void OnEnable()
    {
        _playerInputSystem.Enable();
        _openMenuTabIndex = 0;
        SelectedTabs();
    }

    private void OnDisable()
    {
        _playerInputSystem.Disable();
    }
    private void SwitchTabs()
    {
        var nextMenu = _menuTabs[_openMenuTabIndex];
        CloseAllTabs();
        nextMenu.OpenMenu();
    }
}
