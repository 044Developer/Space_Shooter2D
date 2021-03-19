using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerProgressData 
{
    public const string Directory = "SaveData";
    public const string FileName = "LevelProgressData.txt";

    public string DirectoryPath { get => Directory; }
    public string FileNamePath { get => FileName; }
    public int CurrentScore { get; set; }
}
