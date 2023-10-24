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
    private GridCell[,] grid;

    public GameObject coin;
    // Start is called before the first frame update
    void Start()
    {
        // Initialisation de la grille
        grid = new GridCell[gridSizeX, gridSizeY];
        float cellSize = 1.0f; // Taille d'une cellule de la grille

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                grid[x, y] = new GridCell
                {
                    position = new Vector3(x * cellSize + cellSize / 2, 0.0f, y * cellSize + cellSize / 2),
                    isOccupied = false
                };
            }
        }
        
    }

    public void RespawnCoin()
    {
        // Générer des indices aléatoires
        int randomX, randomY;

        do
        {
            randomX = Random.Range(0, gridSizeX);
            randomY = Random.Range(0, gridSizeY);
        }
        while (grid[randomX, randomY].isOccupied);

        // Positionner la pièce d'euro au centre de la case
        Vector3 spawnPosition = grid[randomX, randomY].position;
        Instantiate(coin, spawnPosition, Quaternion.identity);

        // Marquer la case comme occupée
        grid[randomX, randomY].isOccupied = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
