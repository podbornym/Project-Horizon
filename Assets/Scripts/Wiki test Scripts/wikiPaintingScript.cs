using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wikiPaintingScript : MonoBehaviour {

    public string painting;
    public Text TextField;
    public GameObject TextObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IAmClickedUkiyo()
    {
        if(painting == "uk1")
        {
            TextField.text = "Ukiyo-e painting one:\n";
            if (PersistVars.UkiyoOne[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk1[0];
            if (PersistVars.UkiyoOne[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk1[1];
            if (PersistVars.UkiyoOne[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk1[2];
            if (PersistVars.UkiyoOne[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk1[3];
            if (PersistVars.UkiyoOne[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk1[4];
            if (PersistVars.UkiyoOne[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk1[5];
        }
        if (painting == "uk2")
        {
            TextField.text = "Ukiyo-e painting two:\n";
            if (PersistVars.UkiyoTwo[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk2[0];
            if (PersistVars.UkiyoTwo[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk2[1];
            if (PersistVars.UkiyoTwo[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk2[2];
            if (PersistVars.UkiyoTwo[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk2[3];
            if (PersistVars.UkiyoTwo[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk2[4];
            if (PersistVars.UkiyoTwo[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk2[5];
        }
        if (painting == "uk3")
        {
            TextField.text = "Ukiyo-e painting three:\n";
            if (PersistVars.UkiyoThree[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk3[0];
            if (PersistVars.UkiyoThree[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk3[1];
            if (PersistVars.UkiyoThree[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk3[2];
            if (PersistVars.UkiyoThree[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk3[3];
            if (PersistVars.UkiyoThree[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk3[4];
            if (PersistVars.UkiyoThree[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk3[5];
        }

        if (painting == "uk4")
        {
            TextField.text = "Ukiyo-e painting four:\n";
            if (PersistVars.UkiyoFour[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk4[0];
            if (PersistVars.UkiyoFour[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk4[1];
            if (PersistVars.UkiyoFour[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk4[2];
            if (PersistVars.UkiyoFour[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk4[3];
            if (PersistVars.UkiyoFour[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk4[4];
            if (PersistVars.UkiyoFour[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk4[5];
        }
        if (painting == "uk5")
        {
            TextField.text = "Ukiyo-e painting five:\n";
            if (PersistVars.UkiyoFive[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk5[0];
            if (PersistVars.UkiyoFive[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk5[1];
            if (PersistVars.UkiyoFive[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk5[2];
            if (PersistVars.UkiyoFive[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk5[3];
            if (PersistVars.UkiyoFive[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk5[4];
            if (PersistVars.UkiyoFive[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk5[5];
        }
        if (painting == "uk6")
        {
            TextField.text = "Ukiyo-e painting six:\n";
            if (PersistVars.UkiyoSix[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk6[0];
            if (PersistVars.UkiyoSix[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk6[1];
            if (PersistVars.UkiyoSix[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk6[2];
            if (PersistVars.UkiyoSix[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk6[3];
            if (PersistVars.UkiyoSix[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk6[4];
            if (PersistVars.UkiyoSix[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().uk6[5];
        }

    }

    public void IAmClickedSurreal()
    {
        if (painting == "su1")
        {
            TextField.text = "Surrealism painting one:\n";
            if (PersistVars.SurrealOne[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su1[0];
            if (PersistVars.SurrealOne[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su1[1];
            if (PersistVars.SurrealOne[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su1[2];
            if (PersistVars.SurrealOne[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su1[3];
            if (PersistVars.SurrealOne[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su1[4];
            if (PersistVars.SurrealOne[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su1[5];
        }
        if (painting == "su2")
        {
            TextField.text = "Surrealism painting two:\n";
            if (PersistVars.SurrealTwo[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su2[0];
            if (PersistVars.SurrealTwo[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su2[1];
            if (PersistVars.SurrealTwo[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su2[2];
            if (PersistVars.SurrealTwo[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su2[3];
            if (PersistVars.SurrealTwo[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su2[4];
            if (PersistVars.SurrealTwo[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su2[5];
        }
        if (painting == "su3")
        {
            TextField.text = "Surrealism painting three:\n";
            if (PersistVars.SurrealThree[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su3[0];
            if (PersistVars.SurrealThree[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su3[1];
            if (PersistVars.SurrealThree[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su3[2];
            if (PersistVars.SurrealThree[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su3[3];
            if (PersistVars.SurrealThree[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su3[4];
            if (PersistVars.SurrealThree[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su3[5];
        }

        if (painting == "su4")
        {
            TextField.text = "Surrealism painting four:\n";
            if (PersistVars.SurrealFour[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su4[0];
            if (PersistVars.SurrealFour[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su4[1];
            if (PersistVars.SurrealFour[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su4[2];
            if (PersistVars.SurrealFour[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su4[3];
            if (PersistVars.SurrealFour[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su4[4];
            if (PersistVars.SurrealFour[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su4[5];
        }
        if (painting == "su5")
        {
            TextField.text = "Surrealism painting five:\n";
            if (PersistVars.SurrealFive[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su5[0];
            if (PersistVars.SurrealFive[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su5[1];
            if (PersistVars.SurrealFive[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su5[2];
            if (PersistVars.SurrealFive[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su5[3];
            if (PersistVars.SurrealFive[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su5[4];
            if (PersistVars.SurrealFive[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su5[5];
        }
        if (painting == "su6")
        {
            TextField.text = "Surrealism painting six:\n";
            if (PersistVars.SurrealSix[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su6[0];
            if (PersistVars.SurrealSix[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su6[1];
            if (PersistVars.SurrealSix[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su6[2];
            if (PersistVars.SurrealSix[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su6[3];
            if (PersistVars.SurrealSix[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su6[4];
            if (PersistVars.SurrealSix[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().su6[5];
        }

    }

    public void IAmClickedBaroque()
    {
        if (painting == "ba1")
        {
            TextField.text = "Baroque painting one:\n";
            if (PersistVars.BaroqueOne[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba1[0];
            if (PersistVars.BaroqueOne[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba1[1];
            if (PersistVars.BaroqueOne[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba1[2];
            if (PersistVars.BaroqueOne[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba1[3];
            if (PersistVars.BaroqueOne[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba1[4];
            if (PersistVars.BaroqueOne[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba1[5];
        }
        if (painting == "ba2")
        {
            TextField.text = "Baroque painting two:\n";
            if (PersistVars.BaroqueTwo[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba2[0];
            if (PersistVars.BaroqueTwo[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba2[1];
            if (PersistVars.BaroqueTwo[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba2[2];
            if (PersistVars.BaroqueTwo[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba2[3];
            if (PersistVars.BaroqueTwo[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba2[4];
            if (PersistVars.BaroqueTwo[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba2[5];
        }
        if (painting == "ba3")
        {
            TextField.text = "Baroque painting three:\n";
            if (PersistVars.BaroqueThree[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba3[0];
            if (PersistVars.BaroqueThree[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba3[1];
            if (PersistVars.BaroqueThree[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba3[2];
            if (PersistVars.BaroqueThree[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba3[3];
            if (PersistVars.BaroqueThree[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba3[4];
            if (PersistVars.BaroqueThree[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba3[5];
        }

        if (painting == "ba4")
        {
            TextField.text = "Baroque painting four:\n";
            if (PersistVars.BaroqueFour[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba4[0];
            if (PersistVars.BaroqueFour[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba4[1];
            if (PersistVars.BaroqueFour[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba4[2];
            if (PersistVars.BaroqueFour[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba4[3];
            if (PersistVars.BaroqueFour[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba4[4];
            if (PersistVars.BaroqueFour[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba4[5];
        }
        if (painting == "ba5")
        {
            TextField.text = "Baroque painting five:\n";
            if (PersistVars.BaroqueFive[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba5[0];
            if (PersistVars.BaroqueFive[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba5[1];
            if (PersistVars.BaroqueFive[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba5[2];
            if (PersistVars.BaroqueFive[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba5[3];
            if (PersistVars.BaroqueFive[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba5[4];
            if (PersistVars.BaroqueFive[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba5[5];
        }
        if (painting == "ba6")
        {
            TextField.text = "Baroque painting six:\n";
            if (PersistVars.BaroqueSix[0] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba6[0];
            if (PersistVars.BaroqueSix[1] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba6[1];
            if (PersistVars.BaroqueSix[2] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba6[2];
            if (PersistVars.BaroqueSix[3] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba6[3];
            if (PersistVars.BaroqueSix[4] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba6[4];
            if (PersistVars.BaroqueSix[5] == true)
                TextField.text += TextObject.GetComponent<wikiDataScript>().ba6[5];
        }

    }
}
