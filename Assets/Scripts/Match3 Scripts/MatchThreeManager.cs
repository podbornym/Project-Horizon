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
                Instantiate(tilePrefabs[randomTile], new Vector2(x-3, y-2), Quaternion.identity);
            }
        }
    }

    public void CheckMatches()
    {
        ArrayList horizontalMatchPositions = new ArrayList();
        ArrayList verticalMatchPositions = new ArrayList();

        int currentTile = 0;
        int lastTile = 0;
        int secondToLastTile = 0;

        int horizCurrentTile = 0;
        int horizLastTile = 0;
        int horizSecondToLastTile = 0;

        for(int x = 0; x < gridWidth; x++)
        {
            for(int y = 0; y < gridHeight; y++)
            {
                currentTile = grid[x,y];

                if(currentTile == lastTile && lastTile == secondToLastTile)
                {
                    verticalMatchPositions.Add(new Vector2(x,y));
                }
                if(y==0)
                {
                    secondToLastTile = 0;
                    lastTile = 0;
                }
                else
                {
                    secondToLastTile = lastTile;
                    lastTile = currentTile;
                }
                
            }
            //same for horizontal
        }

        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                horizCurrentTile = grid[x, y];

                if (currentTile == lastTile && lastTile == secondToLastTile)
                {
                    horizontalMatchPositions.Add(new Vector2(x, y));
                }
                if (x == 0)
                {
                    horizSecondToLastTile = 0;
                    horizLastTile = 0;
                }
                else
                {
                    horizSecondToLastTile = horizLastTile;
                    horizLastTile = horizCurrentTile;
                }
                
            }
            //same for blahdeeblah
        }

        if(horizontalMatchPositions.Count > 0)
        {
            ArrayList tilesToDestroy = new ArrayList();

            foreach(Vector2 tilePosition in horizontalMatchPositions)
            {
                //raycast
                RaycastHit2D hit = Physics2D.Raycast(tilePosition, 3*Vector2.left);
                Destroy(hit.collider.gameObject);
            }
            //destroy (set to 0, send message to older method?)
            horizontalMatchPositions.Clear();
        }

        if (verticalMatchPositions.Count > 0)
        {
            ArrayList tilesToDestroy = new ArrayList();

            foreach (Vector2 tilePosition in verticalMatchPositions)
            {
                //raycast
                RaycastHit2D hit = Physics2D.Raycast(tilePosition, 3 * Vector2.up);
                Destroy(hit.collider.gameObject);
            }
            //destroy (set to 0, send message to older method?)
            verticalMatchPositions.Clear();
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
