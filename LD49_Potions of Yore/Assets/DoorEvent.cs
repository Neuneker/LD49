using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorEvent : MonoBehaviour
{
    public void OpenDoor()
    {
        GetComponent<Animator>().SetTrigger("Start");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
