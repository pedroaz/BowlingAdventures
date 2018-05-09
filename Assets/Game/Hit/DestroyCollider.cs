using UnityEngine;

public class DestroyCollider : MonoBehaviour {

    // TODO: Change to destroy

    [SerializeField] private bool showMenu;

    [Tooltip("What should be considered the layer mask")]
    [SerializeField] private LayerMask ballLayerMask;

    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter(Collider other) {

        if (GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, ballLayerMask)) {

            if (levelManager.PlayerIsAlive()) {
                levelManager.KillPlayer(showMenu);
            }
        }
    }
}
