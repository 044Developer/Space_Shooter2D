using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public PlayerProgressData ProgressData;

    private void OnEnable()
    {
        LoadData();
    }

    private void SubscribeEvents()
    {
        PlayerEvents.SaveProgressData += SaveData;
    }

    private void SaveData()
    {
        SaveDataManager.Save(ProgressData, ProgressData.DirectoryPath, ProgressData.FileNamePath);
    }

    private void LoadData()
    {
        ProgressData = SaveDataManager.Load<PlayerProgressData>(ProgressData.DirectoryPath, ProgressData.FileNamePath);
    }

    private void UnsubscribeEvents()
    {
        PlayerEvents.SaveProgressData -= SaveData;
    }

    private void OnDisable()
    {
        SaveData();
    }
}
