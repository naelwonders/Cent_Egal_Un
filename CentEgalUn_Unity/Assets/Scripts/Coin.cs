using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public int worth;
    public Sprite headsImage;

    private Vector3 objectSize;
    private CircleCollider2D collider;
    
    [HideInInspector]
    public bool onWallet = false;


    void Start()
    {
        // Obtenir le composant Collider attaché à cet objet
        collider = GetComponent<CircleCollider2D>();
        
    }

}
