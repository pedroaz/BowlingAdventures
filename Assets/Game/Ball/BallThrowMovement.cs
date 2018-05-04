using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowMovement : MonoBehaviour {

    // Components
    Rigidbody rigid;

    // Variables
    public float zSpeed;

    public bool ballIsMoving;

    public delegate void ThrowDelegate();
    public static event ThrowDelegate ThrowEvent; 

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {


        // Bottom left
        FreezeBall(true);
        ballIsMoving = false;
    }

  
    // Update is called once per frame
    void Update () {

        if (Input.touchCount == 1 && !ballIsMoving) {

            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Ended) {

                ThrowBall();
            }

        }
	}


    void FreezeBall(bool value) {

        if (value) {
            rigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else {
            rigid.constraints = RigidbodyConstraints.None;
        }
    }

    void ThrowBall() {

        FreezeBall(false);

        rigid.velocity = new Vector3(0, 0, zSpeed);

        ballIsMoving = true;

        ThrowEvent();
    }


}
