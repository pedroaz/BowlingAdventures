using System.Collections;
using UnityEngine;

public class SlowTime : MonoBehaviour {


    //if (SlowTime.isSlow) {
    //        x = x / 3;
    //    }


    [SerializeField] private float maxSlowDuration;

    [SerializeField] private PowersStats powersStats;

    [SerializeField] private float currentDuration;

    static public bool isSlow;

    /// <summary>
    /// This event is called when the ghost object is activated
    /// </summary>
    static public event SlowDelegate SlowEvent;
    public delegate void SlowDelegate();

	// Use this for initialization
	void Start () {

        isSlow = false;
    }
	
    public void ActivateSlow() {

        if(powersStats.HasRedPower()) {

            if (!isSlow && !Ghost.isGhost) {

                powersStats.ChangeRedPowerAmount(-1);
                
                currentDuration = maxSlowDuration;

                SlowTheTime(true);

                StartCoroutine(Duration());
            }
        }
    }

    IEnumerator Duration() {

        while (currentDuration > 0) {

            currentDuration-= 0.01f;
            if (currentDuration < 0.01f) {
                currentDuration = 0;
            }

            powersStats.RedDuration = currentDuration / maxSlowDuration;
            SlowEvent();
            yield return null;
        }

        SlowTheTime(false);

    }

    void SlowTheTime(bool value) {

        if (value) {

            isSlow = true;
            Time.timeScale = 0.3f;
        }
        else {

            Time.timeScale = 1f;
            isSlow = false;
        }
    }
}
