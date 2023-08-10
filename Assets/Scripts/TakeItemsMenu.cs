using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeItemsMenu : MonoBehaviour 
{
    [SerializeField] private Transform _container;
    [SerializeField] private TakeMenuCell _takeMenuCell;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Color _selectedColor;
    [SerializeField] private Color _defaultColor;
    private ScrollRect _scrollRect;
    private List<TakeMenuCell> _items;
    private PlayerInputSystem _playerInput;
    private int _currentItemIndex;

    private void Awake()
    {
        _playerInput = new PlayerInputSystem();
        _scrollRect = GetComponent<ScrollRect>();
        _playerInput.UI.Choosing.started += ctx => ChooseItem();
        _playerInput.UI.Accept.started += ctx => TakeItem();
    }
    private void OnEnable()
    {
        Clear();
        _items = new List<TakeMenuCell>();
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void ChooseItem()
    {
        var direction = (int)(_playerInput.UI.Choosing.ReadValue<Vector2>().y * 1.5f);
        ChangeCurrentItemIndex(direction);
    }

    private void TakeItem()
    {
        var menuCell = _items[_currentItemIndex];
        if (menuCell.Item.Take(_inventory))
        {
            _items.Remove(menuCell);
            Destroy(menuCell.gameObject);
            if (!IsEmpty())
                ChangeCurrentItemIndex();
        }
    }
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }
    public void Clear()
    {
        _currentItemIndex = 0;
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }
    }

    private void ChangeCurrentItemIndex(int direction = 0)
    {
        _currentItemIndex -= direction;
        if (_currentItemIndex < 0)
            _currentItemIndex = _items.Count - 1;
        if (_currentItemIndex > _items.Count - 1)
            _currentItemIndex = 0;
        ChangeColorSelectedItem();
        ScrollViewPort();
    }
    private void ScrollViewPort()
    {
        float normalizePosition = (float)_currentItemIndex / (_items.Count - 1);
        _scrollRect.verticalNormalizedPosition = 1 - normalizePosition;
    }

    private void ChangeColorSelectedItem()
    {
        foreach (TakeMenuCell item in _items)
        {
            item.SetColor(_defaultColor);
        }
        _items[_currentItemIndex].SetColor(_selectedColor);
    }

    public void AddItems(List<IItem> items)
    {
        foreach(IItem item in items)
        {
            var menuItem = Instantiate(_takeMenuCell, _container);
            menuItem.Render(item);
            _items.Add(menuItem);
        }
        ChangeCurrentItemIndex();
    }
}
