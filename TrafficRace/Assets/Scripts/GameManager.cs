using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerCar;
    [SerializeField] private GameObject StartPanel;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] private float score;
    public int intScore;
    private void Start()
    {
        scoreText.text = "0";
    }
    private void Update()
    {
        //araç hareket ediyorsa scoru zaman baðlý arttýr.
        if (playerCar.GetComponent<CarController>().isGoing)
        {
            score += Time.deltaTime;
            intScore = (int)score;
            scoreText.text = intScore.ToString();
        }
        
    }
    public void StartButton()
    {
        //butona basýldýðýnda aracý hareket ettir ve startpaneli kapat
        playerCar.GetComponent<CarController>().isGoing = true;
        StartPanel.SetActive(false);
    }
    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
