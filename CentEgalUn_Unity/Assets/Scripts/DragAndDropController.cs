using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropController : MonoBehaviour
{
    
    public bool isDraggable = true;
    public bool isDragged = false;
    private Vector3 originalPosition;
    private Coin coin;

    void Start()
    {
        originalPosition = transform.position;
        coin = GetComponent<Coin>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDragged) {
            transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition); //we cast to vector to loose the z axis otherwise the drag and drop does not work
        }
        else {
            //prevent the drag and drop after dropping the coin on the wallet: BUGG HERE
            if (coin.onWallet) {
                isDraggable = false;
            }
            //if coin is dropped outside the wallet, bring it to its original position
            else {
                transform.position = originalPosition;
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
