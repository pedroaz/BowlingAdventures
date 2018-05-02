using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour {

    public RoundManager roundsManager;
    Text pointsText;

    private void Awake() {

        pointsText = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {

        Pin.PinFellEvent += UpdateText;
        ExtraPin.ExtraPinEvent += UpdateText;
        UpdateText();
    }

    private void OnDestroy() {

        Pin.PinFellEvent -= UpdateText;
        ExtraPin.ExtraPinEvent -= UpdateText;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void UpdateText() {

        pointsText.text = "Points: " + LevelManager.currentPoints  + " / " + LevelManager.selectedLevel.pointsRequired;
    }
}
