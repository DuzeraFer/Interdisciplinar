using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridBehavior : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public int scaleX = 1;
    public float scaleY = 0.6f;
    public GameObject gridPrefab;
    public Vector3 leftBottomLocationOdd = new Vector3(0, 0, 0);
    public Vector3 leftBottomLocationEven = new Vector3(0, 0, 0);
    public Tilemap wallTile;
    public Tilemap groundTile;
    public Grid grid;

    void Awake()
    {
        GenerateGridOdd();
        GenerateGridEven();
    }

    void GenerateGridOdd()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3Int cellPositionOdd = grid.WorldToCell(new Vector3(leftBottomLocationOdd.x + scaleX * i, (leftBottomLocationOdd.y + scaleY * j), leftBottomLocationOdd.z));
                Vector3Int cellDestroyPositionOdd = grid.WorldToCell(new Vector3(leftBottomLocationOdd.x + scaleX * i, (leftBottomLocationOdd.y + scaleY * j) + 0.6f, leftBottomLocationOdd.z));

                if (groundTile.HasTile(cellPositionOdd) && wallTile.HasTile(cellDestroyPositionOdd))
                {
                    GameObject objOdd = Instantiate(gridPrefab, new Vector3(leftBottomLocationOdd.x + scaleX * i, (leftBottomLocationOdd.y + scaleY * j) + 0.6f, leftBottomLocationOdd.z), Quaternion.identity);
                    objOdd.transform.SetParent(gameObject.transform);
                }                                                     
            }
        }
    }

    void GenerateGridEven()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3Int cellPositionEven = grid.WorldToCell(new Vector3(leftBottomLocationEven.x + scaleX * i, (leftBottomLocationEven.y + scaleY * j), leftBottomLocationEven.z));
                Vector3Int cellDestroyPositionEven = grid.WorldToCell(new Vector3(leftBottomLocationEven.x + scaleX * i, (leftBottomLocationEven.y + scaleY * j) + 0.6f, leftBottomLocationEven.z));

                if (groundTile.HasTile(cellPositionEven) && wallTile.HasTile(cellDestroyPositionEven))
                {
                    GameObject obj = Instantiate(gridPrefab, new Vector3(leftBottomLocationEven.x + scaleX * i, (leftBottomLocationEven.y + scaleY * j) + 0.6f, leftBottomLocationEven.z), Quaternion.identity);
                    obj.transform.SetParent(gameObject.transform);
                }
            }
        }
    }
}
