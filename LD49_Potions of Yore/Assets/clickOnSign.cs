using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickOnSign : MonoBehaviour
{

    public MainMenu m;

    private void OnMouseDown()
    {
        m.SignClick();
    }
}
