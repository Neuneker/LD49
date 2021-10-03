using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTester : MonoBehaviour
{
    public Color test;
    [Range(0,200)]
    public int redCount, greenCount, blueCount;
    public int denominator;
    public float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        denominator = redCount + blueCount + greenCount;
        test = new Color(redCount / (float)denominator, greenCount / (float)denominator, blueCount / (float)denominator);
        print(test.r + " " + test.g + " " + test.b);
    }
}
