using UnityEngine;

/// <summary>
/// Ball side movement controller
/// </summary>
public class BallSideMovement : MonoBehaviour {

    [SerializeField] private BallStats ballStats;
        
    [SerializeField] private PowersStats powersStats;

    [SerializeField] private LevelManager levelManager;

    private Rigidbody rigid;

    private void Awake() {

        rigid = GetComponent<Rigidbody>();
    }

    private void Update() {

        SpendPurplePower(-0.005f, 0.05f);
    }

    private void FixedUpdate() {

        SideMovement();
    }


    /// <summary>
    /// Move the ball sideways. 
    /// Use the ballstats scriptable object to get the speed
    /// Only moves if has purple power
    /// </summary>
    void SideMovement() {

        float sideVelocity;

        if (BallIsRolling()) {

            if (powersStats.HasPurplePower()) {

                sideVelocity = Input.acceleration.x * ballStats.BallSideVelocity;
            }
            else {

                sideVelocity = 0;
            }

            rigid.velocity = new Vector3(
                    sideVelocity,
                    rigid.velocity.y,
                    ballStats.BallInitialFowardSpeed
            );
        }
    }

    /// <summary>
    /// Spends purple power when ball is moving
    /// with veloicty above certain threshold 
    /// </summary>
    /// <param name="amountToSpend">Amount of purple power to spend</param>
    /// <param name="threshold">Speed threshold</param>
    void SpendPurplePower(float amountToSpend, float threshold) {

        if (BallIsRolling()) {

            if (IsOverPurpleSpeed(threshold)) {

                powersStats.ChangePurplePowerAmount(amountToSpend);
            }
        }
    }

    /// <summary>
    /// Check if ball is curentaly rolling
    /// </summary>
    /// <returns></returns>
    bool BallIsRolling() {

        return ballStats.ballIsMoving && levelManager.PlayerIsAlive();
    }

    /// <summary>
    /// Check if Ball is over speed threshold
    /// </summary>
    /// <param name="threshold"></param>
    /// <returns></returns>
    bool IsOverPurpleSpeed(float threshold) {

        float accelerationValue = Mathf.Abs(Input.acceleration.x);

        return (accelerationValue > threshold);
    }

    

}
