using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NotADiff : MonoBehaviour
{

    public static float penaltyTime = -1;
    bool foundAll = SpotTheDiffManager.foundAll;

	AudioSource source1;

	public string sceneName;

    // Use this for initialization
    void Start()
    {
		sceneName = SceneManager.GetActiveScene ().name;
		source1 = gameObject.AddComponent<AudioSource>();
		if(sceneName=="Z1-SD1" || sceneName=="Z1-SD2" || sceneName=="Z1-SD3" || sceneName=="Z1-SD4" || sceneName=="Z1-SD5" || sceneName=="Z1-SD6")
		{
			source1.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Ukiyo-E Wrong") as AudioClip;
		}
		else if(sceneName=="Z2-SD1" || sceneName=="Z2-SD2" || sceneName=="Z2-SD3" || sceneName=="Z2-SD4" || sceneName=="Z2-SD5" || sceneName=="Z2-SD6")
		{
			source1.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Surreal Wrong") as AudioClip;
		}
		else if(sceneName=="Z3-SD1" || sceneName=="Z3-SD2" || sceneName=="Z3-SD3" || sceneName=="Z3-SD4" || sceneName=="Z3-SD5" || sceneName=="Z3-SD6")
		{
			source1.clip = Resources.Load ("Sound/Mini-Game SFX/Spot the Difference/Baroque Wrong") as AudioClip;
		}

    }

    // Update is called once per frame
    void Update()
    {
        // After a penalty, wait half a second before changing the timer's color back to white
        if (penaltyTime != -1 && penaltyTime - SpotTheDiffManager.seconds >= 0.5)
        {
            SpotTheDiffManager.timeCounter.color = Color.white;
        }
    }

    public void OnMouseDown()
    {
        if (SpotTheDiffManager.seconds > 0 && !foundAll)
        {
            SpotTheDiffManager.seconds--;

            // Change the timer's color to red upon getting a penalty
            SpotTheDiffManager.timeCounter.color = Color.red;
            penaltyTime = SpotTheDiffManager.seconds;

			if(sceneName=="Z1-SD1" || sceneName=="Z1-SD2" || sceneName=="Z1-SD3" || sceneName=="Z1-SD4" || sceneName=="Z1-SD5" || sceneName=="Z1-SD6")
			{
				source1.Play();
			}
			else if(sceneName=="Z2-SD1" || sceneName=="Z2-SD2" || sceneName=="Z2-SD3" || sceneName=="Z2-SD4" || sceneName=="Z2-SD5" || sceneName=="Z2-SD6")
			{
				source1.Play();
			}
			else if(sceneName=="Z3-SD1" || sceneName=="Z3-SD2" || sceneName=="Z3-SD3" || sceneName=="Z3-SD4" || sceneName=="Z3-SD5" || sceneName=="Z3-SD6")
			{
				source1.Play();
			}
        }


    }
}
