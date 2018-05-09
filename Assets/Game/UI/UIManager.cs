using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] private PowersStats powersStats;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private Text pointsText;
    [SerializeField] private Text redCrystalText;
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider purpleSlider;

    [SerializeField] private GameObject purpleGameObject;
    [SerializeField] private GameObject redGameObject;
    [SerializeField] private GameObject powersGameObject;

    // Use this for initialization
    void Start () {


        BallFowardMovement.ThrowEvent += ShowPowersUI;
        ExtraPin.PickUpExtraPinEvent += UpdatePointsText;
        RedCrystal.PickUpRedCrystalEvent += UpdateRedText;
        PurpleCrystal.PickUpPurpleCrystalEvent += UpdatePurpleSlider;
        SlowTime.SlowEvent += UpdateRedSlider;
        Ghost.GhostEvent += UpdateRedSlider;
        PowersStats.PowerAmountChangedEvent += UpdateAllUI;

        UpdateAllUI();
    }

    private void OnDestroy() {

        ExtraPin.PickUpExtraPinEvent -= UpdatePointsText;
        RedCrystal.PickUpRedCrystalEvent -= UpdateRedText;
        PurpleCrystal.PickUpPurpleCrystalEvent -= UpdatePurpleSlider;
        BallFowardMovement.ThrowEvent -= ShowPowersUI;
        SlowTime.SlowEvent -= UpdateRedSlider;
        Ghost.GhostEvent -= UpdateRedSlider;
        PowersStats.PowerAmountChangedEvent -= UpdateAllUI;
    }

    void ShowPowersUI() {

        purpleGameObject.SetActive(true);
        powersGameObject.SetActive(true);
        redGameObject.SetActive(true);
    }

    void HidePowerUIs() {

        purpleGameObject.SetActive(false);
        powersGameObject.SetActive(false);
        redGameObject.SetActive(false);
    }

    void UpdateAllUI() {

        UpdatePointsText();
        UpdateRedText();
        UpdatePurpleSlider();
        UpdateRedSlider();
    }

    void UpdatePointsText() {

        pointsText.text = 
            "Points: " +
            levelManager.CurrentPoints +
            " / " + 
            levelManager.MaxPoints;
    }

    void UpdateRedText() {

        redCrystalText.text = powersStats.CurrentRedPower + "x";
    }

    void UpdatePurpleSlider() {

        purpleSlider.value = powersStats.CurrentPurplePower;
    }

    void UpdateRedSlider() {

        redSlider.value = powersStats.RedDuration;

        if (powersStats.RedDuration == 0) {

            redGameObject.SetActive(false);
        }
        else {

            redGameObject.SetActive(true);
        }

    }

    static public void ShowDeathMenu(bool value) {

        GameObject menu = GameObject.FindGameObjectWithTag("DeathMenu");

        for (int i = 0; i < menu.transform.childCount; i++) {

            menu.transform.GetChild(i).gameObject.SetActive(value);
        }
    }
}
