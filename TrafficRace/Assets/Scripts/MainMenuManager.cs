using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        highScoreText.text = "High Score : " + PlayerPrefs.GetInt("totalScoreKey");
        if (Screen.currentResolution.width < 1000)
        {
            Screen.SetResolution(Screen.currentResolution.width / 2, Screen.currentResolution.height / 2, true);
        }
        
    }
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
