using UnityEngine;

public class ExtraPin : MonoBehaviour {

    [Tooltip("LayerMask of what is considered to be the ball")]
    [SerializeField] private LayerMask ballLayerMask;

    [SerializeField] LevelManager levelManager;

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            levelManager.AddPoints(1);
            Destroy(gameObject);
        }
    }
}
