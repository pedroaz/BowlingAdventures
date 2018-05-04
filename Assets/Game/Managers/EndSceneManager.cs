using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneManager : MonoBehaviour {

    public GameObject gameCamera;
    GameObject endCamera;
    public Transform ballTransform;
    LevelManager levelManager;

	// Use this for initialization
	void Start () {

        endCamera = GameObject.FindGameObjectWithTag("EndCamera");
        levelManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndScene() {

        SwitchCameras();
        PositionBall();
        StartCoroutine(End());
    }

    void SwitchCameras() {

        gameCamera.gameObject.SetActive(false);
        endCamera.GetComponent<Camera>().enabled = true;
        endCamera.GetComponent<AudioListener>().enabled = true;
        endCamera.GetComponent<FlareLayer>().enabled = true;
    }

    void PositionBall() {

        ballTransform.position = new Vector3(
            0, ballTransform.position.y, ballTransform.position.z);
    }

    IEnumerator End() {

        yield return new WaitForSeconds(2);
        levelManager.EndLevel();
    }
}
