using UnityEngine;

public class HitCollider : MonoBehaviour {

    [Tooltip("What should be considered the layer mask")]
    [SerializeField] private LayerMask ballLayerMask;

    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter(Collider other) {

        if (GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, ballLayerMask)) {

            if (levelManager.PlayerIsAlive()) {
                levelManager.KillPlayer();
            }
        }
    }
}
