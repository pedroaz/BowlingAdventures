using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallArea : MonoBehaviour {

    public LayerMask laneLayerMask;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        
        if(laneLayerMask == (laneLayerMask | (1 << other.gameObject.layer))) {

            transform.parent.gameObject.GetComponent<Pin>().Fell(); 
        }
    }

    
}
