using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [System.Serializable]
    public class GridCell
    {
        public Vector3 position; //est ce que je ne mettrai pas un vector 2?
        public bool isOccupied;
    }

    public int gridColumns = 5; 
    public int gridRows = 5;

    public int numberOfCoins = 4;
    private GridCell[,] grid;

    public GameObject coin;
    private Camera mainCamera; // Reference to your main camera

    void Start()
    {
        mainCamera = Camera.main;
        // Récupérer la taille de la fenetre de jeu
        float screenWidth = mainCamera.orthographicSize * 2.0f * mainCamera.aspect;
        float screenHeight = mainCamera.orthographicSize * 2.0f;

        // Initialisation de la grille
        grid = new GridCell[gridColumns, gridRows]; // tableo de cellules
        float cellSizeX = screenWidth / gridColumns; // Taille d'une cellule de la grille
        float cellSizeY = screenHeight / gridColumns;

        for (int x = 0; x < gridColumns; x++)
        {
            for (int y = 0; y < gridRows; y++)
            {
                grid[x, y] = new GridCell
                {
                    position = new Vector3(x * cellSizeX + cellSizeX / 2 - screenWidth / 2, y * cellSizeY + cellSizeY / 2 - screenHeight / 2, 0.0f),
                    isOccupied = false
                };
            }
        }
        
        // Générer des indices aléatoires
        int randomCellX, randomCellY;

        for (int i = 0; i < numberOfCoins; i++)
        {
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
