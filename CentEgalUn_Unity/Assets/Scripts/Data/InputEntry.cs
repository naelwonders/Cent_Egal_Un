using System;

[Serializable] public class InputEntry 
{   
    public string nameOfPlayer;
    public int playCountGame1;
    public int playCountGame2;
    public int playCountGame3;

    // Start is called before the first frame update

    //CONTSTRUCTOR
    public InputEntry (string name, int playCount1, int playCount2, int playCount3)
    {
        nameOfPlayer = name;
        playCountGame1 = playCount1;
        playCountGame2 = playCount2;
        playCountGame3 = playCount3;
    }
}
