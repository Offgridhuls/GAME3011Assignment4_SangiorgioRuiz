using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float[] possibleRotations = {0, 90, 180, 270};
    int currentRotation;
    public Vector3 targetPosition;
    bool isBeingDragged = false;
    public float snapDistance = 1;
    private bool canBeDragged = true;
    public PossibleRotationStruct correctPath;
    public Vector2Int index;
    public LayerMask nodeMask;
    public bool solved = false;
    public bool isStraightPipe;
    public GameManager gameManager;

    void Start()
    {
        int rand = Random.Range(0, possibleRotations.Length);
        transform.eulerAngles = new Vector3(0, 0, possibleRotations[rand]);
        currentRotation = rand;
        gameManager = GameObject.Find("EventSystem").GetComponent<GameManager>();
        //targetPosition = correctPath.correctIndex;
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, correctPath.correctRotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetPosition;
        float smallestDistance = snapDistance;
        if (isStraightPipe)
        {
            if (index == correctPath.correctIndex && (transform.eulerAngles.z == correctPath.correctRotation || transform.eulerAngles.z == correctPath.correctRotation + 180))
            {
                canBeDragged = false;
                solved = true;
            }
        }
        else
        {
            if (index == correctPath.correctIndex && (transform.eulerAngles.z == correctPath.correctRotation) && !solved)
            {
                canBeDragged = false;
                solved = true;
                gameManager.unsolvedPipes.Remove(this);
                gameManager.solvedPipes.Add(this);
            }
        }
        foreach(Transform node in GridLayout.gridInstance.backgroundNodes)
        {
            if (Vector3.Distance(node.position, targetPosition) < smallestDistance && isBeingDragged)
            {

                index = node.GetComponent<BackgroundPiece>().index;
                targetPosition = node.position;
                smallestDistance = Vector3.Distance(node.position, targetPosition);
            }
        }

        if (Input.GetKeyDown(KeyCode.X) && !solved)
        {
            gameManager.unsolvedPipes.Remove(this);
            gameManager.solvedPipes.Add(this);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!solved)
            {
                //transform.Rotate(new Vector3(0, 0, 90));
                if (currentRotation == 0)
                {
                    currentRotation = 1;
                }
                else if (currentRotation == 1)
                {
                    currentRotation = 2;
                }
                else if (currentRotation == 2)
                {
                    currentRotation = 3;
                }
                else if (currentRotation == 3)
                {
                    currentRotation = 0;
                }
                transform.rotation = Quaternion.Euler(0f, 0f, possibleRotations[currentRotation]);
            }
        }
    }

    private void OnMouseDown()
    {
        isBeingDragged = true;
        if (canBeDragged != false) ;
    }
    private void OnMouseDrag()
    {
        if(isBeingDragged && canBeDragged != false)
        targetPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    }

    private void OnMouseExit()
    {
        isBeingDragged = false;
    }

    //void SnapToLocation()
    //{
    //
    //}
}
