using TMPro;
using UnityEngine;

public abstract class Rune: MonoBehaviour, IItem
{
    protected string Name;
    protected string Description;
    protected Sprite Icon;

    string IItem.Name => Name;

    string IItem.Description => Description;

    Sprite IItem.Icon => Icon;

    public abstract void GetBonus(PlayerParameters playerParameters);

    public bool Take(Inventory inventory)
    {
        if (inventory.AddItem(this))
        {
            Destroy(gameObject);
            return true;
        }
        return false;
    }
}
