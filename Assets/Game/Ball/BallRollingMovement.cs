using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRollingMovement : MonoBehaviour {

    public BallThrowMovement ballThrowMovement;
    public float turningSpeed;
    Rigidbody rigid;
    public bool wasHit;


    // Use this for initialization
    void Start () {

        rigid = GetComponent<Rigidbody>();
        wasHit = false;
    }
	
    private void FixedUpdate() {

        if (ballThrowMovement.ballIsMoving && !wasHit) {
            rigid.velocity = new Vector3(
                Input.acceleration.x * turningSpeed,
                rigid.velocity.y,
                ballThrowMovement.zSpeed
            );
        }
    }

    public void Hit() {

        wasHit = true;
    }
}
