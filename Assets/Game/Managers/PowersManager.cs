using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowersManager : MonoBehaviour {

    static public float purplePower;
    static public int redPower;
    static public float redDuration;

    public delegate void PowerDelegate();
    public static event PowerDelegate PowerEvent;
    public SlowTime slowTime;

	// Use this for initialization
	void Start () {

        redPower = 2;
        purplePower = 1f;
        redDuration = 0;
        PowerEvent();
    }

    static public void AddRed() {

        redPower++;
        PowerEvent(); 
    }

    static public void RemoveRed() {
        if(redPower > 1) {
            redPower--;
        }
    }

    static public void AddPurple() {

        purplePower += 0.1f;
        if(purplePower >= 1) {
            purplePower = 1;
        }
        PowerEvent();
    }

    static public void SpendPurple(float x) {

        if (SlowTime.isSlow) {
            x = x / 3;
        }

        purplePower -= x;
        if(purplePower <= 0) {
            purplePower = 0;
        }
        PowerEvent();
    }
}
