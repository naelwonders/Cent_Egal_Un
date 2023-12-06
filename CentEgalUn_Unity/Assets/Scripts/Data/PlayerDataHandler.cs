using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//https://www.youtube.com/watch?v=xWMQIozp6YE&t=30s

public class PlayerDataHandler : MonoBehaviour
{
    private string filename = "names.json";

    List<InputEntry> entries = new List<InputEntry> ();

    private void UpdateAllEntries ()
    {
        entries = FileHandler.ReadFromJSON<InputEntry>(filename);
    }
    

    public void UpdateCurrentScoreGame1 (int currentEntryIndex)
    {
        entries[currentEntryIndex].playCountGame1 += 1;
        
        FileHandler.SaveToJSON<InputEntry>(entries, filename);

    }

    public void UpdateCurrentScoreGame2 (int currentEntryIndex)
    {
        entries[currentEntryIndex].playCountGame2 += 1;
        
        FileHandler.SaveToJSON<InputEntry>(entries, filename);

    }

    public void UpdateCurrentScoreGame3 (int currentEntryIndex)
    {
        entries[currentEntryIndex].playCountGame3 += 1;
        
        FileHandler.SaveToJSON<InputEntry>(entries, filename);

    }
}
