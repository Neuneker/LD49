using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorContainer : MonoBehaviour
{
    public Color originalColor { get; private set; }

    public void Awake()
    {
        originalColor = GetComponent<SpriteRenderer>().color;
    }

}
