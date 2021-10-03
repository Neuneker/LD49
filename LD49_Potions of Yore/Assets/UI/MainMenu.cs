using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject sign;
    [SerializeField] GameObject door;

    public void SignClick()
    {
        sign.GetComponent<SignAnimator>().StartSwing();
    }

    public void StartGame()
    {
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Level", 1);
        door.GetComponent<DoorEvent>().OpenDoor();
    }

    public void Help()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        
    }

}
