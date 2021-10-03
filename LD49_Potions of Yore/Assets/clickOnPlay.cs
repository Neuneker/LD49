using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOnPlay : MonoBehaviour
{
    public MainMenu m;

    private void OnMouseDown()
    {
        m.StartGame();
    }
}