using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public bool hasFallen;
    public delegate void PinFellDelegate();
    public static event PinFellDelegate PinFellEvent;


    // Use this for initialization
    void Start () {

        hasFallen = false;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Fell() {

        if (!hasFallen) {

            hasFallen = true;
            PinFellEvent();
        }
        
    }
}
