using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuCell : MenuCell
{
    public Menu Menu;

    public override void SetColor(Color color)
    {
        if (Background == null)
            Background = GetComponent<Image>();
        base.SetColor(color);
    }
    public void OpenMenu()
    {
        Menu.gameObject.SetActive(true);
    }
    public void CloseMenu()
    {
        Menu.gameObject.SetActive(false);
    }
}
