using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerProgressData 
{
    public const string Directory = "SaveData";
    public const string FileName = "ProgressData.txt";

    public string DirectoryPath { get => Directory; }
    public string FileNamePath { get => FileName; }
    public int TotalScore { get; set; }
}
