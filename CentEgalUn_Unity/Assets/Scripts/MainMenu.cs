using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
    //Go to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //now add scenes to the queue
 
    }
    
    public void QuitGame() {
        Application.Quit();
    }
}
