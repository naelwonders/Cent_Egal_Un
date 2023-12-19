using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WalletTrigger : MonoBehaviour, IDataPersistence
{
    public gameUIHandler gameUIHandler;

    private Coin coin;

    private int droppedAmount = 0;

    private float timer = 16.0f; // 60 + 1 seconde car le fadein dure une seconde
    //same thing pour le TIMER mais via l'inspecteur
    

    public bool gameComplete = false;
    private GameObject oneEuro;

    [SerializeField] private Coin[] coins;
    
    [HideInInspector] public int numberOfCoinsOnWallet = 0;

    public ParticleSystem particle;

    public AudioSource gameFinishedSound;

    public TweenUIGame tweenGame;

    public void LoadData(GameData data)
    {
        //TODOget how many times the player completed game <add game number> in the past HOW??
    }

    public void SaveData(ref GameData data)
    {
        //TODO: if game completed INCREMENT tHE NUMBER OF TIMES the player completed game <add game number> HOW??
    }
    
    //attention au 2D et il faut un rigid body sans gravité, car je ne veux pas qu'il tombe 
    void Start()
    {
        coins = GameObject.FindObjectsOfType<Coin>();
        oneEuro = GameObject.FindGameObjectWithTag("Finish");
        oneEuro.gameObject.SetActive(false);

        particle.Stop(); 

    }

    void Update()
    {
        timer -= Time.deltaTime;
        gameUIHandler.DisplayDroppedAmount(droppedAmount);
        gameUIHandler.DisplayTimer(timer, gameComplete);

        //if the tiggering component is a coin (coin is not null)
        //if the coin is dropped (not dragged)
        if (coin != null && coin.GetComponent<DragAndDropController>().isDragged == false)
        {   
            tweenGame.MontantTween();
            // Comme ca le prochain update, on ne rentre plus dans cette boucle
            coin = null;

            //IF 1 EURO HAS BEEN DROPPED (first winning condition)
            if (droppedAmount == 100)
            {
                //IF THE TIME IS NOT UP(second winning condition)
                if (timer >= 0)
                {
                    gameComplete = true;
                    foreach (Coin coin in coins)
                    {
                        coin.gameObject.SetActive(false);
                    }
                    oneEuro.gameObject.SetActive(true);
                    particle.Play();
                    gameFinishedSound.volume = 0.5f;
                    gameFinishedSound.Play();
                }
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

}



