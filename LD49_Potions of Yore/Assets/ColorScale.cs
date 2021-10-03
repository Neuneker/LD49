using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScale : MonoBehaviour
{

    public FluidColorChanger fluidColorChanger;

    [SerializeField] Transform icon;
    [SerializeField] int colorChannel;


    // Start is called before the first frame update
    void Update()
    {
        switch (colorChannel)
        {
            case 1:
                icon.localScale = new Vector3(1, fluidColorChanger.targetColor.r - fluidColorChanger.newColor.r, 1);
                break;
            case 2:
                icon.localScale = new Vector3(1, fluidColorChanger.targetColor.g - fluidColorChanger.newColor.g, 1);
                break;
            case 3:
                icon.localScale = new Vector3(1, fluidColorChanger.targetColor.b - fluidColorChanger.newColor.b, 1);
                break;
        }
    }
}
