using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    
    public bool isDraggable = true;
    public bool isDragged = false; // is dropped
    private Vector3 originalPosition;
    private Coin coin;
    private Renderer renderer2D; //not allowed to use renderer cos it crashes another renderer


    private int layerWhenDragging;

    private WalletTrigger walletTrigger;

    //we cannot use get component for the audio because we will have many audio effects
    public AudioSource isDraggedSound;
    
    public AudioSource isDroppedSound;
    

    void Start()
    {
        originalPosition = transform.position;
        coin = GetComponent<Coin>(); //null if apple
        renderer2D = GetComponent<Renderer>();
        walletTrigger = GameObject.FindObjectOfType<WalletTrigger>();
        layerWhenDragging = 9;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDragged) 
        {
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition); //we cast to vector to loose the z axis otherwise the drag and drop does not work
            renderer2D.sortingOrder = layerWhenDragging;
        }
        else 
        {
            if (coin != null) // si c'est un coin et qu'il est sur le wallet vs pas sur le wallet
            {
                if (coin.onWallet) // on the wallet
                {
                    if (isDraggable) 
                    {
                        isDraggable = false;
                        renderer2D.sortingOrder = walletTrigger.numberOfCoinsOnWallet;
                    }
                }
                //if coin is dropped outside the wallet, bring it to its original position
                else
                {
                    transform.position = originalPosition;
                }
           
            }
            //if not a coin : nothing special happens when dropped
            else 
            {
                transform.position = originalPosition;
                renderer2D.sortingOrder = 0;
            }
        }
    }
    private void OnMouseOver()
    {
        if (isDraggable && Input.GetMouseButtonDown(0)) //int of the button pressed, here the left one
        {
            isDraggedSound.Play();
            isDragged = true;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;

        if (coin != null)
        {
            if (coin.onWallet)
            {
                isDroppedSound.Play();
            }
        }
    }
}
