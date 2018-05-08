using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controlls the main camera
/// It follows the Ball with an offset
/// Also set the screen orientation to portrait mode
/// </summary>
public class CameraController : MonoBehaviour {

    [Tooltip("The offsed of the camera to the ball")]
    [SerializeField] private Vector3 offset;

    [SerializeField] private BallStats ballStats;

    [SerializeField] private GameObject ball;


    private void Awake() {

        Screen.orientation = ScreenOrientation.Portrait;
    }

    private void LateUpdate() {

        if (ballStats.BallIsMoving) {

            transform.position = ball.transform.position + offset;
        }
    }
}
