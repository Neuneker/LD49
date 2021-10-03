using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidRelease : MonoBehaviour
{


    [SerializeField] GameObject[] blocks;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            blocks[0].SetActive(!blocks[0].activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            blocks[1].SetActive(!blocks[1].activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            blocks[2].SetActive(!blocks[2].activeSelf);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
