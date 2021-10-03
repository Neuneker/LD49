using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOnQuit : MonoBehaviour
{
    public MainMenu m;

    private void OnMouseDown()
    {
        m.Quit();
    }
}