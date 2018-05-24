using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadHelper {

    public static GameData currentGameData;

    public static void NewGame() {

        GameData gameData = new GameData();

        currentGameData = gameData;

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/GameData.gd", FileMode.Create);

        binaryFormatter.Serialize(fileStream, gameData);

        fileStream.Close();
    }

    public static void SaveGame() {

        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/GameData.gd", FileMode.Create);

        binaryFormatter.Serialize(fileStream, currentGameData);

        fileStream.Close();
    }

    public static void LoadGame() {

        if (GameDateExists()) {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream(Application.persistentDataPath + "/GameData.gd", FileMode.Open);

            currentGameData = (GameData)binaryFormatter.Deserialize(fileStream);

            fileStream.Close();
        }
    }

    public static bool GameDateExists() {

        return File.Exists(Application.persistentDataPath + "/GameData.gd");
    }
}


[Serializable]
public class GameData {

    public bool[] planetsPermission;

    public GameData() {

        planetsPermission = new bool[10];
        for (int i = 0; i < 10; i++) {

            if(i == 0) {

                planetsPermission[i] = true;
            } else {

                planetsPermission[i] = false;
            }
        }
    }

    public void UpdateGameData(LevelManager levelManager) {

        SaveLoadHelper.SaveGame();
    }
}

