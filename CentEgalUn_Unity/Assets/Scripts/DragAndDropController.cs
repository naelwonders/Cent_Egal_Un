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


    void Start()
    {
        originalPosition = transform.position;
        coin = GetComponent<Coin>();
        renderer2D = GetComponent<Renderer>();
        walletTrigger = GameObject.FindObjectOfType<WalletTrigger>();
        layerWhenDragging = 9;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDragged) {
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition); //we cast to vector to loose the z axis otherwise the drag and drop does not work
            renderer2D.sortingOrder = layerWhenDragging;
        }
        else {
            //prevent the drag and drop after dropping the coin on the wallet: BUGG HERE
            if (coin.onWallet) {
                if (isDraggable) {
                    isDraggable = false;
                    renderer2D.sortingOrder = walletTrigger.numberOfCoinsOnWallet;
                }
            }
            //if coin is dropped outside the wallet, bring it to its original position
            else {
                transform.position = originalPosition;
                renderer2D.sortingOrder = 0;
            }
        }
    }

    private void OnMouseOver()
    {
        if (isDraggable && Input.GetMouseButtonDown(0)) //int of the button pressed, here the left one
        {
            isDragged = true;
        }
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }
}
