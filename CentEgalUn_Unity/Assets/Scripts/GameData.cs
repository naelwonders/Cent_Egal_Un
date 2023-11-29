using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//KEEP SCRIPT
[System.Serializable]
public class GameData
{

    public int score; //upon completion score increases
    public string playerName; 

    public GameData()
    {
        this.score = 0;
    }
}
