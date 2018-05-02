using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public Vector3 offset;
    public Transform ballTransform;
    public bool grounded;
    public LayerMask groundLayerMask;

	

    private void LateUpdate() {

        transform.position = ballTransform.transform.position + offset;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter(Collider other) {

        if (groundLayerMask == (groundLayerMask | (1 << other.gameObject.layer))) {

            grounded = true;
        }
    }

    


    private void OnTriggerExit(Collider other) {

        if (groundLayerMask == (groundLayerMask | (1 << other.gameObject.layer))) {

            grounded = false;
        }
    }
}
