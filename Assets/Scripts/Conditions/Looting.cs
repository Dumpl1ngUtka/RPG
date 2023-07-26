using System.Collections.Generic;
using UnityEngine;

public class Looting : Condition
{
    [SerializeField] private TakeItemsMenu _menu;
    private void OnEnable()
    {
        Take();
        InputSystem = PlayerController.InputSystem;
    }
    private void Update()
    {
        if (InputSystem.UI.Back.triggered)
        {
            _menu.gameObject.SetActive(false);
            PlayerController.ChangeCurrentCondition(PlayerController.MoveCondition);
        }
        if (_menu.IsEmpty())
        {
            _menu.gameObject.SetActive(false);
            PlayerController.ChangeCurrentCondition(PlayerController.MoveCondition);
        }
    }
    private void Take()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);
        var items = new List<IItem>();
        foreach (Collider collider in colliders)
        {
            var item = collider.GetComponent<IItem>();
            if (item != null)
                items.Add(item);
        }
        if (items.Count > 0)
        {
            _menu.gameObject.SetActive(true);
            _menu.Clear();
            _menu.AddItems(items);
        }
        else
        {
            PlayerController.ChangeCurrentCondition(PlayerController.MoveCondition);
        }
            
    }
}
