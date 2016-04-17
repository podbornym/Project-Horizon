using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PuzzlePiece : MonoBehaviour
{
    public float baseX;
    public float baseY;

    public Color color;

    public bool popped = false;
    public bool falling = false;

    public Animation animation;

    private List<GameObject> allPieces = new List<GameObject>();
    private BoardCreation boardScript;

    public float timeDragging = 0;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(baseX, baseY, 0), 0.1f);
        if (falling)
        {
            if (Mathf.Abs(transform.position.y - baseY) < 0.1f)
            {
                falling = false;
                return;
            }
        }
        if (!boardScript.dragging)
        {
            SnapToBase();
        }
    }

    void Start()
    {
        baseX = transform.position.x;
        baseY = transform.position.y;
        allPieces = GameObject.FindGameObjectsWithTag("PuzzlePiece").ToList();
        boardScript = GameObject.Find("Scripts").GetComponent<BoardCreation>();
        //animation.Play("PieceCreation");
    }

    void OnMouseDrag()
    {
        if (boardScript.spawning)
        {
            return;
        }
        boardScript.dragging = true;
        boardScript.spawning = false;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        allPieces = GameObject.FindGameObjectsWithTag("PuzzlePiece").ToList();
        for (int i = 0; i < allPieces.Count; i++)
        {
            if (allPieces[i] != gameObject)
            {
                if (Vector2.Distance(transform.position, allPieces[i].transform.position) < 0.45f)
                {
                    float newBaseX = allPieces[i].GetComponent<PuzzlePiece>().baseX;
                    float newBaseY = allPieces[i].GetComponent<PuzzlePiece>().baseY;
                    allPieces[i].GetComponent<PuzzlePiece>().baseX = baseX;
                    allPieces[i].GetComponent<PuzzlePiece>().baseY = baseY;
                    baseX = newBaseX;
                    baseY = newBaseY;
                    allPieces[i].GetComponent<PuzzlePiece>().SnapToBase();

                    timeDragging += Time.deltaTime * 1000;

                    /*if(timeDragging > 200f)
                    {
                        //print("dragging: " + timeDragging);
                        boardScript.dragPenalty += .02f;

                        boardScript.warningText.color = Color.red;
                        boardScript.warningText.text = "Warning: dragging for too long will incur a score penalty!";
                    }*/
                }
            }
        }
    }

    void OnMouseUp()
    {
        boardScript.dragging = false;
        boardScript.warningText.text = "";
        SnapToBase();
        boardScript.PopMatches();
    }

    public void SnapToBase()
    {
        if (!falling)
        {
            transform.position = new Vector3(baseX, baseY, 0);
        }
    }

    public void CallDestruction()
    {
        //StartCoroutine(DestroySelf());
        DestroyGameObject();
    }

    /*IEnumerator DestroySelf()
    {
        //animation.Play("PieceDestruction");
        /*do
        {
            yield return null;
        } while (animation.isPlaying);
        DestroyGameObject();
    }*/

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    public void FallDown()
    {
        if (boardScript == null)
        {
            return;
        }
        if (boardScript.dragging)
        {
            return;
        }
        if (boardScript.spawning)
        {
            return;
        }
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 0.87f, Vector2.down);
        if (hit.collider == null)
        {
            baseY = -4.5f;
            if (Mathf.Abs(baseY - transform.position.y) > 0.1f)
            {
                falling = true;
            }
        }
        else
        {
            baseY = hit.transform.position.y + 0.87f;
            if (Mathf.Abs(baseY - transform.position.y) > 0.1f)
            {
                falling = true;
            }
        }
    }
}
