using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerStats")]
public class PowersStats : ScriptableObject {

   [SerializeField] private float startingPurplePower;
   [SerializeField] private float currentPurplePower;
   [SerializeField] private float redDuration;


    /// <summary>
    /// Purple Power varies between 0 and 1
    /// </summary>
    public float CurrentPurplePower {

        get {

            return currentPurplePower;
        }

        set {

            currentPurplePower = value;
            Mathf.Clamp01(CurrentPurplePower);
        }
    }

    /// <summary>
    /// Red Power varies between 0 and 1
    /// </summary>
    public int CurrentRedPower {

        get {

            return currentRedPower;
        }

        set {

            currentRedPower = value;
            Mathf.Clamp01(currentRedPower);
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

            redDuration = value;
            Mathf.Clamp01(redDuration);
        }
    }

    [SerializeField]
    private int 
        startingRedPower,
        currentRedPower;

    /// <summary>
    /// Event is called when some power amount (red or puple is changed)
    /// Used for example on the UI
    /// </summary>
    public static event PowerAmountWasChanged PowerAmountChangedEvent;
    public delegate void PowerAmountWasChanged();

    /// <summary>
    /// To be called when the game is reseted. 
    /// Resets power values to inital values
    /// </summary>
    public void ResetPowerStats() {

        currentPurplePower = startingPurplePower;
        currentRedPower = startingRedPower;
    }

    /// <summary>
    /// Change red power amount
    /// </summary>
    public void ChangeRedPowerAmount(int value) {

        CurrentRedPower += value;
        PowerAmountChangedEvent(); 
    }


    /// <summary>
    /// Change purple power amount
    /// </summary>
    public void ChangePurplePowerAmount(float value) {

        CurrentPurplePower += value;
        PowerAmountChangedEvent();
    }

    public bool HasPurplePower() {

        return CurrentPurplePower > 0;
    }

    public bool HasRedPower() {

        return CurrentPurplePower > 0;
    }
}
