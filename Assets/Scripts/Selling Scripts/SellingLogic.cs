/*
 * This is the intenal logic that will dictate if a buyer accepts a forgery and how much with pay for it.
 */
using UnityEngine;
using System.Collections;

public class SellingLogic : MonoBehaviour {
	
	// Calculates average of all 6 minigame grades
	// Returns average as float
	float Avg (float m1, float m2, float m3, float m4, float m5, float m6) {
		float average = (m1+m2+m3+m4+m5+m6)/6;
		return average;
	}

	/* Determines if player 
	 * Returns true if player passes error check
	 * Returns false if player does not pass
	 */
	bool ErrorCheck (string buyer, float avg) {
		// High level buyer
		if (buyer=="high") {
			if (avg >= .9) {
				return true;
			} 
			else {
				return false;
			}
		}
		// Medium level buyer
		else if (buyer == "med") {
			if (avg >= .8) {
				return true;
			} else {
				return false;
			}
		}
		// Low level buyer
		else if (buyer == "low") {
			if (avg >= .75) {
				return true;
			} else {
				return false;
			}
		}
		// Black market buyer
		else {
			if (avg >= .7) {
				return true;
			} else {
				return false;
			}
		}
	}

	// Determines payout for High, Medium, and Low buyers
	// Returns payout as int
	int Payout (string buyer, float avg, int maxValue) {
		// High level buyer
		if (buyer=="high") {
			return (int)(avg * maxValue);
		}
		// Medium level buyer
		else if (buyer == "med") {
			if (avg >.89) {
				return (int)(.89 * maxValue);
			} else {
				return (int)(avg * maxValue);
			}
		}
		// Low level buyer
		else {
			if (avg > .79) {
				return (int)(.79 * maxValue);
			} else {
				return (int)(avg * maxValue);
			}
		}
	}
}
