using UnityEngine;

/// <summary>
/// Ball foward movement controller
/// </summary>
public class BallFowardMovement : MonoBehaviour {


    [SerializeField] private BallStats ballStats;

    private Rigidbody rigid;

    /// <summary>
    /// Event called when ball is thrown
    /// </summary>
    public static event ThrowDelegate ThrowEvent;
    public delegate void ThrowDelegate();

    private void Awake() {

        rigid = GetComponent<Rigidbody>();
    }

    void Start () {

        FreezeBall(true);
    }
  
    void Update () {

        ThorwBallInput();
    }

    /// <summary>
    /// Recives a single touch on screen to throw ball
    /// </summary>
    void ThorwBallInput() {

        if (!ballStats.BallIsMoving) {

            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended) {

                ThrowBall();
            }
        }
    }

    /// <summary>
    /// Thorw the ball with the ball stats speed
    /// </summary>
    void ThrowBall() {

        FreezeBall(false);

        rigid.velocity = new Vector3(0, 0, ballStats.BallInitialSpeed);

        ThrowEvent();
    }

    /// <summary>
    /// Freeze or unfreeze the ball position
    /// </summary>
    /// <param name="value">If true, ball freezes</param>
    void FreezeBall(bool value) {

        if (value) {
            ballStats.BallIsMoving = false;
            rigid.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else {
            ballStats.BallIsMoving = true;
            rigid.constraints = RigidbodyConstraints.None;
        }


    }
}
