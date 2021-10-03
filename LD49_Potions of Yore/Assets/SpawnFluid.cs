using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFluid : MonoBehaviour
{

    [SerializeField] private int width, height;
    [SerializeField] private GameObject fluid;

    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject tempGo = Instantiate(fluid, transform);
                tempGo.transform.position = new Vector2((x - (width / 2))*.1f, y * .1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
