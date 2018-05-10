using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour {

    [SerializeField] private float maxGhostDuration;
    [SerializeField] private float currentDuration;

    [SerializeField] private PowersStats powersStats;

    [SerializeField] private GameObject ball;

    /// <summary>
    /// This event is called when the ghost power is activated
    /// </summary>
    static public event GhostDelegate GhostEvent;
    public delegate void GhostDelegate();

    static public bool isGhost;


    void Start () {

        isGhost = false;
    }
	
    /// <summary>
    /// If has all the conditions active the ghost power
    /// </summary>
    public void ActivateGhost() {

        if (powersStats.HasRedPower()) {

            if (!isGhost && !SlowTime.isSlow) {

                powersStats.ChangeRedPowerAmount(-1);

                currentDuration = maxGhostDuration;

                ChangeToGhostLayer(true);

                StartCoroutine(Duration());
            }
        }

    }

    /// <summary>
    /// Decrease the duration of the power
    /// </summary>
    /// <returns></returns>
    IEnumerator Duration() {

        while (currentDuration > 0) {

            currentDuration -= 0.01f;
            if (currentDuration < 0.01f) {
                currentDuration = 0;
            }
            powersStats.RedDuration = currentDuration / maxGhostDuration;
            GhostEvent();
            yield return null;
        }


        ChangeToGhostLayer(false);
    }

    /// <summary>
    /// Change to ghost layer and change static variable
    /// </summary>
    /// <param name="value"></param>
    void ChangeToGhostLayer(bool value) {

        if (value) {

            isGhost = true;
            ball.layer = 11;
        }
        else {

            isGhost = false;
            ball.layer = 9;
        }
    }
}
