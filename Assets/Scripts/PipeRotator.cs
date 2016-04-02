using UnityEngine;
using System.Collections;

public class PipeRotator : MonoBehaviour {

    public bool PipeConnection = false;
    public bool IsFull = false;
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
        //Checks if the tile is full, and if it is changes the sprite to be full. This is only temporary for prototyping.
        if (IsFull)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = filled;
        }
	}

    void OnMouseDown()
    {
        //Checks if the tile is not full, and if it is not the tile can rotate when clicked.
        if(IsFull == false)
        {
            transform.Rotate(new Vector3(0f, 0f, -90f));
            if(gameObject.tag == "Straight")
            {
                print("Straight");
                if(transform.rotation.eulerAngles.z == 270 || transform.rotation.eulerAngles.z == 90)
                {
                    print(transform.rotation.eulerAngles.z);
                }
                else if(transform.rotation.eulerAngles.z == 180 || transform.rotation.eulerAngles.z == 0)
                {
                    print(transform.rotation.eulerAngles.z);
                }
            }
            else if(gameObject.tag == "Turn")
            {
                print("Turn");
                if (transform.rotation.eulerAngles.z == 270)
                {
                    print(transform.rotation.eulerAngles.z);
                }
                else if (transform.rotation.eulerAngles.z == 180)
                {
                    print(transform.rotation.eulerAngles.z);
                }
                if (transform.rotation.eulerAngles.z == 90)
                {
                    print(transform.rotation.eulerAngles.z);
                }
                else if (transform.rotation.eulerAngles.z == 0)
                {
                    print(transform.rotation.eulerAngles.z);
                }
            }
            else if(gameObject.tag == "FourWay")
            {
                print("FourWay");
                print(transform.rotation.eulerAngles.z);
            }
        }
    }
}
