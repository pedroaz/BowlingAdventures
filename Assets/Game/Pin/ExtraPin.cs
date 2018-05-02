using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraPin : MonoBehaviour {

    public LayerMask ballLayerMask;

    public delegate void ExtraPinDelegate();
    public static event ExtraPinDelegate ExtraPinEvent;

	// Use this for initialization
	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            RoundManager.AddPoint();
            Destroy(gameObject);
            ExtraPinEvent();
        }
    }
}
