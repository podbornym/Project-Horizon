using UnityEngine;
using System.Collections;

public class PersistVars : MonoBehaviour {
    //this script is attached to the UI so
    //all variables stored in here will persist
    //across scene changes

    public static string ggScrub = "This will be the best art theft game ever made.  No doubt about it!";
    public static GameObject[] landingPairs;
    //Locations
    public static bool Ukiyo = false;
    public static bool Surreal = false;
    public static bool Baroque = false;
    //Paintings
    public static bool[] painting = { false, false, false, false, false, false };
    //If a painting is true, use the location + the painting number. EX: If Ukiyo = true and using painting[2], location = "Ukiyo", clue set = location + "Three"
    //Ukiyo-e Clues
    public static bool[] UkiyoOne = { false, false, false, false, false, false };
    public static bool[] UkiyoTwo = { false, false, false, false, false, false };
    public static bool[] UkiyoThree = { false, false, false, false, false, false };
    public static bool[] UkiyoFour = { false, false, false, false, false, false };
    public static bool[] UkiyoFive = { false, false, false, false, false, false };
    public static bool[] UkiyoSix = { false, false, false, false, false, false };
    //Surreal Clues
    public static bool[] SurrealOne = { false, false, false, false, false, false };
    public static bool[] SurrealTwo = { false, false, false, false, false, false };
    public static bool[] SurrealThree = { false, false, false, false, false, false };
    public static bool[] SurrealFour = { false, false, false, false, false, false };
    public static bool[] SurrealFive = { false, false, false, false, false, false };
    public static bool[] SurrealSix = { false, false, false, false, false, false };
    //Baroque Clues
    public static bool[] BaroqueOne = { false, false, false, false, false, false };
    public static bool[] BaroqueTwo = { false, false, false, false, false, false };
    public static bool[] BaroqueThree = { false, false, false, false, false, false };
    public static bool[] BaroqeuFour = { false, false, false, false, false, false };
    public static bool[] BaroqueFive = { false, false, false, false, false, false };
    public static bool[] BaroqueSix = { false, false, false, false, false, false };
}
