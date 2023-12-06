using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


//https://www.youtube.com/watch?v=KZft1p8t2lQ 
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
        entries.Add(new InputEntry (nameInput.text, 0, 0, 0)); //0 because the times played is zero when you sign up to the game 
        nameInput.text = "";
        
        FileHandler.SaveToJSON<InputEntry>(entries, filename);

    }
}