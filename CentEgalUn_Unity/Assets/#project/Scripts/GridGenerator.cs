using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [HideInInspector]
    public class GridCell
    {
        public Vector3 position; 
        public bool isOccupied;
    }
    [HideInInspector]
    public GridCell[,] grid;
    public int gridColumns = 4; 
    public int gridRows = 4;

    private Camera mainCamera; // Reference to your main camera
    // Start is called before the first frame update

    public void CreateGrid() {
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
    }

}
