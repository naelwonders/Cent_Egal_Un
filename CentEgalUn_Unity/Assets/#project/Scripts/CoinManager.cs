using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    
    [System.Serializable]
    public class GridCell
    {
        public Vector3 position; 
        public bool isOccupied;
    }

    private int gridColumns = 4; 
    private int gridRows = 4;

    public int numberOfCoins = 9; //by defaut 9 coins to play with
    private GridCell[,] grid;

    private GameObject coin; // mettre en privé et utiliser coin combo generator 
    private Camera mainCamera; // Reference to your main camera

    private CoinCombinationGenerator coinsList;
    private Coin prefabCoin;

    void Start()
    {
        GameObject[] prefabVariants = Resources.LoadAll<GameObject>("Prefabs");
        Debug.Log(prefabVariants.Length); //ca marche 

        //ref a l'autre script
        coinsList = GetComponent<CoinCombinationGenerator>();

        mainCamera = Camera.main;
        // Récupérer la taille de la fenetre de jeu
        float gridWidth = mainCamera.orthographicSize * mainCamera.aspect; //takes half the width of the screen
        float gridHeight = mainCamera.orthographicSize * 1.6f;

        // Initialisation de la grille
        grid = new GridCell[gridColumns, gridRows]; // tableau de cellules
        // Taille d'une cellule de la grille
        float cellSizeX = gridWidth / gridColumns; 
        float cellSizeY = gridHeight / gridRows;

        //generer la position random dans le grid et dans la cellule pour un effet semi random (double boucle)
        for (int x = 0; x < gridColumns; x++)
        {
            for (int y = 0; y < gridRows; y++)
            {
                // Randomize where the sprite spawns within the cell tout en empachant de l'overlap avec les autres potentiel sprites a coté
                float randomWithinCellX = Random.Range(cellSizeX / 2 - cellSizeX / 4, cellSizeX / 2 + cellSizeX / 4);
                float randomWithinCellY = Random.Range(cellSizeY / 2 - cellSizeY / 4, cellSizeY / 2 + cellSizeY / 4);

                grid[x, y] = new GridCell
                {
                    position = new Vector3(x * cellSizeX + randomWithinCellX - gridWidth, y * cellSizeY + randomWithinCellY - gridHeight / 2, 0.0f),
                    isOccupied = false
                };
            }
        }
        
        // Générer des indices aléatoires
        int randomCellX, randomCellY;

        for (int i = 0; i < numberOfCoins; i++)
        {
            //METTRE DES DEBUG LOG ICI POUR LES VARIANTS 
            //passer dans tous les vaiants pour voir lequel il faut spawner
            foreach (GameObject prefab in prefabVariants)
            {
                // Check if the prefab has a script component with a "worth" field
                prefabCoin = prefab.GetComponent<Coin>();
                if (prefabCoin != null)
                {
                    // Debug log to confirm that the script component is found
                    Debug.Log("Found Coin script on prefab: " + prefab.name);
                    // Check the value of i
                    Debug.Log("i value: " + i);
                    Debug.Log("List of Coins : " + coinsList); // BUGG HERE : prints nothing meaning my list of coins is not generated

                    
                    // Check if the "worth" field matches the target value
                    if (prefabCoin.worth == coinsList.listOfCoins[i])
                    {
                        //coin is the GameObject I want to instantiate
                        coin = prefab;// prendre le coin de la valeure du int a l'indice i de la liste 
                        // You found the matching prefab variant
                        Debug.Log("Found prefab variant with worth = " + coinsList.listOfCoins[i] + ": " + prefab.name);
                    }
                }
            }

            //pour chaque prefab, respawn dans une case libre
            do
            {
                randomCellX = Random.Range(0, gridColumns);
                randomCellY = Random.Range(0, gridRows);
            }
            while (grid[randomCellX, randomCellY].isOccupied);

            // Positionner la pièce d'euro au centre de la case
            Vector3 spawnPosition = grid[randomCellX, randomCellY].position;
            Instantiate(coin, spawnPosition, Quaternion.identity);

            // Marquer la case comme occupée
            grid[randomCellX, randomCellY].isOccupied = true;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
