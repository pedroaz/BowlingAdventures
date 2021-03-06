﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataHelper : MonoBehaviour {

    public bool alwaysNewGame;

    private void Awake() {

        if (alwaysNewGame) {

            SaveLoadHelper.NewGame();
        } else {

            if (!SaveLoadHelper.GameDateExists()) {

                SaveLoadHelper.NewGame();
            } else {
                SaveLoadHelper.LoadGame();
            }
        }

    }

}
