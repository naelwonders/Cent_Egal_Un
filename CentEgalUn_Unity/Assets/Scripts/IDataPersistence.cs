using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NO NEED TO KEEP: REFERENCES FROM TUTORIAL (https://www.youtube.com/watch?v=aUi9aijvpgs&t=103s)
public interface IDataPersistence 
{
    void LoadData(GameData data);
    void SaveData(ref GameData data);
}
