using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//https://www.youtube.com/watch?v=KZft1p8t2lQ je suis sur cette video pour faire l'input du name

//j'arrive pas a coller l'input field dans la champs publique d'un script (je sais pas pourquoi)
public class InputHandler : MonoBehaviour
{
    [SerializeField] private InputField nameInput;
    [SerializeField] private string filename;

    List<InputEntry> entries = new List<InputEntry> ();

    public void AddNameToList ()
    {
        //BUGG nullreferenceexception HERE 
        entries.Add(new InputEntry (nameInput.text));
        nameInput.text = "";
        
        FileHandler.SaveToJSON<InputEntry>(entries, filename);
    }
}
