using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSpell : Condition
{
    private void OnEnable()
    {
        if (PlayerController.CurrentSpell != null)
            StartCoroutine(PlayerController.CurrentSpell.Activate(PlayerController));
    }
}
