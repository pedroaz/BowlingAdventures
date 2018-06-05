using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour {

    public GameObject optionsMenu;
    public GameObject optionsButton;
    public GameObject tutorial;

    public PlanetsShaders planetsShaders;

    public void ShowTutorial() {

        optionsMenu.SetActive(true);
        tutorial.SetActive(true);
    }

    public void ShowGear() {

        optionsMenu.SetActive(true);
        optionsButton.SetActive(true);
    }

    public void CloseOptions() {

        optionsMenu.SetActive(false);
        tutorial.SetActive(false);
        optionsButton.SetActive(false);
    }

	public void ResetGameData() {

        SaveLoadHelper.NewGame();
        planetsShaders.UpdateShaders();
    }
}
