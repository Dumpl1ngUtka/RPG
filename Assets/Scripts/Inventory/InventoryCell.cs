using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MenuCell
{
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _lockdeSprite;
    public bool IsLocked = false;
    public IItem Item;
    public bool IsEmpty()
    {
        return Item == null && !IsLocked;
    } 

    public void AddItem(IItem item)
    {
        Item = item;
    }

    public void Render()
    {
        if (IsLocked)
            _icon.sprite = _lockdeSprite;
        else if (IsEmpty())
            _icon.sprite = _defaultSprite;
        else
            _icon.sprite = Item.Icon;
        Background = GetComponent<Image>();
    }
}
