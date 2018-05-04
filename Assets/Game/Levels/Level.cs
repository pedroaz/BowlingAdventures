using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject {

    public int maxPoints;
    public GameObject levelPrefab;

    public void SelectThisLevel() {

        LevelManager.selectedLevel = this;
    }
}
