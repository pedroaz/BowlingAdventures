using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour {

    [Tooltip("What should be considered the layer mask")]
    [SerializeField] private LayerMask ballLayerMask;

    private void OnTriggerEnter(Collider other) {

        if (GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, ballLayerMask)) {

            if (LevelManager.playerIsAlive) {
                LevelManager.KillPlayer();
            }
        }
    }
}
