using UnityEngine;
using System.Collections;

public class PipeRotator : MonoBehaviour {

    public bool IsConnected = false;
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

        if (gameObject.tag == "End")
        {
            if(CheckLeft())
            {
                IsConnected = true;
            }
        }

        //Checks tag of tile
        //If tag is Straight
        if (gameObject.tag == "Straight")
        {
            //If piece is vertically alligned
            if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == 90)
            {
                //Calls CheckUp and CheckDown
                if (CheckUp() || CheckDown())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
            //If piece is horizontally alligned
            else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
            {
                //Calls CheckLeft and CheckRight
                if (CheckLeft() || CheckRight())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
        }
        //If tag is Turn
        else if (gameObject.tag == "Turn")
        {
            //If piece goes from Left to Up
            if (transform.rotation.eulerAngles.z == 270)
            {
                //Calls CheckLeft and CheckUp
                if (CheckLeft() || CheckUp())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
            //If piece goes from up to right
            else if (transform.rotation.eulerAngles.z == 180)
            {
                //Calls CheckUp and CheckRight
                if (CheckUp() || CheckRight())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
            //If piece goes from Right to Down
            else if (transform.rotation.eulerAngles.z == 90)
            {
                //Calls CheckRight and CheckDown
                if (CheckRight() || CheckDown())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
            //If piece goes from Down to Left
            else if (transform.rotation.eulerAngles.z == 0)
            {
                //Calls CheckDown and CheckLeft
                if (CheckDown() || CheckLeft())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
        }
        //If tag is FourWay
        else if (gameObject.tag == "FourWay")
        {
            //If piece is horizontally alligned
            if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == 90)
            {
                //Calls Check*
                if (CheckUp() || CheckDown() || CheckLeft() || CheckRight())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
            //If piece is vertically alligned
            else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
            {
                //Calls Check*
                if (CheckUp() || CheckDown() || CheckLeft() || CheckRight())
                {
                    IsConnected = true;
                }
                else
                {
                    IsConnected = false;
                }
            }
        }
    }
    /*
    OnMouseDown simultaneously rotates the tiles and
    checks to see if they can be filled. If they can
    be filled then it will set their bool to true
    where the update function takes over and changes
    the sprite to full.

    In the final version of this code, instead of
    setting the full bool to true, it will check
    whether or not the pipes are connected as the
    liquid flows through them.
    */

    //Called on left mouse down while on a collider
    void OnMouseDown()
    {
        for(int i = 0; i < ObjectManager.GetComponent<PipeDreamManager>().objectGrid.Count; i++)
        {
            ObjectManager.GetComponent<PipeDreamManager>().objectGrid[i].GetComponent<PipeRotator>().IsConnected = false;
        }
        for(int i = 0; i < ObjectManager.GetComponent<PipeDreamManager>().objectGrid.Count; i++)
        {
            if(ObjectManager.GetComponent<PipeDreamManager>().objectGrid[i].gameObject.tag == "Start")
            {
                ObjectManager.GetComponent<PipeDreamManager>().objectGrid[i].GetComponent<PipeRotator>().IsConnected = true;
            }
        }

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
                    if (CheckUp() || CheckDown())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
                //If piece is horizontally alligned
                else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
                {
                    //Calls CheckLeft and CheckRight
                    if (CheckLeft() || CheckRight())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
            }
            //If tag is Turn
            else if (gameObject.tag == "Turn")
            {
                //If piece goes from Left to Up
                if (transform.rotation.eulerAngles.z == 270)
                {
                    //Calls CheckLeft and CheckUp
                    if (CheckLeft() || CheckUp())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
                //If piece goes from up to right
                else if (transform.rotation.eulerAngles.z == 180)
                {
                    //Calls CheckUp and CheckRight
                    if (CheckUp() || CheckRight())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
                //If piece goes from Right to Down
                else if (transform.rotation.eulerAngles.z == 90)
                {
                    //Calls CheckRight and CheckDown
                    if (CheckRight() || CheckDown())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
                //If piece goes from Down to Left
                else if (transform.rotation.eulerAngles.z == 0)
                {
                    //Calls CheckDown and CheckLeft
                    if (CheckDown() || CheckLeft())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
            }
            //If tag is FourWay
            else if (gameObject.tag == "FourWay")
            {
                //If piece is horizontally alligned
                if (transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == 90)
                {
                    //Calls Check*
                    if (CheckUp() || CheckDown() || CheckLeft() || CheckRight())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
                //If piece is vertically alligned
                else if (transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
                {
                    //Calls Check*
                    if (CheckUp() || CheckDown() || CheckLeft() || CheckRight())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
            }
        }
    }

    //Checks the tile above the selected
    public bool CheckUp()
    {
        //Raycasts 1 space above selected tile
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.up);
        //If raycast hits
        if (hitUp.collider != null)
        {
            //If hit piece is tagged Straight
            if (hitUp.transform.gameObject.tag == "Straight")
            {
                //If hit piece is full
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit piece alligned with top of selected
                    if (hitUp.transform.rotation.eulerAngles.z == 270 || hitUp.transform.rotation.eulerAngles.z == 90)
                    {
                        return true;
                    }
                }
            }
            //If hit piece is tagged Turn
            else if (hitUp.transform.gameObject.tag == "Turn")
            {
                //If hit piece is full
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit piece alligned with top of selected
                    if (hitUp.transform.rotation.eulerAngles.z == 90 || hitUp.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit piece is tagged FourWay
            else if (hitUp.transform.gameObject.tag == "FourWay")
            {
                //If piece is full
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit piece alligned with top of selected
                    if (hitUp.transform.rotation.eulerAngles.z == 270 || hitUp.transform.rotation.eulerAngles.z == 90 || hitUp.transform.rotation.eulerAngles.z == 180 || hitUp.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space above FourWay
                        RaycastHit2D hitUp2 = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.up);
                        //If hit2
                        if (hitUp2.collider != null)
                        {
                            //If piece is tagged Straight
                            if (hitUp2.transform.gameObject.tag == "Straight")
                            {
                                //If piece is full
                                if (hitUp2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If piece is aligned with the FourWay
                                    if (hitUp2.transform.rotation.eulerAngles.z == 270 || hitUp2.transform.rotation.eulerAngles.z == 90)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If piece is tagged Turn
                            else if (hitUp2.transform.gameObject.tag == "Turn")
                            {
                                //If piece is full
                                if (hitUp2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If piece is aligned with the FourWay
                                    if (hitUp2.transform.rotation.eulerAngles.z == 90 || hitUp2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            /*
                            The code does not check to see if there is another Fourway to 
                            prevent an infinite cycle of checking the next piece, due to 
                            the nature of FourWay pieces. This will however prevent a piece
                            from becoming full if it is connected to two FourWays in a row.

                            This can potentially be solved with a recursive function, but
                            since the levels are hand built it is inconsequential.
                            */
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }

    //Checks the tile below the selected
    public bool CheckDown()
    {
        //Raycasts 1 space below the selected tile
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.down);
        //If the raycast hits
        if (hitDown.collider != null)
        {
            //If the hit piece is tagged Straight
            if (hitDown.transform.gameObject.tag == "Straight")
            {
                //If the hit piece is full
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If the hit piece is aligned with the selected
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 90)
                    {
                        return true;
                    }
                }
            }
            //If the hit piece is tagged Turn
            else if (hitDown.transform.gameObject.tag == "Turn")
            {
                //If the hit piece is full
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If the hit piece is aligned with the selected
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 180)
                    {
                        return true;
                    }
                }
            }
            //If the hit piece is tagged FourWay
            else if (hitDown.transform.gameObject.tag == "FourWay")
            {
                //If the hit piece is full
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If the hit piece is aligned with the selected
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 90 || hitDown.transform.rotation.eulerAngles.z == 180 || hitDown.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space below the FourWay
                        RaycastHit2D hitDown2 = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), Vector2.up);
                        //If raycast his
                        if (hitDown2.collider != null)
                        {
                            //If hit piece is tagged Straight
                            if (hitDown2.transform.gameObject.tag == "Straight")
                            {
                                //If hit piece is full
                                if (hitDown2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If hit piece is aligned with FourWay
                                    if (hitDown2.transform.rotation.eulerAngles.z == 270 || hitDown2.transform.rotation.eulerAngles.z == 90)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If hit piece is tagged Turn
                            else if (hitDown2.transform.gameObject.tag == "Turn")
                            {
                                //If hit piece is full
                                if (hitDown2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If hit piece is aligned with FourWay
                                    if (hitDown2.transform.rotation.eulerAngles.z == 270 || hitDown2.transform.rotation.eulerAngles.z == 180)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }
    
    //Checks the tile to the left of the selected
    public bool CheckLeft()
    {
        //Raycasts 1 space to the left of the selected
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), Vector2.left);
        //If raycast hits
        if (hitLeft.collider != null)
        {
            /*
            The check for the Start tile will only be within
            the CheckLeft() function because the Start tile
            will only ever be on the left hand side of the
            board.

            If a change is wanted this if statement can be used
            in the other functions, simply changing the name
            of the raycast to the corresponding check.
            */

            //If hit is tagged Start
            if (hitLeft.transform.gameObject.tag == "Start")
            {
                //Sets selected to full
                return true;
            }
            //If hit is tagged Straight
            else if (hitLeft.transform.gameObject.tag == "Straight")
            {
                //If hit is full
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit is aligned with selected
                    if (hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged Turn
            else if (hitLeft.transform.gameObject.tag == "Turn")
            {
                //If hit is full
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit is aligned with selected
                    if (hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 90)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged FourWay
            else if (hitLeft.transform.gameObject.tag == "FourWay")
            {
                //IF hit is full
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit is aligned with selected
                    if (hitLeft.transform.rotation.eulerAngles.z == 270 || hitLeft.transform.rotation.eulerAngles.z == 90 || hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space to left of FourWay
                        RaycastHit2D hitLeft2 = Physics2D.Raycast(transform.position + new Vector3(-2, 0, 0), Vector2.up);
                        //If hit
                        if (hitLeft2.collider != null)
                        {
                            //If hit is tagged Start
                            if (hitLeft2.transform.gameObject.tag == "Start")
                            {
                                return true;
                            }
                            //If hit is tagged Straight
                            else if (hitLeft2.transform.gameObject.tag == "Straight")
                            {
                                //If hit is full
                                if (hitLeft2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If hit is aligned with FourWay
                                    if (hitLeft2.transform.rotation.eulerAngles.z == 180 || hitLeft2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If hit is tagged Turn
                            else if (hitLeft2.transform.gameObject.tag == "Turn")
                            {
                                //If hit is full
                                if (hitLeft2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If hit is aligned with FourWay
                                    if (hitLeft2.transform.rotation.eulerAngles.z == 180 || hitLeft2.transform.rotation.eulerAngles.z == 90)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }

    //Checks the tile to the right of the selected
    public bool CheckRight()
    {
        //Rays casts 1 space to right of the selected
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right);
        //If hits
        if (hitRight.collider != null)
        {
            //If hit is tagged Straight
            if (hitRight.transform.gameObject.tag == "Straight")
            {
                //If hit is full
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit is aligned with selected
                    if (hitRight.transform.rotation.eulerAngles.z == 180 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged Turn
            else if (hitRight.transform.gameObject.tag == "Turn")
            {
                //If hit is full
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit is aligned with selected
                    if (hitRight.transform.rotation.eulerAngles.z == 270 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged FourWay
            else if (hitRight.transform.gameObject.tag == "FourWay")
            {
                //If hit is full
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                {
                    //If hit is aligned with selected
                    if (hitRight.transform.rotation.eulerAngles.z == 270 || hitRight.transform.rotation.eulerAngles.z == 90 || hitRight.transform.rotation.eulerAngles.z == 180 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space to the right of the FourWay
                        RaycastHit2D hitRight2 = Physics2D.Raycast(transform.position + new Vector3(2, 0, 0), Vector2.up);
                        //If hit
                        if (hitRight2.collider != null)
                        {
                            //If hit is tagged Straight
                            if (hitRight2.transform.gameObject.tag == "Straight")
                            {
                                //If hit is full
                                if (hitRight2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If hit is aligned with Fourway
                                    if (hitRight2.transform.rotation.eulerAngles.z == 180 || hitRight2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If hit is tagged Turn
                            else if (hitRight2.transform.gameObject.tag == "Turn")
                            {
                                //If hit is full
                                if (hitRight2.transform.gameObject.GetComponent<PipeRotator>().IsConnected)
                                {
                                    //If hit is aligned with FourWay
                                    if (hitRight2.transform.rotation.eulerAngles.z == 270 || hitRight2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }

    public bool CheckUpFull()
    {
        //Raycasts 1 space above selected tile
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + new Vector3(0, 1, 0), Vector2.up);
        //If raycast hits
        if (hitUp.collider != null)
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
                        return true;
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
                        return true;
                    }
                }
            }
            //If hit piece is tagged FourWay
            else if (hitUp.transform.gameObject.tag == "FourWay")
            {
                //If piece is full
                if (hitUp.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit piece alligned with top of selected
                    if (hitUp.transform.rotation.eulerAngles.z == 270 || hitUp.transform.rotation.eulerAngles.z == 90 || hitUp.transform.rotation.eulerAngles.z == 180 || hitUp.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space above FourWay
                        RaycastHit2D hitUp2 = Physics2D.Raycast(transform.position + new Vector3(0, 2, 0), Vector2.up);
                        //If hit2
                        if (hitUp2.collider != null)
                        {
                            //If piece is tagged Straight
                            if (hitUp2.transform.gameObject.tag == "Straight")
                            {
                                //If piece is full
                                if (hitUp2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If piece is aligned with the FourWay
                                    if (hitUp2.transform.rotation.eulerAngles.z == 270 || hitUp2.transform.rotation.eulerAngles.z == 90)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If piece is tagged Turn
                            else if (hitUp2.transform.gameObject.tag == "Turn")
                            {
                                //If piece is full
                                if (hitUp2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If piece is aligned with the FourWay
                                    if (hitUp2.transform.rotation.eulerAngles.z == 90 || hitUp2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            /*
                            The code does not check to see if there is another Fourway to 
                            prevent an infinite cycle of checking the next piece, due to 
                            the nature of FourWay pieces. This will however prevent a piece
                            from becoming full if it is connected to two FourWays in a row.

                            This can potentially be solved with a recursive function, but
                            since the levels are hand built it is inconsequential.
                            */
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }

    //Checks the tile below the selected
    public bool CheckDownFull()
    {
        //Raycasts 1 space below the selected tile
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0, -1, 0), Vector2.down);
        //If the raycast hits
        if (hitDown.collider != null)
        {
            //If the hit piece is tagged Straight
            if (hitDown.transform.gameObject.tag == "Straight")
            {
                //If the hit piece is full
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If the hit piece is aligned with the selected
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 90)
                    {
                        return true;
                    }
                }
            }
            //If the hit piece is tagged Turn
            else if (hitDown.transform.gameObject.tag == "Turn")
            {
                //If the hit piece is full
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If the hit piece is aligned with the selected
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 180)
                    {
                        return true;
                    }
                }
            }
            //If the hit piece is tagged FourWay
            else if (hitDown.transform.gameObject.tag == "FourWay")
            {
                //If the hit piece is full
                if (hitDown.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If the hit piece is aligned with the selected
                    if (hitDown.transform.rotation.eulerAngles.z == 270 || hitDown.transform.rotation.eulerAngles.z == 90 || hitDown.transform.rotation.eulerAngles.z == 180 || hitDown.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space below the FourWay
                        RaycastHit2D hitDown2 = Physics2D.Raycast(transform.position + new Vector3(0, -2, 0), Vector2.up);
                        //If raycast his
                        if (hitDown2.collider != null)
                        {
                            //If hit piece is tagged Straight
                            if (hitDown2.transform.gameObject.tag == "Straight")
                            {
                                //If hit piece is full
                                if (hitDown2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If hit piece is aligned with FourWay
                                    if (hitDown2.transform.rotation.eulerAngles.z == 270 || hitDown2.transform.rotation.eulerAngles.z == 90)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If hit piece is tagged Turn
                            else if (hitDown2.transform.gameObject.tag == "Turn")
                            {
                                //If hit piece is full
                                if (hitDown2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If hit piece is aligned with FourWay
                                    if (hitDown2.transform.rotation.eulerAngles.z == 270 || hitDown2.transform.rotation.eulerAngles.z == 180)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }

    //Checks the tile to the left of the selected
    public bool CheckLeftFull()
    {
        //Raycasts 1 space to the left of the selected
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-1, 0, 0), Vector2.left);
        //If raycast hits
        if (hitLeft.collider != null)
        {
            /*
            The check for the Start tile will only be within
            the CheckLeft() function because the Start tile
            will only ever be on the left hand side of the
            board.

            If a change is wanted this if statement can be used
            in the other functions, simply changing the name
            of the raycast to the corresponding check.
            */

            //If hit is tagged Start
            if (hitLeft.transform.gameObject.tag == "Start")
            {
                //Sets selected to full
                return true;
            }
            //If hit is tagged Straight
            else if (hitLeft.transform.gameObject.tag == "Straight")
            {
                //If hit is full
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit is aligned with selected
                    if (hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged Turn
            else if (hitLeft.transform.gameObject.tag == "Turn")
            {
                //If hit is full
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit is aligned with selected
                    if (hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 90)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged FourWay
            else if (hitLeft.transform.gameObject.tag == "FourWay")
            {
                //IF hit is full
                if (hitLeft.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit is aligned with selected
                    if (hitLeft.transform.rotation.eulerAngles.z == 270 || hitLeft.transform.rotation.eulerAngles.z == 90 || hitLeft.transform.rotation.eulerAngles.z == 180 || hitLeft.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space to left of FourWay
                        RaycastHit2D hitLeft2 = Physics2D.Raycast(transform.position + new Vector3(-2, 0, 0), Vector2.up);
                        //If hit
                        if (hitLeft2.collider != null)
                        {
                            //If hit is tagged Start
                            if (hitLeft2.transform.gameObject.tag == "Start")
                            {
                                return true;
                            }
                            //If hit is tagged Straight
                            else if (hitLeft2.transform.gameObject.tag == "Straight")
                            {
                                //If hit is full
                                if (hitLeft2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If hit is aligned with FourWay
                                    if (hitLeft2.transform.rotation.eulerAngles.z == 180 || hitLeft2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If hit is tagged Turn
                            else if (hitLeft2.transform.gameObject.tag == "Turn")
                            {
                                //If hit is full
                                if (hitLeft2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If hit is aligned with FourWay
                                    if (hitLeft2.transform.rotation.eulerAngles.z == 180 || hitLeft2.transform.rotation.eulerAngles.z == 90)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }

    //Checks the tile to the right of the selected
    public bool CheckRightFull()
    {
        //Rays casts 1 space to right of the selected
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(1, 0, 0), Vector2.right);
        //If hits
        if (hitRight.collider != null)
        {
            //If hit is tagged Straight
            if (hitRight.transform.gameObject.tag == "Straight")
            {
                //If hit is full
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit is aligned with selected
                    if (hitRight.transform.rotation.eulerAngles.z == 180 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged Turn
            else if (hitRight.transform.gameObject.tag == "Turn")
            {
                //If hit is full
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit is aligned with selected
                    if (hitRight.transform.rotation.eulerAngles.z == 270 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        return true;
                    }
                }
            }
            //If hit is tagged FourWay
            else if (hitRight.transform.gameObject.tag == "FourWay")
            {
                //If hit is full
                if (hitRight.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                {
                    //If hit is aligned with selected
                    if (hitRight.transform.rotation.eulerAngles.z == 270 || hitRight.transform.rotation.eulerAngles.z == 90 || hitRight.transform.rotation.eulerAngles.z == 180 || hitRight.transform.rotation.eulerAngles.z == 0)
                    {
                        //Raycasts 1 space to the right of the FourWay
                        RaycastHit2D hitRight2 = Physics2D.Raycast(transform.position + new Vector3(2, 0, 0), Vector2.up);
                        //If hit
                        if (hitRight2.collider != null)
                        {
                            //If hit is tagged Straight
                            if (hitRight2.transform.gameObject.tag == "Straight")
                            {
                                //If hit is full
                                if (hitRight2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If hit is aligned with Fourway
                                    if (hitRight2.transform.rotation.eulerAngles.z == 180 || hitRight2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                            //If hit is tagged Turn
                            else if (hitRight2.transform.gameObject.tag == "Turn")
                            {
                                //If hit is full
                                if (hitRight2.transform.gameObject.GetComponent<PipeRotator>().IsFull)
                                {
                                    //If hit is aligned with FourWay
                                    if (hitRight2.transform.rotation.eulerAngles.z == 270 || hitRight2.transform.rotation.eulerAngles.z == 0)
                                    {
                                        return true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        return false;
    }
}