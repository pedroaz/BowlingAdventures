using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneTransitionHelper")]
public class SceneTransitionHelper : ScriptableObject {

    public void LoadMainMenu() {

        SceneManager.LoadScene("MainMenuScene");
    }

    public void LoadGameLevel() {

        SceneManager.LoadScene("GameScene");
    }

    public void LevelSelectMenu() {

        SceneManager.LoadScene("SelectLevelMenuScene");
    }

    public void LoadEndGame() {

        SceneManager.LoadScene("EndGameS");
    }

    public void ReloadScene() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
