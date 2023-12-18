using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenUI : MonoBehaviour
{
    [SerializeField] GameObject winningPanel, timesUpPanel; 
   

    public void WinningPanelTween()
    {
        LeanTween.init(10000);
        LeanTween.scale(winningPanel, new Vector3 (0.8f,1f,1f), 2f).setEase(LeanTweenType.easeOutElastic);

    }

     public void TimesUpTween()
    {
        LeanTween.init(10000);
        LeanTween.scale(timesUpPanel, new Vector3 (1f,1f,1f), 2f).setEase(LeanTweenType.easeOutElastic);
    }
    
}
