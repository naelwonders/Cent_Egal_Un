using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletTrigger : MonoBehaviour, IDataPersistence
{
    private GameObject uiElement;
    private TMP_Text resultText; // Référence à l'élément Text de l'UI
    private string uiTag = "Amount";
    private Coin coin;

    private int droppedAmount = 0;

    public bool gameComplete = false;
    private GameObject oneEuro;

    [SerializeField] private Coin[] coins;
    
    [HideInInspector] public int numberOfCoinsOnWallet = 0;

    private ParticleSystem particle;

    public AudioSource gameFinishedSound;
    
    public void LoadData(GameData data)
    {
        //get how many times the player completed game <add game number> in the past HOW??
    }

    public void SaveData(ref GameData data)
    {
        //if game completed INCREMENT tHE NUMBER OF TIMES the player completed game <add game number> HOW??
    }
    
    //attention au 2D et il faut un rigid body sans gravité, car je ne veux pas qu'il tombe 
    void Start()
    {
        // Find all GameObjects with the specified tag
        uiElement = GameObject.FindGameObjectWithTag(uiTag);
        resultText = uiElement.GetComponent<TMP_Text>();
        coins = GameObject.FindObjectsOfType<Coin>();
        oneEuro = GameObject.FindGameObjectWithTag("Finish");
        oneEuro.gameObject.SetActive(false);

        particle = GetComponent<ParticleSystem>();
        particle.Stop(); 
    
    }

    void Update()
    {
        DisplayDroppedAmount(droppedAmount);
        //add a delay or deactivate them after the dissappearing rendering
        if (coin != null && coin.GetComponent<DragAndDropController>().isDragged == false)
        {
            coin = null;
            if (droppedAmount >= 100)
            {
                foreach (Coin coin in coins)
                {
                    coin.gameObject.SetActive(false);
                }
                oneEuro.gameObject.SetActive(true);

                //ADD SOME WINNING JUICINESS
                particle.Play(); 
                gameFinishedSound.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        coin = other.gameObject.GetComponent<Coin>();
        //GAMEPLAY : seulement compter les point quand le coin is dropped in the wallet
        if (coin != null) 
        {
            coin.onWallet = true;
            droppedAmount += coin.worth;
            numberOfCoinsOnWallet += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (coin != null) 
        {
            coin.onWallet = false;
            droppedAmount -= coin.worth;
            numberOfCoinsOnWallet -= 1;
        }
        coin = null;
    }

    private void DisplayDroppedAmount(int amount) 
    {
        if (amount < 10) 
        {
            resultText.text = "Montant : 0€0" + (amount).ToString();

        }
        else if (amount > 99)
        {
            resultText.text = "Montant : 1€00";
        } 
        else if (amount >= 10) 
        {
            resultText.text = "Montant : 0€" + (amount).ToString();
        }
        
    }

}


