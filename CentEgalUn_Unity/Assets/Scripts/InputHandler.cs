using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//https://www.youtube.com/watch?v=KZft1p8t2lQ je suis sur cette video pour faire l'input du name

//j'arrive pas a coller l'input field dans la champs publique d'un script (je sais pas pourquoi)
public class InputHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private string filename;

    List<InputEntry> entries = new List<InputEntry> ();

    private void Start ()
    {
        entries = FileHandler.ReadFromJSON<InputEntry>(filename);
    }

    public void AddNameToList ()
    {
        entries.Add(new InputEntry (nameInput.text));
        nameInput.text = "";
        
        FileHandler.SaveToJSON<InputEntry>(entries, filename);

    }

    public void DisplayAllEntries()
    {
        foreach (InputEntry entry in entries)
        {
            Debug.Log(entry.nameOfPlayer.ToString());
        }
    }
}
