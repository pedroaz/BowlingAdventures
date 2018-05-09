using UnityEngine;

public class JumpMovement : MonoBehaviour {

    [SerializeField] private BallStats ballStats;

    [SerializeField] private LevelManager levelManager;

    Rigidbody rigid;


    private void Start() {

        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (Input.touchCount == 1 && ballStats.ballIsMoving) {

            if (IsClickingOnJumpingArea()) {


                if (ballStats.grounded && levelManager.PlayerIsAlive()) {
                    Jump();
                }
            }
        }
    }

    bool IsClickingOnJumpingArea() {

        return Input.GetTouch(0).position.y > 200;
    }

    void Jump() {


        rigid.velocity = new Vector3(
                        rigid.velocity.x,
                        ballStats.BallJumpVelocity,
                        rigid.velocity.z);
    }
}
