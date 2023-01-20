using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveGameManager
{
    public static SaveData CurrentSaveData = new SaveData();

    public const string SaveDirectory = "/Saves/";

    public const string FileName = "SaveData.sav";


    public static bool SaveGame()
    {
        var dir = Application.persistentDataPath + SaveDirectory;

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (!File.Exists(dir + FileName))
        {
            CurrentSaveData.ScoreSaveData.ScoreDataInt = 0;
        }
        string json = JsonUtility.ToJson(CurrentSaveData, true);
        File.WriteAllText(dir + FileName, json);

        //GUIUtility.systemCopyBuffer = dir; //Save dosyasý yolunu kopyalama 
        return true;
    }
    public static void LoadGame()
    {
        var dir = Application.persistentDataPath + SaveDirectory;
        if (!File.Exists(dir + FileName))
        {
            SaveGame();
        }
        string fullPath = Application.persistentDataPath + SaveDirectory + FileName;
        SaveData tempData = new SaveData();

        if (File.Exists(fullPath))
        {
            string json = File.ReadAllText(fullPath);
            tempData = JsonUtility.FromJson<SaveData>(json);
        }
        else
        {
            Debug.Log("Save file does not exists");
        }
        CurrentSaveData = tempData;
    }
    public static void NewGameSave()
    {
        var dir = Application.persistentDataPath + SaveDirectory;
        if (Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        if (File.Exists(dir + FileName))
        {
            File.Delete(dir + FileName);

        }
    }
}