using System;

[Serializable] public class ScoreElement 
{   
    public string nameOfPlayer;
    public int playCountGame;

    //CONTSTRUCTOR
    public ScoreElement (string name, int playCount)
    {
        nameOfPlayer = name;
        playCountGame = playCount;
    }
}
