using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField] protected BarsController BarsController;
    [SerializeField] private MainMenu _mainMenu;

    protected bool IsMenuOpen = false;
    public Condition MoveCondition { get; private set; }
    public Condition ApplyDamageCondition { get; private set; }
    public Condition DodgeCondition { get; private set; }
    public Condition AttackCondition { get; private set; }
    public Condition LootingCondition { get; private set; }
    public Condition UseSpellCondition { get; private set; }

    private List<Condition> _conditions = new List<Condition>();
    
    public Transform CameraHolder;
    public PlayerInputSystem InputSystem { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    private float _staminaTimer = 0;
    public float Health { get; private set; }
    public float Stamina { get; private set; }
    public float Mana{ get; private set; }

    private PlayerParameters _parameters;

    public Spell CurrentSpell;

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
        UseSpellCondition = GetComponent<UseSpell>();
        CurrentSpell = GetComponent<ShieldSpell>();

        Health = _parameters.MaxHealth.Get();
        Stamina = _parameters.MaxStamina.Get();
        Mana = 0;

        InputSystem.UI.MenuOpen.started += ctx => StartCoroutine(OpenMainMenu());

        UpdateBarsValue();
    }

    private IEnumerator OpenMainMenu()
    {
        _mainMenu.gameObject.SetActive(true);
        InputSystem.Disable();
        while (_mainMenu.gameObject.activeSelf)
            yield return null;
        InputSystem.Enable();
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
    public bool SpendStamina(int delta)
    {
        if (delta > Stamina)
            return false;
        Stamina -= delta;
        BarsController.ChangeValue(BarsController.Bar.Stamina, Stamina / _parameters.MaxStamina.Get());
        return true;
    }

    public bool SpendMana(float delta)
    {
        if (delta > Mana)
            return false;
        Mana -= delta;
        BarsController.ChangeValue(BarsController.Bar.Mana, Mana / _parameters.MaxMana.Get());
        return true;
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
