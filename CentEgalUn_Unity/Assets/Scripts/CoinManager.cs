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

    public int gridSizeX = 5;
    public int gridSizeY = 5;

    public int numberOfCoins = 4;
    private GridCell[,] grid;

    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        // Récupérer la taille de la fenetre de jeu
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // Initialisation de la grille
        grid = new GridCell[gridSizeX, gridSizeY];
        float cellSize = screenWidth / gridSizeX; // Taille d'une cellule de la grille

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                grid[x, y] = new GridCell
                {
                    position = new Vector3(x * cellSize + cellSize / 2, y * cellSize + cellSize / 2 , 0.0f),
                    isOccupied = false

                };
            }
        }
        
        spawnCoin();
        
    }



    public void spawnCoin()
    {
        // Générer des indices aléatoires
        int randomCell, randomCellY;

        do
        {
            randomCell = Random.Range(0, gridSizeX);
            randomCellY = Random.Range(0, gridSizeY);
        }
        while (grid[randomCell, randomCellY].isOccupied);

        // Positionner la pièce d'euro au centre de la case
        Vector3 spawnPosition = grid[randomCell, randomCellY].position;
        Instantiate(coin, spawnPosition, Quaternion.identity);

        // Marquer la case comme occupée
        grid[randomCell, randomCellY].isOccupied = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
