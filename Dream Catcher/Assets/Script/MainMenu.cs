using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public AudioSource play;
    public void LoadLevel()
    
    {
        SceneManager.LoadScene("Game");// � �������� �������� ����� �� ������� �������������� �������
    }

    public void Respawn()
    {
        SceneManager.LoadScene("Game");
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
   


    public void ExitGame()
    {
        Application.Quit();
    }
}