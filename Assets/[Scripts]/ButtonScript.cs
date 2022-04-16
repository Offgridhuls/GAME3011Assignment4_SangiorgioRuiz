using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    public GameObject GameCanvas;
    [SerializeField]
    public GameObject MenuCanvas;
    [SerializeField]
    public GameObject GameBoard;
    [SerializeField]
    public Timer timer;

    private void Start()
    {
        GameBoard.SetActive(false);
    }
    public void StartGame(string difficulty)
    {
        GameCanvas.SetActive(true);
        GameBoard.SetActive(true);
        MenuCanvas.SetActive(false);

        if (difficulty == "Easy")
        {
            timer.timeValue = 300;
        }
        else if (difficulty == "Medium")
        {
            timer.timeValue = 150;
        }
        else if (difficulty == "Hard")
        {
            timer.timeValue = 90;
        }

        timer.gameStarted = true;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
