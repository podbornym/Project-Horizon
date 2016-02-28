using UnityEngine;
using System.Collections;

public class MatchThreeInput : MonoBehaviour {
    private MatchThreeManager gridManager;
    public LayerMask tiles;
    public GameObject activeTile;

	void Awake()
    {
        gridManager = GetComponent<MatchThreeManager>();
    }
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButtonDown(0))
        {
            if(activeTile == null)
            {
                SelectTile();
            }

            else
            {
                AttemptMove();
            }
        }
	}

    void SelectTile()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //Ray2D ray = new Ray2D(transform.position, mousePosition);
        //RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(tiles.value, tiles.value));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, tiles.value);
        //RaycastHit2D hit = Physics2D.Raycast(ray, 50f, tiles);

        if(hit)
        {
            activeTile = hit.collider.gameObject;
            print("raycast hit");
        }
    }

    void AttemptMove()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit2D hit = GetRayIntersection(ray, 50f, tiles);
        //Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //RaycastHit2D hit = Physics2D.Raycast(mousePosition, new Vector2(tiles.value, tiles.value));
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, tiles.value);
        //RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        //print(tiles.GetType());

        if (hit)
        {
            if(NeighborCheck(hit.collider.gameObject))
            {
                activeTile.gameObject.GetComponent<MatchThreeInput>().Move(hit.collider.gameObject.transform.position);
                print("attempted move");
                hit.collider.gameObject.GetComponent<MatchThreeInput>().Move(activeTile.transform.position);
                gridManager.CheckMatches();
            }
        }
    }

    bool NeighborCheck(GameObject objectToCheck)
    {
        float xDifference = Mathf.Abs(activeTile.transform.position.x - objectToCheck.transform.position.x);
        float yDifference = Mathf.Abs(activeTile.transform.position.y - objectToCheck.transform.position.y);

        if (xDifference + yDifference == 1)
            return true;
        
        else
            return false;
        
    }

    public void Move(Vector2 destination)
    {
        transform.position = destination;
    }
}