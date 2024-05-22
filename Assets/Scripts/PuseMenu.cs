using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuseMenu : MonoBehaviour
{
    public bool pauseGame;
    public GameObject pauseGameMenu;
    public GameObject Settings;
    
    void Update()
    {
        
        
           
        
    }
    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseGame = false;
    }
    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0;
        pauseGame = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }

    public void OnSettings()
    {
        Settings.SetActive(true);
        
    }
    public void OffSettings()
    {
        Settings.SetActive(false);
        
    }
}

