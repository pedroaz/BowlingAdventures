using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour {


    //if (SlowTime.isSlow) {
    //        x = x / 3;
    //    }

    [SerializeField] private PowersStats powersStats;

    public float maxDuration;
    public float currentDuration;
    static public bool isSlow;

    public delegate void SlowDelegate();
    static public event SlowDelegate SlowEvent;

	// Use this for initialization
	void Start () {

        isSlow = false;
    }
	
    public void ActivateSlow() {

        if(powersStats.HasRedPower()) {

            if (!isSlow && !Ghost.isGhost) {

                //PowersManager.RemoveRed();

                isSlow = true;

                currentDuration = maxDuration;
                Time.timeScale = 0.3f;
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

            //PowersManager.redDuration = currentDuration / maxDuration;
            SlowEvent();


            yield return null;
        }

        Time.timeScale = 1f;
        isSlow = false;
    }
}
