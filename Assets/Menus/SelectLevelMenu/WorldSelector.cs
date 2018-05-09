using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelector : MonoBehaviour {

    [SerializeField] private Universe universe;
    [SerializeField] private Text worldText;
    [SerializeField] private World selectedWorld;

    private int worldIndex;

	// Use this for initialization
	void Start () {

        worldIndex = 0;
        SelectWorld(worldIndex);
    }
	
	void SelectWorld(int i) {

        worldText.text = universe.listOfWorlds[i].worldName;
        selectedWorld = universe.listOfWorlds[i];
        universe.selectedWorld = selectedWorld;
    }

    public void NextWorld() {

        if(worldIndex < universe.listOfWorlds.Count) {
            worldIndex++;
            SelectWorld(worldIndex);
        }
    }

    public void PrevWorld() {

        if (worldIndex > 0) {
            worldIndex--;
            SelectWorld(worldIndex);
        }
    }
}
