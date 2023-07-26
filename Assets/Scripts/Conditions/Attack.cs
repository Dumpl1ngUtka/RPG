using System.Collections;
using UnityEngine;

public class Attack : Condition
{
    [SerializeField] private AnimationCurve attackCurve;
    [SerializeField] private Transform _attackPoint;
    private float _timer;
    private bool _isAttackFinished;
    private float _maxAttackTime;
    private float _attackReleaseTime;
    
    public void SetParameters(float maxAttackTime, float attackReleaseTime)
    {
        _maxAttackTime = maxAttackTime;
        _attackReleaseTime = attackReleaseTime;
    }

    private void Update()
    {

        if (!_isAttackFinished && 
            (_timer > _maxAttackTime || !InputSystem.Movement.Attack.IsPressed()))
        {
            _isAttackFinished = true;
            var damage = PlayerParameters.Damage.Get() * AttackQualifier(_timer);
            var attackPoint = _attackPoint.position;
            attackPoint.y = 1f;
           
            //StartAnimation
            Collider[] colliders = Physics.OverlapSphere(attackPoint,1f,LayerMask.GetMask("Enemy"));
            foreach (Collider collider in colliders)
            {
                collider.GetComponent<Enemy>()?.ApplyDamage(damage);
            }
            StartCoroutine(AttackRelease());
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }

    private IEnumerator AttackRelease()
    {    
        yield return new WaitForSeconds(_attackReleaseTime); 
        PlayerController.ChangeCurrentCondition(PlayerController.MoveCondition);
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
        SetParameters(PlayerParameters.MaxAttackTime.Get(), PlayerParameters.AttackReleaseTime.Get());
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
