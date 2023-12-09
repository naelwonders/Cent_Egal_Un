using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// attention de ne pas appelé ce script SceneManager (sans S) car ca ecrase une fonction deja existante dans unity
public class ScenesManager : MonoBehaviour
{

    //the animator is here to have smoothe transitions between scene changes
    public Animator transitions;
   
    //play first game function and manually set them in the inscpector
    public void PlayFirstGame() 
    {
        StartCoroutine(PlayTransitionAnimation());
        //ATTENTION: remarque qu'il n'y a pas de s ici, il s'agit d'une fonction built in de unity
        SceneManager.LoadScene("FirstGameScene");
    }

    //these scenes are not yet created 
    public void PlaySecondGame() 
    {
        StartCoroutine(PlayTransitionAnimation());
        SceneManager.LoadScene("SecondGameScene");
    }
    public void PlayThirdGame() 
    {
        StartCoroutine(PlayTransitionAnimation());
        SceneManager.LoadScene("ThirdGameScene"); 
    }
    
    public void QuitGame() 
    {
        Application.Quit();
    }

    public void BackToMainMenu() 
    {
        StartCoroutine(PlayTransitionAnimation());
        SceneManager.LoadScene(0);
    }

    IEnumerator PlayTransitionAnimation()
    {
        //play transition animation
        transitions.SetTrigger("start");
        //for a few seconds
        yield return new WaitForSeconds(1);
    }

}
