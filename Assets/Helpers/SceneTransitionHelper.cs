using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneTransitionHelper")]
public class SceneTransitionHelper : ScriptableObject {

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel() {

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
