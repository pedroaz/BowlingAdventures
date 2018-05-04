using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public BallThrowMovement ballThrowMovement;
    public Vector3 offset;

    private void Awake() {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void LateUpdate() {

        if (ballThrowMovement.ballIsMoving) {

            transform.position = ballThrowMovement.transform.position + offset;
        }
    }
}
