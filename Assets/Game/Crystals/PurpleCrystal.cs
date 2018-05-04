using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleCrystal : MonoBehaviour {

    public LayerMask ballLayerMask;
    public delegate void PurpleCrystalDelegate();
    public static event PurpleCrystalDelegate PurpleCrystalEvent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            PowersManager.AddPurple();
            PurpleCrystalEvent();
            Destroy(this.gameObject);
        }
    }
}
