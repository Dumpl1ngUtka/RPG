using UnityEngine;

public class ApplyDamage : Condition
{
    private float _applyDamageConditionTime;
    private float timer = 0;
    public void SetParameters(float applyDamageConditionTime)
    {
        _applyDamageConditionTime = applyDamageConditionTime;
    }

    private void Update()
    {
        if (timer < _applyDamageConditionTime)
        {
            timer += Time.deltaTime;
            Debug.Log(InputSystem);
        }
        else
        {
            var nextCondition = PlayerController.MoveCondition;
            PlayerController.ChangeCurrentCondition(nextCondition);
        }
    }
    private void OnEnable()
    {
        timer = 0;
        SetParameters(PlayerController.ApplyDamageConditionTime.Get());
    }
}
