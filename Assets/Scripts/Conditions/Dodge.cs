using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dodge : Condition
{
    private float _dodgeConditionTime;
    private float _speed;
    public void SetParameters(float dodgeConditionTime,float speed)
    {
        _speed = speed;
        _dodgeConditionTime = dodgeConditionTime;
    }
    private IEnumerator Dodged()
    {
        var nextCondition = PlayerController.MoveCondition;
        yield return new WaitForSeconds(_dodgeConditionTime);
        PlayerController.ChangeCurrentCondition(nextCondition);
    }
    private void OnEnable()
    {
        SetParameters(PlayerParameters.DodgeConditionTime.Get(), PlayerParameters.DodgeSpeed.Get());
        var inputValue = InputSystem.Movement.Move.ReadValue<Vector2>();
        var dodgeDirection = CameraTransform.forward * inputValue.y + CameraTransform.right * inputValue.x;
        dodgeDirection.y = 0;
        dodgeDirection.Normalize();
        Rigidbody.velocity = dodgeDirection * _speed;
        PlayerController.SpendStamina(1);
        StartCoroutine(Dodged());
    }

    private void OnDisable()
    {
        Rigidbody.velocity = Vector3.zero;
    }
}
