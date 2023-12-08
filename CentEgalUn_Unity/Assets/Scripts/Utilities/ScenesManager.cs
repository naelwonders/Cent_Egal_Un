using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// attention de ne pas appelé ce script SceneManager (sans S) car ca ecrase une fonction deja existante dans unity
public class ScenesManager : MonoBehaviour
{
    //static class will be kepts between loads thanks to dontdestroyonload function
    public static ScenesManager manager;

    //the animator is here to have smoothe transitions between scene changes
    public Animator transitions;
    //singleton stat
   

    private void Start()
    {

    }


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
        //the first line is to save game data, the second is to actually quit BUT it is private for now
        //DataPersistenceManager.instance.OnApplicationQuit();
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

//FROM THE TEAM PANOPTES SLIDES: binary formatter not found
    // public void Save() 
    // {
    //     BinaryFormatter bf = new BinaryFormatter();
    //     FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
    //     GameData data = new GameData();
    //     data.health = health;
    //     data.player_name = player_name;
    //     bf.Serialize(file, data);
    //     file.Close();
    // }

    // public void Load() 
    // {
    //     if (File.Exists(Application.persistentDataPath + "/gameData.dat")) 
    //     {
    //         BinaryFormatter bf = new BinaryFormatter();
    //         FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
    //         GameData data = (GameData) bf.Deserialize(file);
    //         file.Close();
    //         health = data.health;
    //         player_name = data.player_name;
    //     }
    // }

}
