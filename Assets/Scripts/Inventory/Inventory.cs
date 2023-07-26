using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    private List<IItem> _items = new List<IItem>();
    private int _maxSize = 2;

    private bool IsFull()
    {
        if (_items == null)
            return false;
        return _items.Count >= _maxSize;
    }
    public bool AddItem(IItem item)
    {
        if (IsFull())
            return false;
        _items.Add(item);
        return true;
    }
}
