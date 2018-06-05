using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameManager : MonoBehaviour {

    public static bool won;

    public LevelManager levelManager;


    [SerializeField]
    private Image loser;

    [SerializeField]
    private Image winner;

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

        loser.gameObject.SetActive(false);
        winner.gameObject.SetActive(true);

        if (levelManager.selectedLevel.levelIndex != 9) {

            SaveLoadHelper.currentGameData.planetsPermission[levelManager.selectedLevel.levelIndex + 1] = true;
        }
    }

    void Lose() {


        loser.gameObject.SetActive(true);
        winner.gameObject.SetActive(false);

        retryButton.SetActive(true);
    }

}
