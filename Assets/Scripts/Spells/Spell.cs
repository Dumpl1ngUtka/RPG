using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    protected string Name;
    protected string Description;
    protected Sprite Icon;

    public abstract IEnumerator Activate(PlayerController playerController);
}
