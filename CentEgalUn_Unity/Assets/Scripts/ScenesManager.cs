using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// attention de ne pas appelé ce script SceneManager (sans S) car ca ecrase une fonction deja existante dans unity
public class ScenesManager : MonoBehaviour
{

    public Animator transitions;
    //play first game function and manually set them in the inscpector

    public static ScenesManager manager;

    //singleton stat
    void Awake()
    {

        if (manager == null) 
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        } 
        else if (manager != this) 
        {
            Destroy(gameObject);
        }
    }


    public void PlayFirstGame() 
    {
        StartCoroutine(PlayTransitionAnimation());
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

    IEnumerator PlayTransitionAnimation(){
        //play transition animation
        transitions.SetTrigger("start");
        //for a few seconds
        yield return new WaitForSeconds(1);
    }


}
