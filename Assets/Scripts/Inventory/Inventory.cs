using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : Menu
{
    [SerializeField] private List<InventoryCell> cells;    
    [SerializeField] private Color _defaultColor;    
    [SerializeField] private Color _selectedColor;
    [SerializeField] private DescriptionPanel _descriptionPanel;
    private int _selectidItemIndex;

    private int _maxSize = 10;

    private void OnEnable()
    {
        PlayerInputSystem.Enable();
        _selectidItemIndex = -1;
        for (int i = _maxSize; i < cells.Count; i++)
            cells[i].IsLocked = true;
        Render();
        _descriptionPanel.Render();
    }

    private void OnDisable()
    {
        PlayerInputSystem.Disable();
    }

    protected override void Selected()
    {
        var direction = PlayerInputSystem.UI.Choosing.ReadValue<Vector2>();
        float inputDegree = Mathf.Acos(direction.x) * Mathf.Rad2Deg * Mathf.Sign(direction.y);
        if (inputDegree < 0)
            inputDegree += 360;
        int currentArea;
        if (inputDegree > 306)
            currentArea = 1;
        else if (inputDegree > 234)
            currentArea = 2;
        else if (inputDegree > 162)
            currentArea = 3;
        else if (inputDegree > 90)
            currentArea = 4;
        else if (inputDegree > 18)
            currentArea = 0;
        else
            currentArea = 1;
        if (currentArea == _selectidItemIndex)
            _selectidItemIndex += 5;
        else if (currentArea + 5 == _selectidItemIndex)
            _selectidItemIndex += 5;
        else if (currentArea + 10 == _selectidItemIndex)
            _selectidItemIndex -= 10;
        else
            _selectidItemIndex = currentArea;

        if (_selectidItemIndex >= _maxSize)
            _selectidItemIndex = currentArea;
        SelectedAreaColorChanged();
        _descriptionPanel.Render(cells[_selectidItemIndex].Item);
    }

    private void SelectedAreaColorChanged()
    {
        foreach (var cell in cells)
        {
            cell.SetColor(_defaultColor);
        }
        if (_selectidItemIndex >= 0)
            cells[_selectidItemIndex].SetColor(_selectedColor);
    }
    private bool IsFull()
    {
        for (int i = 0; i < cells.Count; i++)
            if (cells[i].IsEmpty())
                return false;
        return true;
    }
    public bool AddItem(IItem item)
    {
        // try to find cell with not  full stack 
        if (IsFull())
            return false;
        for (int i = 0; i < cells.Count; i++)
            if (cells[i].IsEmpty())
            {
                cells[i].AddItem(item);
                break;
            }
        Render();
        return true;
    }
    private void Render()
    {
        foreach (var cell in cells)
            cell.Render();
        SelectedAreaColorChanged();
    }
}
