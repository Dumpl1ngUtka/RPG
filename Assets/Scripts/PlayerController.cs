using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] protected BarsController BarsController;
    public Condition MoveCondition { get; private set; }
    public Condition ApplyDamageCondition { get; private set; }
    public Condition DodgeCondition { get; private set; }
    public Condition AttackCondition { get; private set; }
    public Condition LootingCondition { get; private set; }

    private List<Condition> _conditions = new List<Condition>();
    
    public Transform CameraHolder;
    public PlayerInputSystem InputSystem { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private float _staminaTimer = 0;
    public float Health { get; private set; }
    public float Stamina { get; private set; }
    public float Mana{ get; private set; }

    private PlayerParameters _parameters;

    private void Awake()
    {
        InputSystem = new PlayerInputSystem();
        Rigidbody = GetComponent<Rigidbody>();
        _parameters = GetComponent<PlayerParameters>();

        MoveCondition = GetComponent<Move>();
        ApplyDamageCondition = GetComponent<ApplyDamage>();
        AttackCondition = GetComponent<Attack>();
        DodgeCondition = GetComponent<Dodge>();
        LootingCondition = GetComponent<Looting>();

        Health = _parameters.MaxHealth.Get();
        Stamina = _parameters.MaxStamina.Get();
        Mana = 0;

        UpdateBarsValue();
    }

    private void Start()
    {
        UpdateParameters();
        ChangeCurrentCondition(MoveCondition);
    }

    private void Update()
    {
        if (Stamina < _parameters.MaxStamina)
        {
            _staminaTimer += Time.deltaTime;
            if (_staminaTimer > _parameters.StaminaRegenerationPerSecond)
            {
                Stamina++;
                _staminaTimer = 0;
                BarsController.ChangeValue(BarsController.Bar.Stamina,Stamina/ _parameters.MaxStamina.Get());
            }
        }
    }
    public void SpendStamina(int delta)
    {
        Stamina -= delta;
        if (Stamina < 0)
            Stamina = 0;
        BarsController.ChangeValue(BarsController.Bar.Stamina, Stamina / _parameters.MaxStamina.Get());
    }

    public void SpendMana(float delta)
    {
        Mana -= delta;
        if (Mana < 0)
            Mana = 0;
        BarsController.ChangeValue(BarsController.Bar.Mana, Mana / _parameters.MaxMana.Get());
    }
    public void ManaRecovery(float multiplier = 1)
    {
        if (Mana < _parameters.MaxMana)
            Mana += multiplier * _parameters.ManaRegenerationPerSecond.Get() * Time.deltaTime;
        BarsController.ChangeValue(BarsController.Bar.Mana, Mana / _parameters.MaxMana.Get());
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

    private void UpdateBarsValue()
    {
        BarsController.ChangeValue(BarsController.Bar.Health, Health / _parameters.MaxHealth.Get());
        BarsController.ChangeValue(BarsController.Bar.Stamina, Stamina / _parameters.MaxStamina.Get());
        BarsController.ChangeValue(BarsController.Bar.Mana, Mana / _parameters.MaxMana.Get());
        BarsController.ChangeValue(BarsController.Bar.Armor, 0.5f);
    }

    public void UpdateParameters()
    {
        _parameters.UpdateParameters();       
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
        Health -= damage;
        if (Health < 0)
        {
            Debug.Log("Player Die");
        }
        BarsController.ChangeValue(BarsController.Bar.Health, Health / _parameters.MaxHealth.Get());
    }
}
