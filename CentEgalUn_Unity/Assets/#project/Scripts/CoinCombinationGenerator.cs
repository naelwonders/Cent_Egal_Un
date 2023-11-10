using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinCombinationGenerator : MonoBehaviour
{
    [HideInInspector]
    public List<int> listOfCoins = new List<int>();
    
    public void ChooseRandomCombination()
    {
        int[] combo1 = new int[] { 50, 20, 10, 10, 5, 2, 1, 1, 1};
        int[] combo2 = new int[] { 20, 10, 10, 10, 10, 10, 10, 10, 10};
        int[] combo3 = new int[] { 20, 20, 20, 10, 10, 5, 5, 5, 5};

        List<int[]> numbersList = new List<int[]> { combo1, combo2, combo3 };

        // Générez un indice aléatoire entre 0 et la taille de la liste moins un.
        int randomIndex = Random.Range(0, numbersList.Count);

        // Accédez à l'élément aléatoire en utilisant l'indice généré.
        int[] randomCombination = numbersList[randomIndex];

        listOfCoins.Clear();

        //add the elements of my array into a list
        listOfCoins.AddRange(randomCombination);
    }

}
