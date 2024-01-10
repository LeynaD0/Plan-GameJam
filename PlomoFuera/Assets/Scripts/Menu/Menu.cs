using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    GameObject menuScreen, controllerScreen, optionsScreen, creditsScreen;
    [SerializeField]
    float timer;
    [SerializeField]
    bool enable;

    private void Update()
    {
        if (enable)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                controllerScreen.SetActive(false);
                Cursor.visible = false;
                SceneManager.LoadScene(1);
            }
        }
    }

    public void PlayButtom()
    {
        menuScreen.SetActive(false);
        controllerScreen.SetActive(true);
        enable = true;
    }

    public void OptionsButtom()
    {
        menuScreen.SetActive(false);
        optionsScreen.SetActive(true);
    }

    public void CreditsButtom()
    {
        menuScreen.SetActive(false);
        creditsScreen.SetActive(true);
    }

    public void Back2Menu()
    {
        menuScreen.SetActive(true);
        controllerScreen.SetActive(false);
        optionsScreen.SetActive(false);
        creditsScreen.SetActive(false);
    }

    public void ExitGameButtom()
    {
        Application.Quit();
    }
}
