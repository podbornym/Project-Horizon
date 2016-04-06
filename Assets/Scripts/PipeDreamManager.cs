using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeDreamManager : MonoBehaviour {
    public int gridWidth = 6;
    public int gridHeight = 6;
    public int[,] grid;
    public GameObject[] tilePrefabs;
    public List<GameObject> objectGrid = new List<GameObject>();
    //public int[] randomAngles = new int[4] { 0, 90, 180, 270 };


    void Awake()
    {
        CreateGrid();

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void CreateGrid()
    {
        grid = new int[gridWidth, gridHeight];
        for(int i = 0; i < gridWidth; i++)
        {
            for(int j = 0; j < gridHeight; j++)
            {
                //int randomAngle = Random.Range(0, 3);
                int randomTile = Random.Range(0, tilePrefabs.Length);
                grid[i, j] = randomTile;
                Instantiate(tilePrefabs[randomTile], new Vector2(i - 3, j - 2), Quaternion.identity);
            }
        }
    }
}
