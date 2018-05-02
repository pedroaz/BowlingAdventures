using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundUI : MonoBehaviour {

    Text roundText;

    private void Awake() {

        roundText = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {

        RoundManager.NextRoundEvent += UpdateText;
        UpdateText();
    }

    private void OnDestroy() {
        RoundManager.NextRoundEvent -= UpdateText;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void UpdateText() {


        roundText.text = "Round: " + LevelManager.currentRound + " / " + LevelManager.maxRounds;
    }
}
