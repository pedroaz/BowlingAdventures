using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameManager : MonoBehaviour {

    public static bool won;

    [SerializeField]
    TextMeshProUGUI textMeshPro;

    public GameObject retryButton;

	// Use this for initialization
	void Start () {


        if (won) {

            Won();
        } else {

            Lose();
        }
    }

    void Won() {

        textMeshPro.text = "Congratulations, you have collected all the pins!";
    }

    void Lose() {

        textMeshPro.text = "I am sorry, but you need to colled all the pins.";
        retryButton.SetActive(true);
    }

}
