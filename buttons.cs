using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class buttons : MonoBehaviour
{

    //References for menus and buttons
    public GameObject PauseMenu;
    public GameObject DeathMenu;
    public GameObject backBtn;



    //Pausing, unpausing and activating menus
public void startbtn()
    {
        SceneManager.LoadScene("game");
        
    }

    public void creditsbtn()
    {
        SceneManager.LoadScene("credits");
    }

    public void settingsbtn()
    {
        SceneManager.LoadScene("settings");
    }
    public void quitbtn()
    {
        SceneManager.LoadScene("main");
        Time.timeScale = 1;
    }

    public void restartbtn()
    {
        SceneManager.LoadScene("game");
        Time.timeScale = 1;
    }

    public void pausebtn()
    {
         Time.timeScale = 0;
         PauseMenu.SetActive(true);
         Cursor.visible = true;
    }

    public void resumebtn()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        DeathMenu.SetActive(false);
    }

    public void backbtn()
    {
        Time.timeScale = 1;
        backBtn.SetActive(false);

    }


        
    
}
