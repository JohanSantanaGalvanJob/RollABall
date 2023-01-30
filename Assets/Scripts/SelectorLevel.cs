using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorLevel : MonoBehaviour

{
    public int selector;
    public void Levels(int selector)
    {
        switch (selector)
        {
            case 1:
                SceneManager.LoadScene("Start");
                break;
            case 2:
                SceneManager.LoadScene("Second");
                break;
            case 3:
                SceneManager.LoadScene("Third");
                break;
            case 4:
                SceneManager.LoadScene("Fourth");
                break;
        }
    }

    

    public void Exit()
    {
        SceneManager.LoadScene("Menu");
    }
}
