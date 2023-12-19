using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

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

    public TweenUIGame tweenGame;

    public AudioSource timesTickingSound;

    private bool hasPlayedSound = false;

    //public AudioSource click;

    
    void Start()
    {
        // Find all GameObjects with the specified tag
        uiElement = GameObject.FindGameObjectWithTag(uiTag);
        resultText = uiElement.GetComponent<TMP_Text>();


        timesUpUI.SetActive(false);
        winningUI.SetActive(false);
        timerText.color = Color.black;
        
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
        
        if (timer >= 0)
        {
            if (gameComplete)
            {
                StartCoroutine(ShowWinningUIAfterDelay());
            }
        else if (timer <= 4)
        {
            if (!gameComplete)
            {
                StartCoroutine(TimesAlmostUp());
            }
        }
        }
        // Vérifiez si le temps est écoulé
        else if (timer < 0.0f)
        {
            if(!gameComplete)
            {
                timesUpUI.SetActive(true);
                tweenGame.TimesUpTween();
            }
            timer = 0.0f;
        }
        //to round the float into an int
        timerText.text = Mathf.Floor(timer).ToString();
    }

    // public void PlayClickingSound()
    // {
    //     click.Play();
    // }

    // Coroutine to show the winningUI after a delay
    private IEnumerator ShowWinningUIAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        winningUI.SetActive(true);
        tweenGame.WinningPanelTween();
    }

    private IEnumerator TimesAlmostUp()
    {
        if (!hasPlayedSound) // Check if the sound hasn't been played yet
        {
            timerText.color = Color.red;
            tweenGame.ClockTween();
            timesTickingSound.Play();
            hasPlayedSound = true; // Set the flag to indicate that the sound has been played
        }
        yield return null; // Yield to the next frame
    }
}
