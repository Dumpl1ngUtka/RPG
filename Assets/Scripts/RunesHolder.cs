using System.Collections.Generic;
using UnityEngine;

public class RunesHolder : MonoBehaviour
{
    private List<Rune> _runes = new List<Rune>();

    public void AddRune(Rune rune)
    {
        _runes.Add(rune);
    }

    public void RemoveRune(Rune rune)
    {
        _runes.Remove(rune);
    }
    
    public void GetBonusParameters(PlayerParameters playerParameters)
    {
        if (_runes.Count > 0)
            foreach (Rune rune in _runes)
                rune.GetBonus(playerParameters);
    }
}
