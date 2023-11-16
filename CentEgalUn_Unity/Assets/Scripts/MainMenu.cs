using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//9 min 30 https://www.youtube.com/watch?v=CE9VOZivb3I
public class MainMenu : MonoBehaviour
{
    public Animator transitions;
    public void PlayGame() {
    //Go to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //now add scenes to the queue
    }
    
    public void QuitGame() {
        Application.Quit();
    }

    public void BackToMainMenu() {
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadLevel(int sceneIndex){
        transitions.SetTrigger("start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }
}
