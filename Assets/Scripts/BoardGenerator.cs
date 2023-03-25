using System;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Vector2 boardSize;
    [Range(0,1)]
    [SerializeField] private float tileOffset;
    [SerializeField] private float tileHolderHeight;
    
    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for(int i = 0; i < boardSize.x; ++i)
        {
            for (int j = 0; j < boardSize.y; ++j)
            {
                GameObject tile = GameObject.Instantiate(tilePrefab, transform);
                tile.transform.position = new Vector3(-boardSize.x/2 + i + 0.5f,0,-boardSize.y / 2 +j + 0.5f);
                tile.transform.localScale = Vector3.one*(1 - tileOffset);
            }
        }

        GameObject tileHolder = GameObject.Instantiate(tilePrefab, transform);
        tileHolder.transform.localScale=new Vector3(boardSize.x,0,boardSize.y);
    }
}
