using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level")]
public class World : ScriptableObject {

    public string worldName;
    public List<Level> listOfLevels;
}
