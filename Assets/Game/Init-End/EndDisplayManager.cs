using System.Collections;
using UnityEngine;

public class EndDisplayManager : MonoBehaviour {

    [SerializeField] private GameObject gameCamera;
    [SerializeField] Transform ballTransform;

    GameObject endCamera;
    [SerializeField] private LevelManager levelManager;

	void Start () {

        endCamera = GameObject.FindGameObjectWithTag("EndCamera");
    }
	
    /// <summary>
    /// Player the end scene of each level
    /// </summary>
    public void EndDisplay() {

        SwitchCameras();
        PositionBallOnCenter();
        StartCoroutine(End());
    }

    /// <summary>
    /// Switch from the main camera to the End scene Camera
    /// </summary>
    void SwitchCameras() {

        gameCamera.gameObject.SetActive(false);
        endCamera.GetComponent<Camera>().enabled = true;
        endCamera.GetComponent<AudioListener>().enabled = true;
        endCamera.GetComponent<FlareLayer>().enabled = true;
    }

    /// <summary>
    /// Position the ball on the center of the trak
    /// </summary>
    void PositionBallOnCenter() {

        ballTransform.position = new Vector3(
            0, ballTransform.position.y, ballTransform.position.z);
    }

    /// <summary>
    /// End two seconds and end the level
    /// </summary>
    /// <returns></returns>
    IEnumerator End() {

        yield return new WaitForSeconds(2);
        levelManager.EndLevel();
    }
}
