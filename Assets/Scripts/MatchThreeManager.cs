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

    public void CheckMatches()
    {
        ArrayList matchPositions = new ArrayList();
        int currentTile = 0;
        int lastTile = 0;
        int secondToLastTile = 0;

        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                currentTile = grid[x,y];

                if(currentTile == lastTile && lastTile == secondToLastTile)
                {
                    matchPositions.Add(new Vector2(x,y));
                    secondToLastTile = lastTile;
                    lastTile = currentTile;
                }
            }
            //same for horizontal
        }

        if(matchPositions.Count > 0)
        {
            ArrayList tilesToDestroy = new ArrayList();

            foreach(Vector2 tilePosition in matchPositions)
            {
                //raycast

            }
            //destroy (set to 0, send message to older method?)
        }
    }

    void ReplaceTiles()
    {
        for(int x = 0; x <gridWidth; x++)
        {
            int missingTileCount = 0;

            for(int y = 0; y < gridHeight; y++)
            {
                if(grid[x,y] == -1)
                {
                    missingTileCount++;
                }
            }

            for(int i = 0; i < missingTileCount; i++)
            {
                int randomTileID = Random.Range(0, tilePrefabs.Length);
                Instantiate(tilePrefabs[randomTileID], new Vector2 (x, gridHeight + i), Quaternion.identity);
            }
        }
    }
}
