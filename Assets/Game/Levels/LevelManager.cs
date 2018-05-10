using UnityEngine;

[CreateAssetMenu(fileName ="LevelManager")]
public class LevelManager : ScriptableObject {

    [SerializeField] private SceneTransitionHelper sceneTransitionHelper;
    [SerializeField] private Universe universe;
    [SerializeField] private Level selectedLevel;
    [SerializeField] private Level defaultLevel;
    [SerializeField] private bool playerIsAlive;
    //[SerializeField] private int currentPoints;
    //[SerializeField] private int maxPoints;

    /// <summary>
    /// This event is called when the points are changed
    /// </summary>
    public static event PointsChanged PointsChangedEvent;
    public delegate void PointsChanged();

    public int CurrentPoints{ get; set; }
    public int MaxPoints{ get; set; }

    /// <summary>
    /// Init the level manager variables from the Level object and instantiate
    /// </summary>
    public void InitLevel() {

        if (selectedLevel == null) {
            selectedLevel = defaultLevel;
        }

        CurrentPoints = 0;
        PointsChangedEvent();
        playerIsAlive = true;
        MaxPoints = selectedLevel.amountOfPinsInLevel;
        Instantiate(selectedLevel.levelPrefab);
    }


    /// <summary>
    /// End the level by sending to the other scene
    /// </summary>
    public void EndLevel() {

        HasWonLevel();
        sceneTransitionHelper.LoadEndGame();
    }

    void HasWonLevel() {

        if (true) {
            EndGameManager.won = true;
        }
        else {
            EndGameManager.won = false;
        }
    }

    
    public void AddPoints(int x) {

        CurrentPoints += x;
        PointsChangedEvent();
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

    public void SelectLevel(int index) {

        selectedLevel = universe.selectedWorld.listOfLevels[index];
        Debug.Log(selectedLevel);
    }

}
