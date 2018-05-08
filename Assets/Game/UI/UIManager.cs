using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text pointsText;
    public Text redCrystalText;
    public Slider redSlider;
    public Slider purpleSlider;

    public GameObject purpleGameObject;
    public GameObject redGameObject;
    public GameObject powersGameObject;


    // Use this for initialization
    void Start () {


        //BallThrowMovement.ThrowEvent += ShowPowers;
        ExtraPin.ExtraPinEvent += UpdatePointsText;
        //RedCrystal.RedCrystalEvent += UpdateRedText;
        //PurpleCrystal.PurpleCrystalEvent += UpdatePurpleSlider;
        SlowTime.SlowEvent += UpdateRedSlider;
        Ghost.GhostEvent += UpdateRedSlider;
        //PowersManager.PowerEvent += UpdateAll;

        UpdateAll();
    }

    private void OnDestroy() {

        ExtraPin.ExtraPinEvent -= UpdatePointsText;
        //RedCrystal.RedCrystalEvent -= UpdateRedText;
        //PurpleCrystal.PurpleCrystalEvent += UpdatePurpleSlider;
        //BallThrowMovement.ThrowEvent -= ShowPowers;
        SlowTime.SlowEvent -= UpdateRedSlider;
        Ghost.GhostEvent -= UpdateRedSlider;
        //PowersManager.PowerEvent -= UpdateAll;
    }


    void ShowPowers() {

        purpleGameObject.SetActive(true);
        powersGameObject.SetActive(true);
        redGameObject.SetActive(true);
    }

    void HidePowers() {

        purpleGameObject.SetActive(false);
        powersGameObject.SetActive(false);
        redGameObject.SetActive(false);
    }

    void UpdateAll() {

        UpdatePointsText();
        UpdateRedText();
        UpdatePurpleSlider();
        UpdateRedSlider();
    }

    void UpdatePointsText() {

        //pointsText.text = "Points: " + LevelManager.currentPoints + " / " + LevelManager.selectedLevel.MaxPoints;
        pointsText.text = "Points: " + LevelManager.currentPoints + " / " + 10;
    }

    void UpdateRedText() {

        //redCrystalText.text = PowersManager.redPower + "x";
    }

    void UpdatePurpleSlider() {

        //purpleSlider.value = PowersManager.purplePower;
    }

    void UpdateRedSlider() {

        //redSlider.value = PowersManager.redDuration;

        //if(PowersManager.redDuration == 0) {
        //    redGameObject.SetActive(false);
        //}
        //else {
        //    redGameObject.SetActive(true);
        //}

    }

    static public void ShowDeathMenu(bool value) {

        GameObject menu = GameObject.FindGameObjectWithTag("DeathMenu");

        for (int i = 0; i < menu.transform.childCount; i++) {

            menu.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
