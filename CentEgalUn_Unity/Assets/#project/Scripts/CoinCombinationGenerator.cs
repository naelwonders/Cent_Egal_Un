using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; //to create an alias for random
using System.Linq;

public class CoinCombinationGenerator : MonoBehaviour
{
    public List<int> listOfCoins;
    
     public List<int> GenerateRandomDistinctCoinCombination()
    {
        int[] coinDenominations = { 1, 2, 5, 10, 20, 50, 100 };
        List<int> combination = new List<int>();
        System.Random random = new System.Random();

        // Randomly select 9 distinct coin denominations
        List<int> availableDenominations = new List<int>(coinDenominations);

        for (int i = 0; i < 8; i++)
        {
            if (availableDenominations.Count == 0)
            {
                break; // If no more distinct denominations available, exit the loop
            }

            int index = random.Next(0, availableDenominations.Count);
            int selectedDenomination = availableDenominations[index];
            combination.Add(selectedDenomination);
        }

        // Ensure that the combination sums up to 1 euro (100 cents)
        int sum = combination.Sum();
        int remainingValue = 100 - sum;
        
        if (availableDenominations.Contains(remainingValue))
        {
            combination.Add(remainingValue);
        }
        else
        {
            // If the remaining value is not a valid denomination, randomly select one
            int index = random.Next(0, availableDenominations.Count);
            int selectedDenomination = availableDenominations[index];
            combination.Add(selectedDenomination);
        }

        return combination;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        listOfCoins = GenerateRandomDistinctCoinCombination();
        Debug.Log(listOfCoins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
