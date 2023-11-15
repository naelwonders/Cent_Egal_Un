using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class PlayerName : MonoBehaviour
{
    private InputField playerNameInput;
    private Button saveButton;

    private string csvFilePath = "Assets/DataBase/PlayerNames.csv";
    private List<string> playerNames = new List<string>();

    private void Start()
    {
        playerNameInput = GetComponentInChildren<InputField>();
        Debug.Log("PlayNameInput: " + playerNameInput);
        saveButton = GetComponentInChildren<Button>();
        // Load existing player names from the CSV file (if any)
        LoadPlayerNames();
        
        // Attach a function to the button's click event
        saveButton.onClick.AddListener(AddPlayerName);
    }

    private void LoadPlayerNames()
    {
        if (File.Exists(csvFilePath))
        {
            string[] lines = File.ReadAllLines(csvFilePath);
            playerNames.AddRange(lines);
        }
    }

    private void AddPlayerName()
    {
        //bugg here
        string playerName = playerNameInput.text;
        
        if (!string.IsNullOrEmpty(playerName))
        {
            playerNames.Add(playerName);
            
            // Update the CSV file with the new player name
            File.WriteAllLines(csvFilePath, playerNames);
            
            Debug.Log("Player name saved: " + playerName);
            
            // Optionally, clear the input field after saving
            playerNameInput.text = "";
        }
        else
        {
            Debug.Log("PlayerNameInput is not assigned.");
        }
    }
}
