using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameUIHandler : MonoBehaviour
{
    public TMP_Text timerText;
    private float timer = 60.0f; // Temps initial en secondes (60 secondes = 1 minute)

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = timer.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    
        // Vérifiez si le temps est écoulé
        if (timer <= 0.0f)
        {
            // Le temps est écoulé, vous pouvez mettre ici le code que vous souhaitez exécuter lorsque le temps est écoulé
            Debug.Log("Temps écoulé !");
            timer = 0.0f; // Optionnel : assurez-vous que le timer ne devienne pas négatif
        }
    }
}
