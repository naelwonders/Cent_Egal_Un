using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//NO NEED TO KEEP: REFERENCES FROM TUTORIAL (https://www.youtube.com/watch?v=aUi9aijvpgs&t=103s)
[System.Serializable]
public class GameData
{

    public int score; //upon completion score increases
    public string playerName; 

    //constructor: initial values to start with
    public GameData()
    {
        this.score = 0;
    }
}
