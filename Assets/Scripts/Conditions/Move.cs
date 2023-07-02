using UnityEngine;

public class Move : Condition
{
    private float _speed;
    private bool _isRecovery;

    public void SetParameters(float speed)
    {
        _speed = speed;
    }

    private void Update()
    {
        if (InputSystem.Movement.Dodge.triggered && PlayerController.Stamina > 0)
            PlayerController.ChangeCurrentCondition(PlayerController.DodgeCondition);

        if (InputSystem.Movement.Recovery.IsPressed() && !_isRecovery)
        {
            _isRecovery = true;
            SetParameters(_speed / PlayerController.ManaRecoverySpeedDivision.Get());
        }
        else if (!InputSystem.Movement.Recovery.IsPressed() && _isRecovery)
        {
            _isRecovery = false;
            SetParameters(PlayerController.Speed.Get());
        }
        if (_isRecovery)
            PlayerController.ManaRecovery();

        if (InputSystem.Movement.Attack.triggered)
        {
            PlayerController.ChangeCurrentCondition(PlayerController.AttackCondition);
        }
    }

    private void FixedUpdate()
    {
        var inputValue = InputSystem.Movement.Move.ReadValue<Vector2>();
        var direction = CameraHolder.forward * inputValue.y + CameraHolder.right * inputValue.x;
        direction.y = 0;
        direction.Normalize();
        Rigidbody.velocity = direction * _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        var hitBox = other.GetComponent<HitBox>();
        if (hitBox != null)
        {
            if (!hitBox.IsPeriodicDamage)
            {
                PlayerController.ApplyDamage(hitBox.Damage);
                var nextCondition = PlayerController.ApplyDamageCondition;
                PlayerController.ChangeCurrentCondition(nextCondition);
            }
        }
    }

    private void OnEnable()
    {
        SetParameters(PlayerController.Speed.Get());
        _isRecovery = false;
    }

    private void OnDisable()
    {
        Rigidbody.velocity = Vector3.zero;
    }
}
