using UnityEngine;

public class HealthRune : Rune
{
    [SerializeField] private Sprite _icon;
    private float _value = 1.5f;
    private void OnEnable()
    {
        Name = "Health Rune";
        Description = $"Increases the amount of health by {_value} times";
        Icon = _icon;
    }

    public override void GetBonus(PlayerParameters playerParameters)
    {
        playerParameters.MaxHealth *= _value;
    }
}
