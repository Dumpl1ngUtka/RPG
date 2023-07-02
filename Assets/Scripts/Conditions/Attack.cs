using UnityEngine;

public class Attack : Condition
{
    [SerializeField] private AnimationCurve attackCurve;
    [SerializeField] private Transform attackPoint;
    private float _timer;
    private bool _isAttackFinished;
    private float _maxAttackTime;
    
    private enum AttackQuality
    {
        bad,
        normal,
        good,
    };
    public void SetParameters(float maxAttackTime)
    {
        _maxAttackTime = maxAttackTime;
    }

    private void Update()
    {
        if (!_isAttackFinished && 
            (_timer > _maxAttackTime || !InputSystem.Movement.Attack.IsPressed()))
        {
            _isAttackFinished = true;
            var damage = PlayerController.Damage.Get() * AttackQualifier(_timer);
            //StartAnimation
            Collider[] colliders = Physics.OverlapSphere(attackPoint.position,0.5f,LayerMask.GetMask("Enemy"));
            foreach (Collider collider in colliders)
            {
                collider.GetComponent<Enemy>()?.ApplyDamage(damage);
            }
            PlayerController.ChangeCurrentCondition(PlayerController.MoveCondition);
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private float AttackQualifier(float timer)
    {
        var value = attackCurve.Evaluate(_timer/ _maxAttackTime);
        if (value < 0.4f)
            return 0.8f;
        else if (value > 0.6f)
            return 1.2f;  
        return 1f;
    }
    private void OnEnable()
    {
        _timer = 0;
        _isAttackFinished = false;
        InputSystem = PlayerController.InputSystem;
        SetParameters(PlayerController.MaxAttackTime.Get());
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
}
