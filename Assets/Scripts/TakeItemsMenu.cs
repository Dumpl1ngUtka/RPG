using System.Collections.Generic;
using UnityEngine;

public class TakeItemsMenu : MonoBehaviour 
{
    [SerializeField] private Transform _container;
    [SerializeField] private TakeMenuCell _takeMenuCell;
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Sprite _box;
    private List<TakeMenuCell> _items;
    private PlayerInputSystem _playerInput;
    private int _currentItemIndex;

    private void Awake()
    {
        _playerInput = new PlayerInputSystem();
    }
    private void OnEnable()
    {
        Clear();
        _items = new List<TakeMenuCell>();
        _currentItemIndex = 0;
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    private void Update()
    {
        if (_playerInput.UI.Choosing.triggered)
        {
            var direction = (int)_playerInput.UI.Choosing.ReadValue<Vector2>().y;
            ChangeCurrentItemIndex(direction);
        }

        if (_playerInput.UI.Accept.triggered)
        {
            var menuCell = _items[_currentItemIndex];   
            if (menuCell.Item.Take(_inventory))
            {
                _items.Remove(menuCell);
                Destroy(menuCell.gameObject);
                ChangeCurrentItemIndex();
            }
        }
    }

    public bool IsEmpty()
    {
        return _items.Count == 0;
    }
    public void Clear()
    {
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
    }

    public void AddItems(List<IItem> items)
    {
        foreach(IItem item in items)
        {
            var menuItem = Instantiate(_takeMenuCell, _container);
            menuItem.Render(item);
            _items.Add(menuItem);
        }
    }

    public void Render()
    {
        if (!IsEmpty())
            foreach (IItem item in _items)
            {
                var menuItem = Instantiate(_takeMenuCell, _container);
                menuItem.Render(item);
            }
    }
}
