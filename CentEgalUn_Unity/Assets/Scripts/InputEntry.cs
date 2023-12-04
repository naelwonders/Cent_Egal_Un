using System;

[Serializable] public class InputEntry 
{   
    public string nameOfPlayer;
    // Start is called before the first frame update

    //CONTSTRUCTOR
    public InputEntry (string name)
    {
        nameOfPlayer = name;
    }
}
