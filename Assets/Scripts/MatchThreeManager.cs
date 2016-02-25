using UnityEngine;
using System.Collections;

public class MatchThreeManager : MonoBehaviour {
    public int gridWidth = 4;
    public int gridHeight = 4;
    public int[,] grid;
    public GameObject[] tilePrefabs;

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

        for(int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                int randomTile = Random.Range(0, tilePrefabs.Length);
                grid[x, y] = randomTile;
                Instantiate(tilePrefabs[randomTile], new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
