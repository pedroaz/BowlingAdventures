using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public BallThrowMovement ballThrowMovement;
    public Vector3 offset;

    private void Awake() {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate() {

        if (!ballThrowMovement.grabbingBall) {

            Vector3 pos = new Vector3(
            offset.x,
            ballThrowMovement.transform.position.y + offset.y,
            ballThrowMovement.transform.position.z + offset.z);

            transform.position = pos;
        }

        
    }
}
