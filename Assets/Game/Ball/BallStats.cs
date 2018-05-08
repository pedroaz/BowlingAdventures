using UnityEngine;

/// <summary>
/// Stats of the bowling ball like velocity and if it is moving
/// </summary>
[CreateAssetMenu(fileName = "BallStats")]
public class BallStats : ScriptableObject {

    
    [Tooltip("Velocity which the ball move sideways")]
    [SerializeField] private float ballSideVelocity;

    [Tooltip("The speed which the ball goes foward")]
    [SerializeField] private float ballFowardVelocity;

    [Tooltip("The initial foward speed of the ball")]
    [SerializeField] private float ballInitialFowardSpeed;

    [Tooltip("Jump velocity which is aplied when the ball jump")]
    [SerializeField] private float ballJumpVelocity;
    
    private bool
        ballIsMoving, // bool to check when the ball is moving
        grounded; // bool to check when the ball is grounded


    [ExecuteInEditMode]
    void OnValidate() {

        ballSideVelocity = Mathf.Clamp(ballSideVelocity, 0, 100);
        ballFowardVelocity = Mathf.Clamp(ballFowardVelocity, 0, 100);
        ballInitialFowardSpeed = Mathf.Clamp(ballInitialFowardSpeed, 0, 100);
        ballJumpVelocity = Mathf.Clamp(ballJumpVelocity, 0, 100);
    }

    /// <summary>
    /// Velocity of the ball
    /// </summary>
    public float BallSideVelocity {

        get {

            return ballSideVelocity;
        }
        set {

            if (value > 0) {

                ballSideVelocity = value;
            }
        }
    }

    /// <summary>
    /// Foward velocity of the ball
    /// </summary>
    public float BallFowardVelocity {

        get {

            return ballFowardVelocity;
        }
        set {

            if (value > 0) {

                ballFowardVelocity = value;
            }
        }
    }

    /// <summary>
    /// Initla Speed of the Ball
    /// </summary>
    public float BallInitialSpeed {
        get {

            return BallInitialSpeed;
        }
    }

    /// <summary>
    /// Jump velocity of the ball
    /// </summary>
    public float BallJumpVelocity {

        get {

            return ballJumpVelocity;
        }
        set {

            if (value > 0) {

                ballJumpVelocity = value;
            }
        }
    }

    /// <summary>
    /// Is the ball moving
    /// </summary>
    public bool BallIsMoving{ get; set; }

    /// <summary>
    /// Is the ball grounded
    /// </summary>
    public bool Grounded {
        get {

            return grounded;
        }
        set {

            grounded = value;
        }
    }
}
