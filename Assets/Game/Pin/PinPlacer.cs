using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPlacer : MonoBehaviour {

    public GameObject pinPrefab;
    GameObject pinPos;

	// Use this for initialization
	void Start () {
        pinPos = this.gameObject;
        SpawnAllPins();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnAllPins() {


        for (int pinCount = 0; pinCount < 10; pinCount++) {

            SpawnPin(pinCount);
        }
    }

    void SpawnPin(int childNumber) {

        GameObject pin = Instantiate(pinPrefab);
        pin.transform.position = pinPos.transform.GetChild(childNumber).transform.position;
        childNumber = childNumber + 1;
        pin.name = "Pin-" + childNumber;
    }

    void PlacePin() {

    }
}
