using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject exitUI;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CliickExitButton()
    {
        exitUI.SetActive(true);
    }
    public void NoButtonClick()
    {
        exitUI.SetActive(false);
    }

    public void YesButtonClick()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void StartButtonClick()
    {
        SceneManager.LoadScene("ViewScene");
    }

    public void ExitButtonClick()
    {
        Application.Quit();
    }

}
