using UnityEngine;

public class JumpMovement : MonoBehaviour {

    [SerializeField] private float jumpSpeed;

    [SerializeField] private BallStats ballStats;

    [SerializeField] private LevelManager levelManager;

    Rigidbody rigid;


    private void Start() {

        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (Input.touchCount == 1 && ballStats.BallIsMoving) {

            if (IsClickingOnJumpingArea()) {

                if (ballStats.Grounded && levelManager.PlayerIsAlive()) {

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
                        jumpSpeed,
                        rigid.velocity.z);
    }
}
