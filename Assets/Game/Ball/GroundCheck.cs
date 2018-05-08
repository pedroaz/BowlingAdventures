using UnityEngine;

/// <summary>
/// Simple ground check class
/// Check if box collider is touching the groundLayerMask
/// Updates the grounded variable accordingly
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class GroundCheck : MonoBehaviour {

    [Tooltip("Which layers should be considered ground")]
    [SerializeField] private LayerMask groundLayerMask;

    [Tooltip("Offset of the collider to the ball")]
    [SerializeField] private Vector3 offset;

    [SerializeField] private BallStats ballStats;

    Transform ballTransform;

    private void Awake() {

        ballTransform = transform.parent.transform;
    }

    private void LateUpdate() {

        UpdateBoxColliderPositions();
    }

    private void OnTriggerEnter(Collider other) {

        if (GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, groundLayerMask)) {

            ballStats.Grounded = true;
        }
    }

    private void OnTriggerExit(Collider other) {

        if(GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, groundLayerMask)) {

            ballStats.Grounded = true;
        }
    }

    /// <summary>
    /// Update the box collider to be under the ball
    /// </summary>
    void UpdateBoxColliderPositions() {

        transform.position = ballTransform.transform.position + offset;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

}
