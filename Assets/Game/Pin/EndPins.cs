using System.Collections.Generic;
using UnityEngine;

public class EndPins : MonoBehaviour {

    [SerializeField] private LayerMask ballLayerMask;

    [SerializeField] private List<Rigidbody> listOfFinalPins;

    [SerializeField] private LevelManager levelManager;

    EndDisplayManager endDisplayManager;

    // Use this for initialization
    void Start () {

        endDisplayManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<EndDisplayManager>();
    }


    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            endDisplayManager.EndDisplay();
            levelManager.AddPoints(10);
            ExplodePins();
            SaveGame();
        }
    }

    /// <summary>
    /// Send all the pins from the list to diferent directions
    /// </summary>
    void ExplodePins() {

        // TODO: Strike sounds

        float explosionVelocity = 10;

        foreach (Rigidbody rigid in listOfFinalPins) {

            rigid.velocity = new Vector3(

                Random.Range(-1.0f, 1.0f) * explosionVelocity,
                Random.Range(-1.0f, 1.0f) * explosionVelocity,
                Random.Range(-1.0f, 1.0f) * explosionVelocity
            );
        }
    }

    void SaveGame() {

        SaveLoadHelper.currentGameData.UpdateGameData(levelManager);
    }
}
