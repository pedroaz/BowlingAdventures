using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static Level selectedLevel;
    public SceneTransitionHelper sceneTransitionHelper;
    public Level defaultLevel;
    public static bool playerIsAlive;

    public static int currentPoints;

    private void Awake() {
        
        if(selectedLevel == null) {
            selectedLevel = defaultLevel;
        }

    }

    // Use this for initialization
    void Start () {

        currentPoints = 0;
        playerIsAlive = true;
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


    bool HasWon() {

        return currentPoints == selectedLevel.maxPoints;
    }

    public static void AddPoints(int x) {

        currentPoints += x;
    }

    public static void KillPlayer() {

        playerIsAlive = false;
        UIManager.ShowDeathMenu(true);
    }

    

}
