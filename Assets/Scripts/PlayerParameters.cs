using UnityEngine;

public class PlayerParameters : MonoBehaviour
{
    public Parameter MaxHealth = new Parameter(1000f);
    public Parameter MaxStamina = new Parameter(10f);
    public Parameter MaxMana = new Parameter(10f);
    public Parameter StaminaRegenerationPerSecond = new Parameter(5f);
    public Parameter ManaRegenerationPerSecond = new Parameter(5f);
    public Parameter Speed = new Parameter(5f);
    public Parameter ApplyDamageConditionTime = new Parameter(0.5f);
    public Parameter DodgeConditionTime = new Parameter(0.2f);
    public Parameter DodgeSpeed = new Parameter(15f);
    public Parameter ManaRecoverySpeedDivision = new Parameter(5f);
    public Parameter MaxAttackTime = new Parameter(1f);
    public Parameter Damage = new Parameter(10f);
    public Parameter AttackReleaseTime = new Parameter(0.8f);

    private RunesHolder _runesHolder;

    private void Awake()
    {
        _runesHolder = GetComponent<RunesHolder>();
    }

    public void UpdateParameters()
    {
        RemoveBonusFromAllParameters();
        _runesHolder.GetBonusParameters(this);
    }

    private void RemoveBonusFromAllParameters()
    {
        MaxHealth.RemoveBonus();
        MaxStamina.RemoveBonus();
        MaxMana.RemoveBonus();
        StaminaRegenerationPerSecond.RemoveBonus();
        ManaRegenerationPerSecond.RemoveBonus();
        Speed.RemoveBonus();
        ApplyDamageConditionTime.RemoveBonus();
        DodgeConditionTime.RemoveBonus();
        DodgeSpeed.RemoveBonus();
        ManaRecoverySpeedDivision.RemoveBonus();
        MaxAttackTime.RemoveBonus();
        Damage.RemoveBonus();
        AttackReleaseTime.RemoveBonus();
    }
}