using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBox : MonoBehaviour {

    public GameObject buttonPrefab;
    public Universe universe;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < universe.selectedWorld.listOfLevels.Count; i++) {

            GameObject btn = Instantiate(buttonPrefab);
            btn.transform.parent = transform;
            btn.GetComponent<Button>().onClick.AddListener(universe.selectedWorld.listOfLevels[i].SelectThisLevel);
        }

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
}
