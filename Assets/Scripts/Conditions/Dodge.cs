using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dodge : Condition
{
    private float _dodgeConditionTime;
    private float _speed;
    private float timer = 0;
    public void SetParameters(float dodgeConditionTime,float speed)
    {
        _speed = speed;
        _dodgeConditionTime = dodgeConditionTime;
    }

    private void Update()
    {
        if (timer < _dodgeConditionTime)
        {
            timer += Time.deltaTime;
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
        SetParameters(PlayerController.DodgeConditionTime.Get(), PlayerController.DodgeSpeed.Get());
        var inputValue = InputSystem.Movement.Move.ReadValue<Vector2>();
        var direction = CameraHolder.forward * inputValue.y + CameraHolder.right * inputValue.x;
        direction.y = 0;
        direction.Normalize();
        Rigidbody.velocity = direction * _speed;
        PlayerController.SpendStamina(1);
    }

    private void OnDisable()
    {
        Rigidbody.velocity = Vector3.zero;
    }
}
