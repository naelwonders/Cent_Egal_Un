using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//Ce script est accroché au empty --UI--
public class gameUIHandler : MonoBehaviour
{
    // Référence à l'élément MONTANT de l'UI
    private string uiTag = "Amount";
    private GameObject uiElement;
    private TMP_Text resultText;
    public TMP_Text timerText;
    
    public GameObject timesUpUI;

    public GameObject winningUI;
    // Start is called before the first frame update
    void Start()
    {
        // Find all GameObjects with the specified tag
        uiElement = GameObject.FindGameObjectWithTag(uiTag);
        resultText = uiElement.GetComponent<TMP_Text>();
        timesUpUI.SetActive(false);
        winningUI.SetActive(false);
        
    }

    public void DisplayDroppedAmount(int amount) 
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

    public void DisplayTimer(float timer, bool gameComplete)
    {
        //timesUpUI.SetActive(false);
        
        if (timer >= 0)
        {
            if (gameComplete)
            {
                winningUI.SetActive(true);
            }
        }
        // Vérifiez si le temps est écoulé
        else if (timer < 0.0f)
        {
            if(!gameComplete)
            {
                timesUpUI.SetActive(true);
            }
            timer = 0.0f;
        }
        //to round the float into an int
        timerText.text = Mathf.Floor(timer).ToString();
    }
}
