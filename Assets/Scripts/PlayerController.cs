using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerParameters
{
    public Condition MoveCondition;
    public Condition ApplyDamageCondition;
    public Condition DodgeCondition;
    public Condition AttackCondition;
    private List<Condition> _conditions = new List<Condition>();
    public Transform CameraHolder;
    public PlayerInputSystem InputSystem { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private float _staminaTimer = 0;
    public float HP { get; private set; }
    public float Stamina { get; private set; }
    public float Mana{ get; private set; }

    private float _periodicDamage;

    private void Awake()
    {
        InputSystem = new PlayerInputSystem();
        Rigidbody = GetComponent<Rigidbody>();
        HP = MaxHP.Get();
        Stamina = MaxStamina.Get();
        Mana = 0;
    }

    private void Start()
    {        
        ChangeCurrentCondition(MoveCondition);
    }

    private void Update()
    {
        if (Stamina < MaxStamina.Get())
        {
            _staminaTimer += Time.deltaTime;
            if (_staminaTimer > StaminaRegenerationPerSecond.Get())
            {
                Stamina++;
                _staminaTimer = 0;
                _barsController.ChangeValue();
            }
        }
    }

    public void SpendStamina(int delta)
    {
        Stamina -= delta;
        if (Stamina < 0)
            Stamina = 0;
        _barsController.ChangeValue();
    }

    public void SpendMana(float delta)
    {
        Mana -= delta;
        if (Mana < 0)
            Mana = 0;
        _barsController.ChangeValue();
    }
    public void ManaRecovery(float multiplier = 1)
    {
        if (Mana < MaxMana.Get())
            Mana += multiplier * ManaRegenerationPerSecond.Get() * Time.deltaTime;
        _barsController.ChangeValue();
    }
    public void AddCondition(Condition condition)
    {
        _conditions.Add(condition);
    }
    public void ChangeCurrentCondition(Condition newCondition)
    {
        foreach (var condition in _conditions)
        {
            condition.enabled = false;
        }
        newCondition.enabled = true;
    }

    private void OnEnable()
    {
        InputSystem.Enable();
    }

    private void OnDisable()
    {
        InputSystem.Disable();
    }
    public void ApplyDamage(float damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            Debug.Log("Player Die");
        }
        _barsController.ChangeValue();
    }
    private void OnTriggerEnter(Collider other)
    {
        var hitBox = other.GetComponent<HitBox>();
        if (hitBox != null && hitBox.IsPeriodicDamage)
        {
            _periodicDamage = hitBox.DamagePerSecond * Time.fixedDeltaTime;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        var hitBox = other.GetComponent<HitBox>();
        if (hitBox != null && hitBox.IsPeriodicDamage)
        {
            ApplyDamage(_periodicDamage);
        }
    }
}
