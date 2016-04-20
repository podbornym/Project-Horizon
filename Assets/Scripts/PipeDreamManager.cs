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
    public bool hitTile = true;
    //public int[] randomAngles = new int[4] { 0, 90, 180, 270 };


    void Awake()
    {
        //CreateGrid();
    }
	// Use this for initialization
	void Start () {

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
            if (end.GetComponent<PipeRotator>().IsConnected)
            {
                for (int i = 0; i < objectGrid.Count; i++)
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
        yield return new WaitForSeconds(4);
        while (gameRunning)
        {
            yield return new WaitForSeconds(4);
            for (int i = 0; i < objectGrid.Count; i++)
            {
                //Checks tag of tile
                //If tag is Straight
                if (objectGrid[i].GetComponent<PipeRotator>().gameObject.tag == "Straight")
                {
                    //If piece is vertically alligned
                    if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 270 ||  Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 90)
                    {
                        //Calls CheckUp and CheckDown
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckUpFull() || objectGrid[i].GetComponent<PipeRotator>().CheckDownFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                    //If piece is horizontally alligned
                    else if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 180 ||  Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 0)
                    {
                        //Calls CheckLeft and CheckRight
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckLeftFull() || objectGrid[i].GetComponent<PipeRotator>().CheckRightFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                }
                //If tag is Turn
                else if (objectGrid[i].GetComponent<PipeRotator>().gameObject.tag == "Turn")
                {
                    //If piece goes from Left to Up
                    if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 270)
                    {
                        //Calls CheckLeft and CheckUp
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckLeftFull() || objectGrid[i].GetComponent<PipeRotator>().CheckUpFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                    //If piece goes from up to right
                    else if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 180)
                    {
                        //Calls CheckUp and CheckRight
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckUpFull() || objectGrid[i].GetComponent<PipeRotator>().CheckRightFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                    //If piece goes from Right to Down
                    else if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 90)
                    {
                        //Calls CheckRight and CheckDown
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckRightFull() || objectGrid[i].GetComponent<PipeRotator>().CheckDownFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                    //If piece goes from Down to Left
                    else if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 0)
                    {
                        //Calls CheckDown and CheckLeft
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckDownFull() || objectGrid[i].GetComponent<PipeRotator>().CheckLeftFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                }
                //If tag is FourWay
                else if (objectGrid[i].GetComponent<PipeRotator>().gameObject.tag == "FourWay")
                {
                    //If piece is horizontally alligned
                    if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 270 ||  Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 90)
                    {
                        //Calls Check*
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckUpFull() || objectGrid[i].GetComponent<PipeRotator>().CheckDownFull() || objectGrid[i].GetComponent<PipeRotator>().CheckLeftFull() || objectGrid[i].GetComponent<PipeRotator>().CheckRightFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                    //If piece is vertically alligned
                    else if ( Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 180 ||  Approximately(objectGrid[i].GetComponent<PipeRotator>().transform.rotation.eulerAngles.z) == 0)
                    {
                        //Calls Check*
                        if (objectGrid[i].GetComponent<PipeRotator>().CheckUpFull() || objectGrid[i].GetComponent<PipeRotator>().CheckDownFull() || objectGrid[i].GetComponent<PipeRotator>().CheckLeftFull() || objectGrid[i].GetComponent<PipeRotator>().CheckRightFull())
                        {
                            if (objectGrid[i].GetComponent<PipeRotator>().IsFull == false)
                            {
                                objectGrid[i].GetComponent<PipeRotator>().IsFull = true;
                                hitTile = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    hitTile = false;
                }
            }
            if (hitTile == false)
            {
                print("Wow you suck, get good scrub");
                gameRunning = false;
            }
        }
    }

    int Approximately(float value)
    {
        if ((value < 45 && value >= 0) || (value <= 360 && value > 315))
        {
            return 0;
        }
        else if (value < 135 && value > 45)
        {
            return 90;
        }
        else if (value < 225 && value > 135)
        {
            return 180;
        }
        else if (value < 315 && value > 225)
        {
            return 270;
        }
        return 123456789;
    }
}
