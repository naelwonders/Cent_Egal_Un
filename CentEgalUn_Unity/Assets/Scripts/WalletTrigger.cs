using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class WalletTrigger : MonoBehaviour
{
    private GameObject uiElement;
    private TMP_Text resultText; // Référence à l'élément Text de l'UI
    private string uiTag = "Amount";
    private Coin coin;
    private int droppedAmount = 0;

    private Coin[] coins;

    //attention au 2D et il faut un rigid body sans gravité, car je ne veux pas qu'il tombe 
    void Start() {
        // Find all GameObjects with the specified tag
        uiElement = GameObject.FindGameObjectWithTag(uiTag);
        resultText = uiElement.GetComponent<TMP_Text>();
        coins = GameObject.FindObjectsOfType<Coin>();
    }

    void Update() {
        if (droppedAmount >= 100) {
            foreach (Coin coin in coins) {
                Debug.Log(coin);
                coin.gameObject.SetActive(false);
            }
        }  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        coin = other.gameObject.GetComponent<Coin>();
        //GAMEPLAY : seulement compter les point quand le coin is dropped in the wallet
        coin.onWallet = true;
        droppedAmount += coin.worth;
        resultText.text = "Montant : " + droppedAmount.ToString();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        coin = other.gameObject.GetComponent<Coin>();
        //GAMEPLAY : seulement compter les point quand le coin is dropped in the wallet
        coin.onWallet = false;
        droppedAmount -= coin.worth;
        resultText.text = "Montant : " + droppedAmount.ToString();
    }
}


