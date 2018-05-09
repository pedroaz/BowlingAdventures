using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour {

    [SerializeField] private int startingRedPower;

    [SerializeField] private LevelManager levelManager;

	// Use this for initialization
	void Start () {

        levelManager.InitLevel();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
