using System;

[Serializable] public class InputEntry 
{   
    public string nameOfPlayer;
    public int playCountGame;

    // Start is called before the first frame update

    //CONTSTRUCTOR
    public InputEntry (string name, int playCount)
    {
        nameOfPlayer = name;
        playCountGame = playCount;
    }
}
