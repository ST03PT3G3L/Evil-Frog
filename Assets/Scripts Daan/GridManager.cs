using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private float width, height;
    [SerializeField] private float cellSize;
    [SerializeField] private Tile tilePrefab;
    [SerializeField] private Transform cam;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if(cellSize > 0)
        {
            for (int x = -60; x < width; x++)
            {
                for (int y = -30; y < height; y++)
                {
                    var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                    spawnedTile.transform.SetParent(transform);
                    spawnedTile.name = "Tile " + x + " " + y;
                }
            }

            cam.transform.position = new Vector3(width / 2 - 0.5f, height / 2 - 0.5f, -10f);
        }
    }
}
