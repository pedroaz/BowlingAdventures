using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Universe")]
public class Universe : ScriptableObject {

    public List<World> listOfWorlds;

    public World selectedWorld;

    public void SelectWorld(int i) {

        selectedWorld = listOfWorlds[i];
    }
}
