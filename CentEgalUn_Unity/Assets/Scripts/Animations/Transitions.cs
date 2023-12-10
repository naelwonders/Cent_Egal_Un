using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{
    //the animator is here to have smoothe transitions between scene changes
    public Animator transitions;
  
    public void StartTransitionCoroutine()
    {
        StartCoroutine(PlayTransitionAnimation());
    }

    IEnumerator PlayTransitionAnimation()
    {
        //play transition animation
        transitions.SetTrigger("start");
        //for a few seconds
        yield return new WaitForSeconds(1);
    }
}
