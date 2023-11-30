using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private CoinCombinationGenerator coinGenerator;
    private GridGenerator gridGenerator;
    private Coin prefabCoin;
    private GameObject prefabToSpanwn; // mettre en privé et utiliser coin combo generator 
    private int randomCellX, randomCellY;

    private GameObject[] prefabVariants;

    public Sprite prefabAppleSprite;
    public int numberOfApples = 3;
    

    void Start()
    {
        //store all the coins prefebs in an array
        prefabVariants = Resources.LoadAll<GameObject>("Prefabs");

        //ref a l'autre script
        coinGenerator = GetComponent<CoinCombinationGenerator>();
        coinGenerator.ChooseRandomCombination();

        //pour chaque prefab, respawn dans une case libre
        gridGenerator = GetComponent<GridGenerator>();
        gridGenerator.CreateGrid();

        SpawnTheCoins();        
    }

    private void SpawnTheCoins()
    {
        for (int i = 0; i < coinGenerator.listOfCoins.Count + numberOfApples; i++)
        {
            // Check if the prefab has a script component with a "worth" field 
            foreach (GameObject prefab in prefabVariants)
            {
                if (i < coinGenerator.listOfCoins.Count) 
                {
                prefabCoin = prefab.GetComponent<Coin>();
                if (prefabCoin != null)
                {
                    // Check if the "worth" field matches the target value
                    if (prefabCoin.worth == coinGenerator.listOfCoins[i])
                    {
                        //coin is the GameObject I want to instantiate
                        prefabToSpanwn = prefab;// prendre le coin de la valeure du int a l'indice i de la liste 
                    }
                }

                }
                if (prefab.tag == "Apple")
                {
                    prefabToSpanwn = prefab;
                }
                
            }

            //Choose an inoccupied cell
            do
            {
                randomCellX = Random.Range(0, gridGenerator.gridColumns);
                randomCellY = Random.Range(0, gridGenerator.gridRows);
            }
            while (gridGenerator.grid[randomCellX, randomCellY].isOccupied);

            // Positionner la pièce d'euro au centre de la case
            Vector3 spawnPosition = gridGenerator.grid[randomCellX, randomCellY].position;
            Instantiate(prefabToSpanwn, spawnPosition, Quaternion.identity);

            // Marquer la case comme occupée
            gridGenerator.grid[randomCellX, randomCellY].isOccupied = true;

        }
    }

}
