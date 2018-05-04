using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCrystal : MonoBehaviour {


    public LayerMask ballLayerMask;
    public delegate void RedCrystalDelegate();
    public static event RedCrystalDelegate RedCrystalEvent;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            PowersManager.AddRed();
            RedCrystalEvent();
            Destroy(this.gameObject);
        }
    }
}
