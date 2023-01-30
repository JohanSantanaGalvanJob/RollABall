using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject endPanel;
    public TextMeshProUGUI countText;

   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void LoseGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over...";
    }

    public void WinGame()
    {
        endPanel.SetActive(true);
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
    }

    public void AddCountText(int count)
    {
        countText.text = "Count: " + count.ToString();
    }

}
