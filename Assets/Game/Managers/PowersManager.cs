using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour {

    public GameObject manaGameObject;
    public GameObject powersGameObject;

	// Use this for initialization
	void Start () {

        BallThrowMovement.ThrowEvent += ShowPowers;
	}

    private void OnDestroy() {

        BallThrowMovement.ThrowEvent -= ShowPowers;
    }

    // Update is called once per frame
    void Update () {
		
	}

    void ShowPowers() {

        manaGameObject.SetActive(true);
        powersGameObject.SetActive(true);
    }
}
