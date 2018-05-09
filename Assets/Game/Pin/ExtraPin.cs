using UnityEngine;

public class ExtraPin : MonoBehaviour {

    [Tooltip("LayerMask of what is considered to be the ball")]
    [SerializeField] private LayerMask ballLayerMask;

    /// <summary>
    /// This event is called when an extra pin is picked up
    /// </summary>
    public static event PickUpExtraPinDelegate PickUpExtraPinEvent;
    public delegate void PickUpExtraPinDelegate();

    [SerializeField] LevelManager levelManager;

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            levelManager.AddPoints(1);
            PickUpExtraPinEvent();
            Destroy(gameObject);
        }
    }
}
