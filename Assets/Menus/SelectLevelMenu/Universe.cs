using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Universe")]
public class Universe : ScriptableObject {

    public List<Level> listOfPlanets;
    LevelManager levelManager;

    public bool[] planetsPermission;

    public void SelectWorld(int i) {

        if (planetsPermission[i]) {

            levelManager.selectedLevel = listOfPlanets[i];
        }
    }
}
