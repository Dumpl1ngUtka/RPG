using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerParameters : MonoBehaviour
{
    [SerializeField] protected BarsController _barsController;

    public Parameter MaxHP = new Parameter(1000f);
    public Parameter MaxStamina = new Parameter(10f);
    public Parameter MaxMana = new Parameter(10f);
    public Parameter StaminaRegenerationPerSecond = new Parameter(5f);
    public Parameter ManaRegenerationPerSecond = new Parameter(1f);
    public Parameter Speed = new Parameter(5f);
    public Parameter ApplyDamageConditionTime = new Parameter(0.5f);
    public Parameter DodgeConditionTime  = new Parameter(0.2f);
    public Parameter DodgeSpeed  = new Parameter(15f);
    public Parameter ManaRecoverySpeedDivision  = new Parameter(5f);
    public Parameter MaxAttackTime  = new Parameter(1f);
    public Parameter Damage  = new Parameter(10f);
}
