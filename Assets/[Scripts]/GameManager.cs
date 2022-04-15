using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gameInstance;
    public List<Pipe> unsolvedPipes;
    public List<Pipe> solvedPipes;
    public bool isGameWon = false;
    public bool gameStarted = false;
    int pipeAmount;

    //public GameObject selectedGameObject;
    private void Awake()
    {
       // selectedGameObject = null;
        gameInstance = this;

        GameObject[] tempPipe = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in tempPipe)
        {
            unsolvedPipes.Add(pipe.GetComponent<Pipe>());
        }
        pipeAmount = unsolvedPipes.Count;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameWon == false)
        {
            if (unsolvedPipes.Count <= 0)
            {
                isGameWon = true;
                print("Game Won!");
                SceneManager.LoadScene("WinScene");
            }
        }
    }

    //public void CheckPipeAmount()
    //{
    //    foreach (Pipe pipe in unsolvedPipes)
    //    {
    //        if (pipe.solved == true)
    //        {
    //            unsolvedPipes.Remove(pipe);
    //            solvedPipes.Add(pipe);
    //            pipeAmount = unsolvedPipes.Count;
    //        }
    //    }
    //}
}
