using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPiece : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2Int index;

    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
