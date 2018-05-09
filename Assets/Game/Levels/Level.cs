using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject {

    // Needs to be public
    public GameObject levelPrefab;

    [SerializeField] LevelManager levelManager;

    public void SelectThisLevel() {

        levelManager.SelectLevel(this);
    }
}
