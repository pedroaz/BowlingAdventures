﻿using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneTransitionHelper")]
public class SceneTransitionHelper : ScriptableObject {

    public void LoadMainMenu() {

        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameLevel() {

        SceneManager.LoadScene("Game");
    }

    public void LoadSelectLevelMenu() {

        SceneManager.LoadScene("SelectLevelMenu");
    }

    public void LoadEndGame() {

        SceneManager.LoadScene("EndGame");
    }

    public void ReloadScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
