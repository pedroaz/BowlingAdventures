using UnityEngine;

public class PurpleCrystal : MonoBehaviour {

    [Tooltip("Percentage value between 0 and 1.")]
    [SerializeField] private float percentageToGain;

    [SerializeField] private PowersStats powersStats;

    [SerializeField] private LayerMask ballLayerMask;

    /// <summary>
    /// Event called when a purple crystal is picked up
    /// </summary>
    public static event PickUpPurpleCrystalDelegate PickUpPurpleCrystalEvent;
    public delegate void PickUpPurpleCrystalDelegate();

    [ExecuteInEditMode]
    void OnValidate() {
        percentageToGain = Mathf.Clamp01(percentageToGain);
    }

    private void OnTriggerEnter(Collider other) {

        if (GeneralFunctionsHelper.CheckLayerCollision(other.gameObject.layer, ballLayerMask)) {

            PickUpPurpleCrystal(percentageToGain);
        }
    }

    /// <summary>
    /// Pick up a purple Crystal and increase the player purple power
    /// </summary>
    void PickUpPurpleCrystal(float percentageToGain) {

        powersStats.ChangePurplePowerAmount(percentageToGain);
        PickUpPurpleCrystalEvent();
        Destroy(this.gameObject);
    }


}
