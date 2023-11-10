using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private CoinCombinationGenerator coinGenerator;
    private GridGenerator gridGenerator;
    private Coin prefabCoin;
    private GameObject coin; // mettre en privé et utiliser coin combo generator 
    private int randomCellX, randomCellY;

    void Start()
    {
        GameObject[] prefabVariants = Resources.LoadAll<GameObject>("Prefabs");
        // mes préfabs existent et son reconnues 
        Debug.Log("Number of prefab variants : " + prefabVariants.Length);

        //ref a l'autre script
        coinGenerator = GetComponent<CoinCombinationGenerator>();
        coinGenerator.ChooseRandomCombination();

        //pour chaque prefab, respawn dans une case libre
        gridGenerator = GetComponent<GridGenerator>();
        gridGenerator.CreateGrid();

        for (int i = 0; i < coinGenerator.listOfCoins.Count; i++)
        {
            foreach (GameObject prefab in prefabVariants)
            {
                // Check if the prefab has a script component with a "worth" field
                prefabCoin = prefab.GetComponent<Coin>();
                if (prefabCoin != null)
                {
                    // Check if the "worth" field matches the target value
                    if (prefabCoin.worth == coinGenerator.listOfCoins[i])
                    {
                        //coin is the GameObject I want to instantiate
                        coin = prefab;// prendre le coin de la valeure du int a l'indice i de la liste 
                        // You found the matching prefab variant
                        Debug.Log("Found prefab variant with worth = " + coinGenerator.listOfCoins[i] + ": " + prefab.name);
                    }
                }
            }

            do
            {
                randomCellX = Random.Range(0, gridGenerator.gridColumns);
                randomCellY = Random.Range(0, gridGenerator.gridRows);
            }
            while (gridGenerator.grid[randomCellX, randomCellY].isOccupied);

            // Positionner la pièce d'euro au centre de la case
            Vector3 spawnPosition = gridGenerator.grid[randomCellX, randomCellY].position;
            Instantiate(coin, spawnPosition, Quaternion.identity);

            // Marquer la case comme occupée
            gridGenerator.grid[randomCellX, randomCellY].isOccupied = true;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
