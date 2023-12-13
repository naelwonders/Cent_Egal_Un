using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//https://www.youtube.com/watch?v=xWMQIozp6YE&t=30s

public class PlayerDataHandler : MonoBehaviour
{
    private string filename = "names.json";

    List<ScoreElement> playerDataList = new List<ScoreElement> ();
    [SerializeField] int maxEntries =  8;

    public delegate void OnPlayerDataListChanged (List<ScoreElement> list);
    public static event OnPlayerDataListChanged onplayerdataListChanged;


    private void Start()
    {
        LoadPlayerData();
    }
    
    private void LoadPlayerData()
    {
        playerDataList = FileHandler.ReadFromJSON<ScoreElement> (filename);

        //when extra entries are added, other ones are deleted forever (change that later)
        while (playerDataList.Count > maxEntries)
        {
            playerDataList.RemoveAt(maxEntries);
        }
        
        //this code also needs to be copy pasted where the score inscreases (player has completed the game )
        if (onplayerdataListChanged != null)
        {
            onplayerdataListChanged.Invoke(playerDataList);
        }
    }

    private void SavePlayerData()
    {
        FileHandler.SaveToJSON<ScoreElement>(playerDataList, filename);
    }

    public void UpdateCurrentScoreGame (int currentEntryIndex)
    {
        playerDataList[currentEntryIndex].playCountGame += 1;
        SavePlayerData();
        if (onplayerdataListChanged != null)
        {
            onplayerdataListChanged.Invoke(playerDataList);
        }
    }
}
