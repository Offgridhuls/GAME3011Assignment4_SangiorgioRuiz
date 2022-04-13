using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridLayout : MonoBehaviour
{
    public int length;
    public int width;

    public static GridLayout gridInstance;
    public Vector2Int index;
    public BackgroundPiece gridBackground;

    public List<Transform> backgroundNodes = new List<Transform>();
    // Start is called before the first frame update
    private void Awake()
    {
        gridInstance = this;
    }
    void Start()
    {
        for(int l = 0; l < length; l++)
        {
            for(int w = 0; w < width; w++)
            {
                var GridBackground = Instantiate(gridBackground, new Vector2(l, w), Quaternion.identity);
                index = new Vector2Int(l, w);
                GridBackground.GetComponent<BackgroundPiece>().index = new Vector2Int(l, w);
                backgroundNodes.Add(GridBackground.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
