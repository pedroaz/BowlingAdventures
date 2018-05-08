using UnityEngine;

public class RedCrystal : MonoBehaviour {

    [Tooltip("Amount of red power gain when the crystal is colletcted")]
    [Range(0, 10)]
    [SerializeField] private int redAmountToGain;

    [Tooltip("What should be considered the ballLayerMask")]
    [SerializeField] private LayerMask ballLayerMask;

    [SerializeField] private PowersStats powersStats;

    /// <summary>
    /// Event called when a red crystal is picked up
    /// </summary>
    public static event PickUpRedCrystalDelegate PickUpRedCrystalEvent;
    public delegate void PickUpRedCrystalDelegate();
    
    private void OnTriggerEnter(Collider other) {

        if (GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, ballLayerMask)) {

            PickUpPurpleCrystal(redAmountToGain);
        }
    }

    /// <summary>
    /// Pick up a purple Crystal and increase the player purple power
    /// </summary>
    void PickUpPurpleCrystal(int redAmountToGain) {

        powersStats.ChangeRedPowerAmount(redAmountToGain);
        PickUpRedCrystalEvent();
        Destroy(this.gameObject);
    }
}
