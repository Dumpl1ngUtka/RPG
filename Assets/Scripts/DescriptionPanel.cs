using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Image _icon;
    public void Render(IItem item = null)
    {
        if (item != null)
        {
            _name.text = item.Name;
            _description.text = item.Description;
            _icon.sprite = item.Icon;
        }
        else
        {
            _name.text = "";
            _description.text = "";
            _icon.sprite = _defaultSprite;
        }
    }
}
