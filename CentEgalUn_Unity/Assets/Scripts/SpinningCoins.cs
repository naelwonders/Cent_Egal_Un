using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningCoins : MonoBehaviour
{
    public Sprite tailColor;

    private Coin heads;
    public Animator animator;

    private float randomTimeInterval;
    

    void Start()
    {
        heads = GetComponent<Coin>();
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimationAtRandomIntervals());
    }

    public void Switch() {

        GetComponent<SpriteRenderer>().sprite = tailColor;

    }

    public void UnSwitch() {
        GetComponent<SpriteRenderer>().sprite = heads.headsImage;
    }


    // // Start the coroutine
    // public void StartCoroutineA()
    // {
    //     myCoroutine = StartCoroutine(PlayAnimationAtRandomIntervals());
    // }

    // // Stop the coroutine
    // public void StopCoroutineA()
    // {
    //     if (myCoroutine != null)
    //     {
    //         StopCoroutine(myCoroutine);
    //         myCoroutine = null;
    //     }
    // }

    public IEnumerator PlayAnimationAtRandomIntervals()
    {
        while(true) {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
                randomTimeInterval = Random.Range(0.2f, 15f);
                yield return new WaitForSeconds(randomTimeInterval);
                animator.SetTrigger("turn");
            }
            yield return null;
        }
    }
}
