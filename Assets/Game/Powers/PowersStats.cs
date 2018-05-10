using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerStats")]
public class PowersStats : ScriptableObject {

   private float currentPurplePower;
   private int currentRedPower;
   private float redDuration;

    /// <summary>
    /// Purple Power varies between 0 and 1
    /// </summary>
    public float CurrentPurplePower {

        get {

            return currentPurplePower;
        }

        set {

            currentPurplePower = Mathf.Clamp01(value);
        }
    }

    /// <summary>
    /// Red Power varies between 0 and 1
    /// </summary>
    public int CurrentRedPower {

        get{

            return currentRedPower;
        }

        set {

            currentRedPower = value;
        }
    }

    /// <summary>
    /// Red duration varies between 0 and 1
    /// </summary>
    public float RedDuration {

        get {
            return redDuration;
        }

        set {

            redDuration = Mathf.Clamp01(value);
        }
    }

  
    public static event PurpleAmountChangedDelegate PurpleAmountChangedEvent;
    public delegate void PurpleAmountChangedDelegate();

    public static event RedAmountChangedDelegate RedAmountChangedEvent;
    public delegate void RedAmountChangedDelegate();

    /// <summary>
    /// Change red power amount
    /// </summary>
    public void ChangeRedPowerAmount(int value) {

        CurrentRedPower += value;
        RedAmountChangedEvent(); 
    }


    /// <summary>
    /// Change purple power amount
    /// </summary>
    public void ChangePurplePowerAmount(float value) {

        CurrentPurplePower += value;
        PurpleAmountChangedEvent();
    }

    public bool HasPurplePower() {

        return CurrentPurplePower > 0;
    }

    public bool HasRedPower() {

        return CurrentPurplePower > 0;
    }
}
