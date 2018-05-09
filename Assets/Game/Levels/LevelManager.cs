using UnityEngine;

[CreateAssetMenu(fileName ="LevelManager")]
public class LevelManager : ScriptableObject {

    [SerializeField] private SceneTransitionHelper sceneTransitionHelper;

    [SerializeField] private Level selectedLevel;
    [SerializeField] private Level defaultLevel;
    [SerializeField] private bool playerIsAlive;
    [SerializeField] private int currentPoints;
    [SerializeField] private int maxPoints;


    public int CurrentPoints{ get; set; }
    public int MaxPoints{ get; set; }

    /// <summary>
    /// Init the level manager variables from the Level object and instantiate
    /// </summary>
    public void InitLevel() {

        if (selectedLevel == null) {
            selectedLevel = defaultLevel;
        }

        currentPoints = 0;
        playerIsAlive = true;
        //maxPoints = selectedLevel.Maxpoints;
        Instantiate(selectedLevel.levelPrefab);
    }


    /// <summary>
    /// End the level by sending to the other scene
    /// </summary>
    public void EndLevel() {

        HasWonLevel();
        sceneTransitionHelper.LoadEndGame();
    }

    /// <summary>
    /// Decide if the player has won the level
    /// </summary>
    void HasWonLevel() {

        if (true) {
            EndGameManager.won = true;
        }
        else {
            EndGameManager.won = false;
        }
    }

    /// <summary>
    /// Add points to the level current points
    /// </summary>
    /// <param name="x">Amount</param>
    public void AddPoints(int x) {

        currentPoints += x;
    }

    /// <summary>
    /// Kill the player and show the death menu
    /// </summary>
    public void KillPlayer(bool showMenu) {

        playerIsAlive = false;
        UIManager.ShowDeathMenu(showMenu);
    }

    public void RevivePlayer() {

        playerIsAlive = true;
        UIManager.ShowDeathMenu(false);
    }

    public bool PlayerIsAlive() {

        return playerIsAlive;
    }

    public void SelectLevel(Level level) {

        selectedLevel = level;
    }

}
