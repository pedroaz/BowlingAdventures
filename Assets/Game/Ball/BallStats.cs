using UnityEngine;

/// <summary>
/// Stats of the bowling ball like velocity and if it is moving
/// </summary>
[CreateAssetMenu(fileName = "BallStats")]
public class BallStats : ScriptableObject {

    
    [Tooltip("Velocity which the ball move sideways")]
    [SerializeField]
    private float ballSideVelocity;

    [Tooltip("The speed which the ball goes foward")]
    [SerializeField]
    private float ballFowardVelocity;

    [Tooltip("The initial foward speed of the ball")]
    [SerializeField]
    private float ballInitialFowardSpeed;

    [Tooltip("Jump velocity which is aplied when the ball jump")]
    [SerializeField]
    private float ballJumpVelocity;

    [SerializeField]
    public bool
        ballIsMoving, // bool to check when the ball is moving
        grounded; // bool to check when the ball is grounded


    [ExecuteInEditMode]
    void OnValidate() {

        ballSideVelocity = Mathf.Clamp(ballSideVelocity, 0, 100);
        ballFowardVelocity = Mathf.Clamp(ballFowardVelocity, 0, 100);
        ballInitialFowardSpeed = Mathf.Clamp(ballInitialFowardSpeed, 0, 100);
        ballJumpVelocity = Mathf.Clamp(ballJumpVelocity, 0, 100);
    }

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

    public float BallInitialFowardSpeed {
        get {

            return ballInitialFowardSpeed;
        }
    }

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

}
