using UnityEngine;
using System.Collections;

public class MatchThreeInput : MonoBehaviour {
    private MatchThreeManager gridManager;
    public LayerMask tiles;
    public GameObject activeTile;
    public GameObject movingTile;
    public Vector2 pos;

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
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);

        if(hit)
        {
            activeTile = hit.collider.gameObject;
            pos = activeTile.transform.position;
        }
    }

    void AttemptMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        
        if (hit)
        {
            if(NeighborCheck(hit.collider.gameObject))
            {
                
                movingTile = hit.collider.gameObject;
                Move(activeTile, movingTile);
                MoveOther(movingTile, pos);
                gridManager.CheckMatches();
                activeTile = null;
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

    public void Move(GameObject tile, GameObject destination)
    {
        tile.transform.position = destination.transform.position;
    }

    public void MoveOther(GameObject tile, Vector2 destination)
    {
        tile.transform.position = destination;
    }
}