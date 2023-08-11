using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShieldSpell : Spell
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private GameObject _bubble;
    private float _manaPerSecond = 1f;
    private void OnEnable()
    {
        Name = "Shield";
        Description = "Create Shield";
        Icon = _icon;
    }
    public override IEnumerator Activate(PlayerController playerController)
    {
        var playerTransform = playerController.gameObject.transform;
        var button = playerController.InputSystem.Movement.Spell;
        var shield = Instantiate(_bubble, playerTransform.position,Quaternion.identity, playerTransform);
        while (button.IsPressed())
        {
            if (!playerController.SpendMana(_manaPerSecond * Time.deltaTime))
                break;
            yield return null;
        }
        Destroy(shield);
        playerController.ChangeCurrentCondition(playerController.MoveCondition);
    }
}
