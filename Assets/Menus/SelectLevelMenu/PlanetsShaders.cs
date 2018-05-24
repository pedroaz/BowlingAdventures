using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetsShaders : MonoBehaviour {

    [SerializeField] private Button[] planetsButtons;
    [SerializeField] private Image[] planetsImages;

    [SerializeField] private Color white;
    [SerializeField] private Color black;

    public bool[] defaultPermissions;

    // Use this for initialization
    void Start () {

        UpdateShaders();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateShaders() {

        bool[] permissions;

        if(SaveLoadHelper.currentGameData == null) {

            permissions = defaultPermissions;
        } else {

            permissions = SaveLoadHelper.currentGameData.planetsPermission;
        }
         

        for (int i = 0; i < 10; i++) {

            
            if (permissions[i]) {

                planetsImages[i].color = white;
                planetsButtons[i].interactable = true;
            } else {

                planetsImages[i].color = black;
                planetsButtons[i].interactable = false;
            }

        }
    }
}
