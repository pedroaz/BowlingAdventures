using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static Level selectedLevel;
    public SceneTransitionHelper sceneTransitionHelper;
    public Level defaultLevel;


    public static int currentPoints;
    public static int currentRound;
    public static int pointsRequired;
    public static int maxRounds;

    private void Awake() {
        
        if(selectedLevel == null) {
            selectedLevel = defaultLevel;
        }

    }

    // Use this for initialization
    void Start () {

    }
	

    public static void StartLevel() {

        currentPoints = 0;
        currentRound = 1;
        pointsRequired = selectedLevel.pointsRequired;
        maxRounds = selectedLevel.maxRounds;
    }

    public void EndLevel() {

        if(HasWon()) {
            EndGameManager.won = true;
        }
        else {
            EndGameManager.won = false;
        }

        sceneTransitionHelper.LoadEndGame();
    }

    public static bool HasWon() {

        return currentPoints > pointsRequired;
    }
}
