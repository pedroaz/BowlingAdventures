using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectMenuTheme : MonoBehaviour {

    [SerializeField] private Universe universe;

    [SerializeField] private Color earthColor;
    [SerializeField] private Color waterColor;
    [SerializeField] private Color airColor;
    [SerializeField] private Color fireColor;
    [SerializeField] private Color energyColor;
    

    [SerializeField] private List<Image> listOfButtons;
    [SerializeField] private TextMeshProUGUI textMesh;

    // Use this for initialization
    void Start () {

        Color colorToBeUsed;

        switch (universe.selectedWorld.worldType) {

            case World.WORLD_TYPE.EARTH:
                textMesh.text = "Earth";
                colorToBeUsed = earthColor;
                break;
            case World.WORLD_TYPE.WATER:
                textMesh.text = "Water";
                colorToBeUsed = waterColor;
                break;
            case World.WORLD_TYPE.FIRE:
                textMesh.text = "Fire";
                colorToBeUsed = fireColor;
                break;
            case World.WORLD_TYPE.AIR:
                textMesh.text = "Air";
                colorToBeUsed = airColor;
                break;
            case World.WORLD_TYPE.ENERGY:
                textMesh.text = "Energy";
                colorToBeUsed = energyColor;
                break;
            default:
                colorToBeUsed = earthColor;
                break;
        }

        foreach (Image button in listOfButtons) {

            button.color = colorToBeUsed;
        }

	}
	
}
