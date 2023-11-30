using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NO NEED TO KEEP: REFERENCES FROM TUTORIAL (https://www.youtube.com/watch?v=aUi9aijvpgs&t=103s)
//this script hold the current state of our game data (from the video, try to do a similar thing in your scenemanager)
public class DataPersistenceManager : MonoBehaviour
{
    private GameData gameData;
    //this is a singleton: we can access it publically but only set it privately within this class
    public static DataPersistenceManager instance {get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one DataPersistenceManager in the scene.");
        }
        instance = this;
    }

    //this is in my scene manager in the start method
    // private void Start()
    // {
    //     LoadGame();
    // }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //to do: load save data
        // if no data load initialization of news game
        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing data to defaults.");
            NewGame();
        }
        // push to all other scripts
    }

    public void SaveGame()
    {
        // pass data onto other scripts so they can update them
        // save data to a file via the file handler
        
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
