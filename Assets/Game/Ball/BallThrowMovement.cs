using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrowMovement : MonoBehaviour {

    // Components
    public BoxCollider laneCollider;
    Rigidbody rigid;

    // Variables
    public float zSpeed;
    public float xSpeed;
    Vector2 beganPos;
    Vector2 movedPos;
    Vector2 endedPos;
    float xLimit;
    Vector2 direction;
    Vector3 velocity;

    public bool ballIsMoving;
    public bool grabbingBall;

    public delegate void ThrowDelegate();
    public static event ThrowDelegate ThrowEvent; 

    private void Awake() {
        rigid = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {


        // Bottom left
        xLimit = laneCollider.bounds.extents.x;
        FreezeBall(true);
        ballIsMoving = false;
    }

  
    // Update is called once per frame
    void Update () {

        if (Input.touchCount == 1 && !ballIsMoving) {

            Touch touch = Input.GetTouch(0);

            switch (touch.phase) {
                case TouchPhase.Began:
                    BeganPhase(touch);
                    break;
                case TouchPhase.Moved:
                    MovedPhase(touch);
                    break;
                case TouchPhase.Stationary:
                    break;
                case TouchPhase.Ended:
                    EndedPhase(touch);
                    break;
                case TouchPhase.Canceled:
                    break;
                default:
                    break;
            }

        }
	}

    void BeganPhase(Touch touch) {

        beganPos = touch.position;
        grabbingBall = true;
    }

    void MovedPhase(Touch touch) {

        movedPos = touch.position;

        float xMovementPercent;
        Vector3 pos;

        xMovementPercent = movedPos.x / Screen.width;

        pos = new Vector3(
            -xLimit + xLimit * 2 * xMovementPercent,
            transform.position.y,
            transform.position.z);


        transform.position = pos;
        
    }

    void EndedPhase(Touch touch) {

        endedPos = touch.position;

        grabbingBall = false;

        ThrowBall();
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
        grabbingBall = false;

       

        direction = GetDirection();

        if(direction == null){
            direction = new Vector3();
            direction.x = 0;
        }

        velocity = new Vector3(
            xSpeed * direction.x,
            0,
            zSpeed);


        rigid.velocity = velocity;

        ballIsMoving = true;

        ThrowEvent();

    }

    Vector2 GetDirection() {

        Vector2 heading = endedPos - beganPos;
        float distance = heading.magnitude;

        return (heading / distance);
    }

}
