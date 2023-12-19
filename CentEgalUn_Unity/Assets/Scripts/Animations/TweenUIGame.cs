using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TweenUIGame : MonoBehaviour
{
    [SerializeField] GameObject winningPanel, timesUpPanel, montantPanel, clockPanel; 
   

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

    public void MontantTween()
    {
        LeanTween.init(10000);
        LeanTween.scale(montantPanel, new Vector3 (1.7f,1.7f,1.7f), 0.1f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
            FollowUpMontantTween();
        });
    }

    public void FollowUpMontantTween()
    {
        LeanTween.scale(montantPanel, new Vector3 (1.2f,1.2f,1.2f), 0.2f).setEase(LeanTweenType.linear);
    }

    public void ClockTween()
    {
        LeanTween.init(10000);
        LeanTween.scale(clockPanel, new Vector3 (1.5f,1.5f,1.5f), 1f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
            FollupClockTween();
        });
    }

    public void FollupClockTween()
    {
        LeanTween.scale(clockPanel, new Vector3 (1f,1f,1f), 1f).setEase(LeanTweenType.linear);
    }
}
