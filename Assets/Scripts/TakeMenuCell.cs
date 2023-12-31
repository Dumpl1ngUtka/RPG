using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TakeMenuCell : MenuCell
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    public IItem Item;

    public override void Render(IItem item)
    {
        Item = item;
        _name.text = item.Name;
        _icon.sprite = item.Icon;
        Background = GetComponent<Image>();
    }
}
