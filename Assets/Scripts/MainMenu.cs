using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void GameScene()
    {
        SceneManager.LoadScene("Start");
    }

    public void Levels()
    {
        SceneManager.LoadScene("SelectLevel");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
