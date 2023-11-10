using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Coin : MonoBehaviour
{
    public int worth;
    public Sprite image;
    private Vector3 objectSize;
    private CircleCollider2D collider;

    void Start()
    {
        // Obtenir le composant Collider attaché à cet objet
        collider = GetComponent<CircleCollider2D>();
        // Obtenir la taille du GameObject (par exemple, échelle transformée en taille)
        // objectSize = transform.localScale;
        // // Définissir la taille du Collider pour correspondre à la taille du GameObject
        // collider.size = objectSize;
    
    }

}
