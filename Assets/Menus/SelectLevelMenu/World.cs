using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level")]
public class World : ScriptableObject {

    public enum WORLD_TYPE {EARTH, WATER, FIRE, AIR, ENERGY}
    public WORLD_TYPE worldType;
    public string worldName;
    public List<Level> listOfLevels;
}
