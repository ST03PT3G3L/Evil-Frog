using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private float width, height;
    [SerializeField] private float cellSize;
    [SerializeField] private Tile tilePrefab;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if(cellSize > 0)
        {
            for (int x = -50; x < width; x++)
            {
                for (int y = -100; y < height; y++)
                {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.transform.SetParent(transform);
                    spawnedTile.name = "Tile " + x + " " + y;
                }
            }
        }
        //enabled = false;
    }
}
