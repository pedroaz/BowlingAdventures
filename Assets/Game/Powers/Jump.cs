using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour {

    BallThrowMovement ballThrowMovement;
    public GroundCheck groundCheck;
    Rigidbody rigid;
    public float jumpSpeed;
    
    

    private void Start() {
        ballThrowMovement = GetComponent<BallThrowMovement>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (Input.touchCount == 1 && ballThrowMovement.ballIsMoving) {

            if(Input.GetTouch(0).position.y > 200) {

                if (groundCheck.grounded && LevelManager.playerIsAlive) {

                    rigid.velocity = new Vector3(
                        rigid.velocity.x,
                        jumpSpeed,
                        rigid.velocity.z);
                }
            }
        }
    }
}
