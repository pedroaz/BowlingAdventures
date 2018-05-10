using UnityEngine;

[CreateAssetMenu(fileName ="LevelManager")]
public class LevelManager : ScriptableObject {

    [SerializeField] private SceneTransitionHelper sceneTransitionHelper;
    [SerializeField] private Universe universe;
    [SerializeField] private Level selectedLevel;
    [SerializeField] private Level defaultLevel;
    [SerializeField] private bool playerIsAlive;

    public int currentPoints;
    public int maxPoints;

    public Level SelectedLevel{
        get { return selectedLevel; }
        set { selectedLevel = value; }
    }

    /// <summary>
    /// This event is called when the points are changed
    /// </summary>
    public static event PointsChanged PointsChangedEvent;
    public delegate void PointsChanged();

    

    /// <summary>
    /// Init the level manager variables from the Level object and instantiate
    /// </summary>
    public void InitLevel() {

        if (selectedLevel == null) {
            selectedLevel = defaultLevel;
        }

        currentPoints = 0;
        PointsChangedEvent();
        playerIsAlive = true;
        maxPoints = selectedLevel.amountOfPinsInLevel;
        Instantiate(selectedLevel.levelPrefab);
    }


    /// <summary>
    /// End the level by sending to the other scene
    /// </summary>
    public void EndLevel() {

        HasWonLevel();
        sceneTransitionHelper.LoadEndGame();
    }

    public bool HasWonLevel() {

        if (currentPoints == maxPoints) {
            EndGameManager.won = true;
            return true;
        }
        else {
            EndGameManager.won = false;
            return false;
        }
    }

    
    public void AddPoints(int x) {

        currentPoints += x;
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
    }

}
