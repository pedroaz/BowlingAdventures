using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndGameManager : MonoBehaviour {

    public static bool won;

    public LevelManager levelManager;

    [SerializeField]
    TextMeshProUGUI textMeshPro;

    public GameObject retryButton;

	// Use this for initialization
	void Start () {

        SaveLoadHelper.SaveGame();

        if (won) {

            Won();
        } else {

            Lose();
        }
    }

    void Won() {

        textMeshPro.text = "Congratulations, you have collected all the pins!";

        if(levelManager.selectedLevel.levelIndex != 9) {

            SaveLoadHelper.currentGameData.planetsPermission[levelManager.selectedLevel.levelIndex + 1] = true;
        }
    }

    void Lose() {

        textMeshPro.text = "I am sorry, but you need to colled all the pins.";
        retryButton.SetActive(true);
    }

}
