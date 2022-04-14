using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    float[] possibleRotations = {0, 90, 180, 270};
    public Vector3 targetPosition;
    bool isBeingDragged = false;
    public float snapDistance = 1;
    private bool canBeDragged = true;
    public PossibleRotationStruct correctPath;
    public Vector2Int index;
    public LayerMask nodeMask;
    public bool solved = false;

    void Start()
    {
        int rand = Random.Range(0, possibleRotations.Length);
        transform.eulerAngles = new Vector3(0, 0, possibleRotations[rand]);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetPosition;
        float smallestDistance = snapDistance;
        if(index == correctPath.correctIndex && transform.eulerAngles.z == correctPath.correctRotation)
        {
            canBeDragged = false;
            solved = true;
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
    }
    private void OnMouseDown()
    {
        isBeingDragged = true;
        if(canBeDragged != false)
        transform.Rotate(new Vector3(0, 0, 90));
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
