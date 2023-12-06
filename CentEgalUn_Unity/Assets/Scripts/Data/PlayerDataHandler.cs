using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//https://www.youtube.com/watch?v=xWMQIozp6YE&t=30s

public class PlayerDataHandler : MonoBehaviour
{
    private string filename = "names.json";

    List<InputEntry> playerDataList = new List<InputEntry> ();
    [SerializeField] int maxEntries =  5;

    public delegate void OnPlayerDataListChanged (List<InputEntry> list);
    public static event OnPlayerDataListChanged onplayerdataListChanged;

    private void Start()
    {
        LoadPlayerData();
    }
    
    private void LoadPlayerData()
    {
        playerDataList = FileHandler.ReadFromJSON<InputEntry> (filename);

        //when extra entries are added, other ones are deleted forever (change that later)
        while (playerDataList.Count > maxEntries)
        {
            playerDataList.RemoveAt(maxEntries);
        }

        if (onplayerdataListChanged != null)
        {
            onplayerdataListChanged.Invoke(playerDataList);
        }
    }

    private void SavePlayerData()
    {
        FileHandler.SaveToJSON<InputEntry>(playerDataList, filename);
    }

    // public void UpdateCurrentScoreGame1 (int currentEntryIndex)
    // {
    //     playerDataList[currentEntryIndex].playCountGame1 += 1;
    //     SavePlayerData();

    // }

    // public void UpdateCurrentScoreGame2 (int currentEntryIndex)
    // {
    //     playerDataList[currentEntryIndex].playCountGame2 += 1;
    //     SavePlayerData();

    // }

    // public void UpdateCurrentScoreGame3 (int currentEntryIndex)
    // {
    //     playerDataList[currentEntryIndex].playCountGame3 += 1;
    //     SavePlayerData();

    // }
}
