using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpotTheDiff : MonoBehaviour
{
    public SpotTheDiffManager manager;
    //public static int diffID;
    private float timeLeft;

	AudioSource source;

	public string sceneName;

    void Awake()
    {
        SpotTheDiffManager.foundDiff = 0;

    }
    // Use this for initialization
    void Start()
	{
		sceneName = SceneManager.GetActiveScene ().name;
		source = gameObject.AddComponent<AudioSource>();
		if(sceneName=="Z1-SD1" || sceneName=="Z1-SD2" || sceneName=="Z1-SD3" || sceneName=="Z1-SD4" || sceneName=="Z1-SD5" || sceneName=="Z1-SD6")
		{
			source.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Ukiyo-E Point") as AudioClip;
		}
		else if(sceneName=="Z2-SD1" || sceneName=="Z2-SD2" || sceneName=="Z2-SD3" || sceneName=="Z2-SD4" || sceneName=="Z2-SD5" || sceneName=="Z2-SD6")
		{
			source.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Surreal Point") as AudioClip;
		}
		else if(sceneName=="Z3-SD1" || sceneName=="Z3-SD2" || sceneName=="Z3-SD3" || sceneName=="Z3-SD4" || sceneName=="Z3-SD5" || sceneName=="Z3-SD6")
		{
			source.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Baroque Point") as AudioClip;
		}
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
			if(sceneName=="Z1-SD1" || sceneName=="Z1-SD2" || sceneName=="Z1-SD3" || sceneName=="Z1-SD4" || sceneName=="Z1-SD5" || sceneName=="Z1-SD6")
			{
				source.Play();
			}
			else if(sceneName=="Z2-SD1" || sceneName=="Z2-SD2" || sceneName=="Z2-SD3" || sceneName=="Z2-SD4" || sceneName=="Z2-SD5" || sceneName=="Z2-SD6")
			{
				source.Play();
			}
			else if(sceneName=="Z3-SD1" || sceneName=="Z3-SD2" || sceneName=="Z3-SD3" || sceneName=="Z3-SD4" || sceneName=="Z3-SD5" || sceneName=="Z3-SD6")
			{
				source.Play();
			}
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