using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    private const string TotalScorePath = "TotalScore";

    public PlayerProgressData ProgressData;

    private void OnEnable()
    {
        LoadData();
    }

    private void Start()
    {
        UpdateTotalResult();
    }

    private void UpdateTotalResult()
    {
        if (ProgressData != null)
        {
            ProgressData.TotalScore += PlayerPrefs.GetInt(TotalScorePath);
            PlayerPrefs.DeleteKey(TotalScorePath);
        }
    }

    private void SaveData()
    {
        if (ProgressData == null)
        {
            ProgressData = new PlayerProgressData();
        }

        SaveDataManager.Save(ProgressData, ProgressData.DirectoryPath, ProgressData.FileNamePath);
    }

    private void LoadData()
    {
        ProgressData = SaveDataManager.Load<PlayerProgressData>(ProgressData.DirectoryPath, ProgressData.FileNamePath);
    }

    private void OnDisable()
    {
        SaveData();
    }
}
