using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPins : MonoBehaviour {

    public LayerMask ballLayerMask;
    public List<Rigidbody> listOfPints;

    public EndSceneManager endSceneManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {

        if (ballLayerMask == (ballLayerMask | (1 << other.gameObject.layer))) {

            endSceneManager.EndScene();

            LevelManager.AddPoints(10);
            ExplodePints();
        }
    }

    void ExplodePints() {

        float explosionVelocity = 10;

        foreach (Rigidbody rigid in listOfPints) {

            rigid.velocity = new Vector3(

                

                Random.Range(-1.0f, 1.0f) * explosionVelocity,
                Random.Range(-1.0f, 1.0f) * explosionVelocity,
                Random.Range(-1.0f, 1.0f) * explosionVelocity
            );
        }
    }
}
