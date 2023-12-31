using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public int worth;
    public Sprite headsImage;

    private Vector3 objectSize;
    private CircleCollider2D colision; //not allowed to use collider cos it crashes another collider
    
    [HideInInspector]
    public bool onWallet = false;


    void Start()
    {
        // Obtenir le composant Collider attaché à cet objet
        colision = GetComponent<CircleCollider2D>();
        
    }

}
