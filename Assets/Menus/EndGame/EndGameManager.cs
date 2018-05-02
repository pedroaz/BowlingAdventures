using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {

    public Text resultText;
    public static bool won;

	// Use this for initialization
	void Start () {

        if (won) {
            resultText.text = "Congratulations!";
        }
        else {
            resultText.text = "Try Again";
        }
	}
	
}
