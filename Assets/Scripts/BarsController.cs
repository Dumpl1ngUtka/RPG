using UnityEngine;
using UnityEngine.UI;

public class BarsController : MonoBehaviour
{
    public enum Bar
    {
        Health = 0,
        Stamina = 1,
        Mana = 2,
        Armor = 3,
    }

    [SerializeField] private Image _healthBar;
    [SerializeField] private Image _staminaBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private Image _armorBar;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void ChangeValue(Bar bar, float value)
    {
        switch (bar)
        {
            case Bar.Health:
                _healthBar.fillAmount = value;
                break;
            case Bar.Stamina:
                _staminaBar.fillAmount = value;
                break;
            case Bar.Mana:
                _manaBar.fillAmount = value;
                break;
            case Bar.Armor:
                _armorBar.fillAmount = value;
                break;
        }
    }
}
