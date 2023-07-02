using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarsController : MonoBehaviour
{
    [SerializeField] private Image _HPBar;
    [SerializeField] private Image _staminaBar;
    [SerializeField] private Image _manaBar;
    [SerializeField] private Image _armorBar;
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        ChangeValue();  
    }
    public void ChangeValue()
    {
        _HPBar.fillAmount = _playerController.HP / _playerController.MaxHP.Get();
        _staminaBar.fillAmount = (float)_playerController.Stamina / _playerController.MaxStamina.Get();
        _manaBar.fillAmount = _playerController.Mana / _playerController.MaxMana.Get();
        _armorBar.fillAmount = 0.5f;
    }

}
