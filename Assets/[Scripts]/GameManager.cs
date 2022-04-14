using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager gameInstance;
    public List<Pipe> unsolvedPipes;
    public List<Pipe> solvedPipes;
    public bool isGameWon = false;

    //public GameObject selectedGameObject;
    private void Awake()
    {
       // selectedGameObject = null;
        gameInstance = this;
    }
    void Start()
    {
        GameObject[] tempPipe = GameObject.FindGameObjectsWithTag("Pipe");
        foreach (GameObject pipe in tempPipe)
        {
            unsolvedPipes.Add(pipe.GetComponent<Pipe>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameWon == false)
        {
            foreach (Pipe pipe in unsolvedPipes)
            {
                if (pipe.solved == true)
                {
                    unsolvedPipes.Remove(pipe);
                    solvedPipes.Add(pipe);
                }
            }

            if (unsolvedPipes.Count <= 0)
            {
                isGameWon = true;
            }
        }
    }
}
