using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour {


    public LevelManager levelManager;
    public delegate void NextRoundDelegate();
    public static event NextRoundDelegate NextRoundEvent;


    // Use this for initialization
    void Start () {
        
        Pin.PinFellEvent += AddPoint;
        BallThrowMovement.ThrowEvent += StartRoundTimer;
    }

    private void OnDestroy() {

        Pin.PinFellEvent -= AddPoint;
        BallThrowMovement.ThrowEvent -= StartRoundTimer;
    }

    

    public static void AddPoint() {

        LevelManager.currentPoints++;
    }

    void StartRoundTimer() {

        StartCoroutine(Wait(5));
        
    }

    IEnumerator Wait(float x) {

        yield return new WaitForSeconds(x);
        NextRound();
    }


    void NextRound() {

        if (LevelManager.HasWon()) {
            levelManager.EndLevel();
        }

        if(LevelManager.currentRound < LevelManager.maxRounds) {
            GoToNextRound();
        }
        else {
            levelManager.EndLevel();
        }
    }

    void GoToNextRound() {

        LevelManager.currentRound++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        NextRoundEvent();
    }
}
