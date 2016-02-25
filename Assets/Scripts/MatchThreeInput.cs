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

    /*void SelectTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, 50f, tiles);

        if(hit)
        {
            activeTile = hit.collider.gameObject;
        }
    }

    void AttemptMove()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = GetRayIntersection(ray, 50f, tiles);

        if (hit)
        {
            if(NeighborCheck(hit.collider.gameObject))
            {
                //activeTile.GetComponent<>().Move(hit.collider.gameObject.transform.position);
                //hit.collider.gameObject.GetComponent<>().Move(activeTile.transform.position);
                gridManager.CheckMatches();
            }
        }
    }

    bool NeighborCheck(GameObject.object)
    {
        int xDifference = Mathf.Abs (activeTile.transform.position.x - objectToCheck.transform.position.x);
        int yDifference = Mathf.Abs (activeTile.transform.position.y - objectToCheck.transform.position.y);

        if (xDifference + yDifference == 1)
            return true;
        else
            return false;
    }

    public void Move(Vector2 destination)
    {
        transform.position = destination;
    }*/
}