using UnityEngine;
using System.Collections;

public class SpotTheDiff : MonoBehaviour
{
    public SpotTheDiffManager manager;
    //public static int diffID;
    private float timeLeft;

    void Awake()
    {
        SpotTheDiffManager.foundDiff = 0;
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = SpotTheDiffManager.seconds;
    }

    /*void SelectDiff()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), Vector2.zero, 0f);
        

        if (hit)
        {
            difference = hit.collider.gameObject;
            difference.gameObject.GetComponent<BoxCollider2D>();
            print("hit");
            Destroy(difference);
            FoundDiff++;
        }

        //difference.gameObject.GetComponent<BoxCollider2D>();
    }*/

    void OnMouseDown()
    {
        if (timeLeft > 0)
        {
            SpotTheDiffManager.foundDiff += 1;
            Destroy(gameObject);
        }

    }

    /*    public static void NotPicked(int[] diffArray)
        {
            bool picked = false;
            // Go through the array and check to see
            // if the diff's number is in the array
            for (int i = 0; i < diffArray.Length; i++)
            {
                if (diffArray[i] == diffID)
                {
                    picked = true;
                }
            }

            // If the diff's number isn't found, remove the diff
            for (int i = 0; i < diffArray.Length; i++)
            {
                if (!picked)
                {
                    Destroy(diffArray[i]);
                }
            }
        }*/
}