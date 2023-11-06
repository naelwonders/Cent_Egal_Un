using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random; //to create an alias for random

public class CoinCombinationGenerator : MonoBehaviour
{
    
    public List<int> listOfCoins;
    
    //public int numberOfCoins; aller chercher le number of coins dans un autre script
    public List<int> GenerateRandomCoinCombination()

    {
        List<int> coins = new List<int>();
        int totalValue = 0;

        // Generate 9 random coins
        for (int i = 0; i < 9; i++)
        {
            int remainingValue = 100 - totalValue;
            
            // Ensure that the remaining value allows for more coins
            if (remainingValue >= 50 && Random.Range(0, 2) == 0)
            {
                coins.Add(50);
                totalValue += 50;
            }
            else if (remainingValue >= 20 && Random.Range(0, 2) == 0)
            {
                coins.Add(20);
                totalValue += 20;
            }
            else if (remainingValue >= 10 && Random.Range(0, 2) == 0)
            {
                coins.Add(10);
                totalValue += 10;
            }
            else if (remainingValue >= 5)
            {
                coins.Add(5);
                totalValue += 5;
            }
            else if (remainingValue >= 2)
            {
                coins.Add(2);
                totalValue += 2;
            }
            else
            {
                coins.Add(1);
                totalValue += 1;
            }
        }

        return coins;
    } 
    // Start is called before the first frame update
    void Start()
    {
        listOfCoins = GenerateRandomCoinCombination();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
