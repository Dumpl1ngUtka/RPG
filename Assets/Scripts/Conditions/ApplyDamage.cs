using System.Collections;
using UnityEngine;

public class ApplyDamage : Condition
{
    private float _applyDamageConditionTime;
    public void SetParameters(float applyDamageConditionTime)
    {
        _applyDamageConditionTime = applyDamageConditionTime;
    }

    private IEnumerator AppliedDamage()
    { 
        yield return new WaitForSeconds(_applyDamageConditionTime);
        var nextCondition = PlayerController.MoveCondition;
        PlayerController.ChangeCurrentCondition(nextCondition); 
    } 

    private void OnEnable()
    {
        SetParameters(PlayerParameters.ApplyDamageConditionTime.Get());
        StartCoroutine(AppliedDamage());
    }
}
