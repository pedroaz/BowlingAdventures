using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRollingMovement : MonoBehaviour {

    public BallThrowMovement ballThrowMovement;
    public float turningSpeed;
    Rigidbody rigid;


    // Use this for initialization
    void Start () {

        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (ballThrowMovement.ballIsMoving && LevelManager.playerIsAlive) {

            float accelerationValue = Mathf.Abs(Input.acceleration.x);

            if (accelerationValue > 0.05) {

                PowersManager.SpendPurple(0.005f);
            }
        }

        
    }

    private void FixedUpdate() {

        float xValue;

        if (ballThrowMovement.ballIsMoving && LevelManager.playerIsAlive) {


            if(PowersManager.purplePower > 0) {

                xValue = Input.acceleration.x * turningSpeed;
            }
            else {
                xValue = 0;
            }

            rigid.velocity = new Vector3(
                    xValue,
                    rigid.velocity.y,
                    ballThrowMovement.zSpeed
                );

        }
    }

}
