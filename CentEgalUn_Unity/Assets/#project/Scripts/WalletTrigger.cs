using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class WalletTrigger : MonoBehaviour
{
    private Coin coin;

    public string uiTag = "Amount";

    [HideInInspector]
    public int droppedAmount = 0;
    private GameObject uiElements;
    public Text resultText; // Référence à l'élément Text de l'UI

    void Start()
    {
    }

    
    //attention au 2D et il faut un rigid body sans gravité, car je ne veux pas qu'il tombe 
    private void OnTriggerStay2D(Collider2D other)
    {
    // Find all GameObjects with the specified tag
        uiElements = GameObject.FindGameObjectWithTag(uiTag);
        resultText = uiElements.GetComponent<Text>();
        // This method is called when another object enters the trigger zone.

        coin = other.gameObject.GetComponent<Coin>();
        // GameObject[] foundObjects = GameObject.FindObjectsWithTag("YourTag");
        // resultText = GameObject.FindObjectsWithTag("Amount").GetComponent<Text>();

        //BUGG: ca additionne le montant a chaque frame --> mettre de code dans un if
        droppedAmount += coin.worth;
        Debug.Log("resultText: " + resultText);
        resultText.text = "Montant : " + droppedAmount;
        
    }
}


