using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject {

    public int pointsRequired;
    public int maxRounds;

    public void SelectThisLevel() {

        LevelManager.selectedLevel = this;
    }
}
