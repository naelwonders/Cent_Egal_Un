using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    List<InputEntry> playerDataList = new List<InputEntry>();
    [SerializeField] int maxEntries =  5;
    [SerializeField] string filename;

    private void Start()
    {
        LoadPlayerData();
    }
    
    private void LoadPlayerData()
    {
        playerDataList = FileHandler.ReadFromJSON<InputEntry> (filename);
    }

}
