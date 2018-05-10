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

            currentGameData = (GameData) binaryFormatter.Deserialize(fileStream);

            fileStream.Close();
        }
    }

    public static bool GameDateExists() {

        return File.Exists(Application.persistentDataPath + "/GameData.gd");
    }



}


[Serializable]
public class GameData {

    public LevelData[] earthLevels;
    public LevelData[] fireLevels;
    public LevelData[] waterLevels;
    public LevelData[] airLevels;
    public LevelData[] energyLevels;

    public int GetWorldPoints(World.WORLD_TYPE worldType) {

        int totalPoints = 0;

        switch (worldType) {

            case World.WORLD_TYPE.EARTH:
                for (int i = 0; i < 10; i++) {
                    totalPoints += earthLevels[i].amountOfPintsCollected;
                }
                break;
            case World.WORLD_TYPE.WATER:
                for (int i = 0; i < 10; i++) {
                    totalPoints += waterLevels[i].amountOfPintsCollected;
                }
                break;
            case World.WORLD_TYPE.FIRE:
                for (int i = 0; i < 10; i++) {
                    totalPoints += fireLevels[i].amountOfPintsCollected;
                }
                break;
            case World.WORLD_TYPE.AIR:
                for (int i = 0; i < 10; i++) {
                    totalPoints += airLevels[i].amountOfPintsCollected;
                }
                break;
            case World.WORLD_TYPE.ENERGY:
                for (int i = 0; i < 10; i++) {
                    totalPoints += energyLevels[i].amountOfPintsCollected;
                }
                break;
            default:
                totalPoints = 0;
                break;
        }

        return totalPoints;
    }

    public GameData() {

        earthLevels = new LevelData[10]{
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData()
        };
        fireLevels = new LevelData[10]{
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData()
        };
        waterLevels = new LevelData[10]{
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData()
        };
        airLevels = new LevelData[10]{
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData()
        };
        energyLevels = new LevelData[10]{
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData(),
            new LevelData()
        };
    }

    public void UpdateGameData(LevelManager levelManager) {

        switch (levelManager.SelectedLevel.worldType) {

            case World.WORLD_TYPE.EARTH:
                earthLevels[levelManager.SelectedLevel.levelIndex].amountOfPintsCollected = levelManager.currentPoints;
                earthLevels[levelManager.SelectedLevel.levelIndex].hasWon = levelManager.HasWonLevel();
                break;
            case World.WORLD_TYPE.WATER:
                waterLevels[levelManager.SelectedLevel.levelIndex].amountOfPintsCollected = levelManager.currentPoints;
                waterLevels[levelManager.SelectedLevel.levelIndex].hasWon = levelManager.HasWonLevel();
                break;
            case World.WORLD_TYPE.FIRE:
                fireLevels[levelManager.SelectedLevel.levelIndex].amountOfPintsCollected = levelManager.currentPoints;
                fireLevels[levelManager.SelectedLevel.levelIndex].hasWon = levelManager.HasWonLevel();
                break;
            case World.WORLD_TYPE.AIR:
                airLevels[levelManager.SelectedLevel.levelIndex].amountOfPintsCollected = levelManager.currentPoints;
                airLevels[levelManager.SelectedLevel.levelIndex].hasWon = levelManager.HasWonLevel();
                break;
            case World.WORLD_TYPE.ENERGY:
                energyLevels[levelManager.SelectedLevel.levelIndex].amountOfPintsCollected = levelManager.currentPoints;
                energyLevels[levelManager.SelectedLevel.levelIndex].hasWon = levelManager.HasWonLevel();
                break;
            default:
                break;
        }

        SaveLoadHelper.SaveGame();
    }
}

[Serializable]
public class LevelData{

    public bool hasWon;
    public int amountOfPintsCollected;

    public LevelData() {

        hasWon = false;
        amountOfPintsCollected = 0;
    }
}