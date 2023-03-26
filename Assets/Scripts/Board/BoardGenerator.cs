using System;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 boardSize;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private GameObject BoardPrefab;
    [Range(0,1)]
    [SerializeField] private float tileOffset;
    [Range(-0.05f,-0.1f)]
    [SerializeField] private float tileHolderHeight;

    [SerializeField] private Material Black;
    [SerializeField] private Material White;
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

                tile.GetComponent<Renderer>().material = White;
            }
        }

        GameObject tileHolder = GameObject.Instantiate(BoardPrefab, transform);
        tileHolder.name = "TileHolder";
        tileHolder.transform.localScale=new Vector3(boardSize.x,boardSize.y,1);
        tileHolder.transform.position = new Vector3(0, tileHolderHeight, 0);

        tileHolder.GetComponent<Renderer>().material = Black;
    }
}
