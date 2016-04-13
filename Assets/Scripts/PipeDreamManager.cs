using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeDreamManager : MonoBehaviour {
    public int gridWidth = 6;
    public int gridHeight = 6;
    public int[,] grid;

    public GameObject[] tilePrefabs;
    GameObject end;
    GameObject start;

    public List<GameObject> objectGrid = new List<GameObject>();

    public PipeRotator rotator;

    public bool gameRunning = true;
    //public int[] randomAngles = new int[4] { 0, 90, 180, 270 };


    void Awake()
    {
        CreateGrid();
    }
	// Use this for initialization
	void Start () {
        print((int)Time.time);

        StartCoroutine(Flow());
        if (end == null)
        {
            end = GameObject.FindWithTag("End");
        }
        if (start == null)
        {
            start = GameObject.FindWithTag("Start");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (gameRunning)
        {
            if(end.GetComponent<PipeRotator>().IsConnected)
            {
                for (int i = 2; i < objectGrid.Count; i++)
                {
                    if(objectGrid[i].GetComponent<PipeRotator>().IsConnected)
                    {
                        objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                    }
                }
                end.GetComponent<PipeRotator>().IsFull = true;
            }
            if (end.GetComponent<PipeRotator>().IsFull)
            {
                gameRunning = false;
                print("Game Over");
            }
        }
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

    IEnumerator Flow()
    {
        while (gameRunning)
        {
            yield return new WaitForSeconds(3);
            print((int)Time.time);

            
        }
    }
}
