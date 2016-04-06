using UnityEngine;
using System.Collections;

public class PipeRotator : MonoBehaviour {

    public bool PipeConnection = false;
    public bool IsFull = false;
    public bool CanRotate = true;
    public PipeDreamManager manager;
    public int[,] tileGrid;
    public int width;
    public int height;
    public Sprite filled;
    public GameObject ObjectManager;

    void Awake()
    {
        ObjectManager = GameObject.Find("Pipe Dream Manager");
        ObjectManager.GetComponent<PipeDreamManager>().objectGrid.Add(gameObject);
    }

    // Use this for initialization
    void Start () {
        /*width  = manager.GetComponent<PipeDreamManager>().gridWidth;
        height = manager.GetComponent<PipeDreamManager>().gridHeight;
        tileGrid = manager.GetComponent<PipeDreamManager>().grid;*/
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Checks if the tile is full
        //If full changes sprite
        //Sets CanRotate to false
        //This is only temporary for prototyping
        if (IsFull)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = filled;
            CanRotate = false;
        }
	}

    //Called on click with collider
    void OnMouseDown()
    {
        //Checks if the tile can rotate
        if(CanRotate)
        {
            //Rotates tile 90* clockwise
            transform.Rotate(new Vector3(0f, 0f, -90f));
            //Checks tag of tile
            //If tag is Straight
            if (gameObject.tag == "Straight")
            {
                //If piece is vertically alligned
                if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == 90)
                {
                    //Calls CheckUp and CheckDown
                    CheckUp();
                    CheckDown();
                }
                //If piece is horizontally alligned
                else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
                {
                    //Calls CheckLeft and CheckRight
                    CheckLeft();
                    CheckRight();
                }
            }
            //If tag is Turn
            else if (gameObject.tag == "Turn")
            {
                //If piece goes from left to up
                if (transform.rotation.eulerAngles.z == 270)
                {
                    //Calls CheckLeft and CheckUp
                    CheckLeft();
                    CheckUp();
                }
                //If piece goes from up to right
                else if (transform.rotation.eulerAngles.z == 180)
                {
                    //Calls CheckUp and CheckRight
                    CheckUp();
                    CheckRight();
                }
                //If piece goes from Right to Down
                else if (transform.rotation.eulerAngles.z == 90)
                {
                    //Calls CheckRight and CheckDown
                    CheckRight();
                    CheckDown();
                }
                //If piece goes from Down to Left
                else if (transform.rotation.eulerAngles.z == 0)
                {
                    //Calls CheckDown and CheckLeft
                    CheckDown();
                    CheckLeft();
                }
            }
            //If tag is FourWay
            else if (gameObject.tag == "FourWay")
            {
                //If piece is horizontally alligned
                if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == 90)
                {
                    //Calls Check*
                    CheckUp();
                    CheckDown();
                    CheckLeft();
                    CheckRight();
                }
                //If piece is vertically alligned
                else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
                {
                    //Calls Check*
                    CheckUp();
                    CheckDown();
                    CheckLeft();
                    CheckRight();
                }
            }
        }
    }

    //Checks the tile above the selected
    void CheckUp()
    {
        //Raycasts 1 space above selected tile
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.up);
        //If raycast hits
        if (hitUp)
        {
            //If hit piece is tagged Straight
            if (hitUp.transform.gameObject.tag == "Straight")
            {
                //If hit piece is full
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit piece alligned with top of selected
                    if (hitUp.transform.rotation.eulerAngles.z == 270 || hitUp.transform.rotation.eulerAngles.z == 90)
                    {
                        //Fills selected piece
                        IsFull = true;
                    }
                }
            }
            //If hit piece is tagged Turn
            else if (hitUp.transform.gameObject.tag == "Turn")
            {
                //If hit piece is full
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit piece alligned with top of selected
                    if (hitUp.transform.rotation.eulerAngles.z == 90 || hitUp.transform.rotation.eulerAngles.z == 0)
                    {
                        //Fills selected piece
                        IsFull = true;
                    }
                }
            }
            //If hit piece is tagged FourWay
            else if (hitUp.transform.gameObject.tag == "FourWay")
            {
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitUp.transform.rotation.eulerAngles.z == 270 || hitUp.transform.rotation.eulerAngles.z == 90 || hitUp.transform.rotation.eulerAngles.z == 180 || hitUp.transform.rotation.eulerAngles.z == 0)
                    {
                        RaycastHit2D hitUp2 = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.up);
                        if (hitUp2.transform.gameObject.tag == "Straight")
                        {
                            if (hitUp2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitUp2.transform.rotation.eulerAngles.z == 270 || hitUp2.transform.rotation.eulerAngles.z == 90)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                        else if (hitUp2.transform.gameObject.tag == "Turn")
                        {
                            if (hitUp2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitUp2.transform.rotation.eulerAngles.z == 90 || hitUp2.transform.rotation.eulerAngles.z == 0)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void CheckDown()
    {
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.down);
        if (hitDown)
        {
            if (hitDown.transform.gameObject.tag == "Straight")
            {
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 90)
                    {
                        IsFull = true;
                    }
                }
            }
            else if (hitDown.transform.gameObject.tag == "Turn")
            {
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 180)
                    {
                        IsFull = true;
                    }
                }
            }
            else if (hitDown.transform.gameObject.tag == "FourWay")
            {
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 90 || hitDown.transform.rotation.eulerAngles.z == 180 || hitDown.transform.rotation.eulerAngles.z == 0)
                    {
                        RaycastHit2D hitDown2 = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), Vector2.up);
                        if (hitDown2.transform.gameObject.tag == "Straight")
                        {
                            if (hitDown2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitDown2.transform.rotation.eulerAngles.z == 270 || hitDown2.transform.rotation.eulerAngles.z == 90)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                        else if (hitDown2.transform.gameObject.tag == "Turn")
                        {
                            if (hitDown2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitDown2.transform.rotation.eulerAngles.z == 270 || hitDown2.transform.rotation.eulerAngles.z == 180)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
    void CheckLeft()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), Vector2.left);
        if (hitLeft)
        {
            if (hitLeft.transform.gameObject.tag == "Start")
            {
                IsFull = true;
            }
            else if (hitLeft.transform.gameObject.tag == "Straight")
            {
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 0)
                    {
                        IsFull = true;
                    }
                }
            }
            else if (hitLeft.transform.gameObject.tag == "Turn")
            {
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 90)
                    {
                        IsFull = true;
                    }
                }
            }
            else if (hitLeft.transform.gameObject.tag == "FourWay")
            {
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitLeft.transform.rotation.eulerAngles.z == 270 || hitLeft.transform.rotation.eulerAngles.z == 90 || hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 0)
                    {
                        RaycastHit2D hitLeft2 = Physics2D.Raycast(transform.position + new Vector3(-2, 0, 0), Vector2.up);
                        if (hitLeft2.transform.gameObject.tag == "Start")
                        {
                            IsFull = true;
                        }
                        else if (hitLeft2.transform.gameObject.tag == "Straight")
                        {
                            if (hitLeft2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitLeft2.transform.rotation.eulerAngles.z == 180 || hitLeft2.transform.rotation.eulerAngles.z == 0)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                        else if (hitLeft2.transform.gameObject.tag == "Turn")
                        {
                            if (hitLeft2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitLeft2.transform.rotation.eulerAngles.z == 180 || hitLeft2.transform.rotation.eulerAngles.z == 90)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    void CheckRight()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right); if (hitRight)
        {
            if (hitRight.transform.gameObject.tag == "Start")
            {
                IsFull = true;
            }
            if (hitRight.transform.gameObject.tag == "Straight")
            {
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitRight.transform.rotation.eulerAngles.z == 180 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        IsFull = true;
                    }
                }
            }
            else if (hitRight.transform.gameObject.tag == "Turn")
            {
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitRight.transform.rotation.eulerAngles.z == 270 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        IsFull = true;
                    }
                }
            }
            else if (hitRight.transform.gameObject.tag == "FourWay")
            {
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    if (hitRight.transform.rotation.eulerAngles.z == 270 || hitRight.transform.rotation.eulerAngles.z == 90 || hitRight.transform.rotation.eulerAngles.z == 180 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        RaycastHit2D hitRight2 = Physics2D.Raycast(transform.position + new Vector3(2, 0, 0), Vector2.up);
                        if (hitRight2.transform.gameObject.tag == "Straight")
                        {
                            if (hitRight2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitRight2.transform.rotation.eulerAngles.z == 180 || hitRight2.transform.rotation.eulerAngles.z == 0)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                        else if (hitRight2.transform.gameObject.tag == "Turn")
                        {
                            if (hitRight2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                            {
                                if (hitRight2.transform.rotation.eulerAngles.z == 270 || hitRight2.transform.rotation.eulerAngles.z == 0)
                                {
                                    IsFull = true;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}