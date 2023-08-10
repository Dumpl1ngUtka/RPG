using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MenuCell : MonoBehaviour
{
    protected Image Background;
    public virtual void Render(IItem item)
    {

    }
    public virtual void SetColor(Color color)
    {
        Background.color = color;
    }
}
