using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenUIMenu : MonoBehaviour
{
    [SerializeField] GameObject creditsPanel, creditMenu, envelope, playButton;
    [SerializeField] CanvasGroup transparentPanel;
   
    private Vector3 originalPosition;
    private float originalAlpha;

    void Start()
    {
        originalPosition = envelope.transform.position;
        originalAlpha = transparentPanel.alpha;
        PlayButtonTween();
    }

    public void WinningPanelTween()
    {
        LeanTween.init(10000);
        LeanTween.scale(creditsPanel, new Vector3 (1f,1f,1f), 1.5f).setEase(LeanTweenType.easeOutElastic);

    }

    public void ExitWinningPanelTween()
    {
        LeanTween.alphaCanvas(transparentPanel, 0f, 1f).setEase(LeanTweenType.easeInOutQuad);
        LeanTween.init(10000);
        LeanTween.scale(creditsPanel, new Vector3 (0f,0f,0f), 2f).setOnComplete(() => {
            SendGoodVibes();
        });
        envelope.transform.position = originalPosition;
        LeanTween.scale(envelope, new Vector3 (2.5f,2f,2f), 3f).setEase(LeanTweenType.easeOutElastic);


    }

    public void SendGoodVibes(){

        LeanTween.moveLocalX(envelope, 1000, 2.0f);
        LeanTween.alphaCanvas(transparentPanel, 0f, 2f)
        .setEase(LeanTweenType.easeInOutQuad)
        .setOnComplete(() => {
            creditMenu.SetActive(false);
        });
    }

    public void PlayButtonTween()
    {
        LeanTween.init(10000);
        LeanTween.scale(playButton, new Vector3 (1.5f,1.5f,1.5f), 2f).setEase(LeanTweenType.easeInOutQuad).setOnComplete(() => {
            FollowUpPlayButtonTween();
        });
    }

    public void FollowUpPlayButtonTween()
    {
        LeanTween.scale(playButton, new Vector3 (1f,1f,1f), 2f).setEase(LeanTweenType.linear).setOnComplete(() => {
            PlayButtonTween();
        });
    }
    
}
