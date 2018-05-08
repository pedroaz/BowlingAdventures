using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level")]
public class Level : ScriptableObject {

    public GameObject LevelPrefab{ get; set; }
    [SerializeField] private GameObject levelPrefab;

    public void SelectThisLevel() {

        LevelManager.selectedLevel = this;
    }
}
