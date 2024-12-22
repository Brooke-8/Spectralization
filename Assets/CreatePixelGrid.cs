using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreatePixelGrid : MonoBehaviour
{
    public int gridSizeX = 64;
    public int gridSizeY = 64;
    public static int[,] grid;
    public static GameObject[,] pixelGrid;
    public float squareSizeX = 0.2f;
    public float squareSizeY = 0.05f;
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        grid = new int[gridSizeX,gridSizeY];
        pixelGrid = new GameObject[gridSizeX,gridSizeY];
        for (int i = 0; i < gridSizeX; i++)
        {
            for (int j = 0; j < gridSizeY; j++)
            {
                grid[i,j] = 0;
            }
        }
        CreateGrid();
    }

    void CreateGrid()
    {
        Vector3 objectLocation = transform.position;

        for (int x =0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                //Calculate position for each new square
                float posX = (x * squareSizeX)+objectLocation.x;
                float posY = (y * squareSizeY)+objectLocation.y;

                //Instantiate a copy of the prefab
                GameObject square = Instantiate(prefab, new Vector3(posX,posY,0),Quaternion.identity);
                square.transform.SetParent(transform);
                square.GetComponent<PixelCoords>().xCoord = x;
                square.GetComponent<PixelCoords>().yCoord = y;
                pixelGrid[x,y] = square;

            }
        }
    }
}
