using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

    public LayerMask ballLayerMask;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {


            if (LevelManager.playerIsAlive) {
                LevelManager.KillPlayer();
            }
        }
    }
}
