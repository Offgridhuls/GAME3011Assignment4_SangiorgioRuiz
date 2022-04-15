using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;
    public float timeValue = 120;
    public bool gameDone = false;
    public bool gameStarted = false;

    private void Update()
    {


        if (gameStarted)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                if (!gameDone)
                {
                    gameDone = true;
                    SceneManager.LoadScene("LoseScene");
                }
            }

            float minutes = Mathf.FloorToInt(timeValue / 60);
            float seconds = Mathf.FloorToInt(timeValue % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

    }
}
