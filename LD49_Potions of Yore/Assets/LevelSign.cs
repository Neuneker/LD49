using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelSign : MonoBehaviour
{
    public TextMeshPro text;
    public FluidColorChanger fluidColorChanger;

    // Start is called before the first frame update
    void Start()
    {
        text.text = PlayerPrefs.GetInt("Level").ToString();
    }

}
