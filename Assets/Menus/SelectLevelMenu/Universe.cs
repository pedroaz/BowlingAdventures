using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Universe")]
public class Universe : ScriptableObject {

    public LevelManager levelManager;

    public List<Level> listOfPlanets;

    

    public void SelectWorld(int i) {

        //if (SaveLoadHelper.currentGameData.planetsPermission[i]) {

        levelManager.selectedLevel = listOfPlanets[i];
        //}
    }
}
