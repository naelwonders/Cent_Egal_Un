#COUPER LE MAMOUTHE:
#start with a clean and organised architecture
#loader et placer des pieces sur le coté gauche de l'ecran de jeu, dans une grille
# rendre la position aléatoire au saint de la grille (pour un effet de pieces tombées)
#faire le cadrage visuel avant de mettre les pieces (pour faciliter le travail)
#trouver un cochon le placer du coté droite
#faire le drag and drop dans le cochon
#faire 
# MAIN = ENTRY POINT into the game

import pygame
from settings import SCREEN_HEIGHT, SCREEN_WIDTH
import states # il faut aller construire les scenes start, game, end (pas de pause car pas de mouvement)
#il y a plusieurs raison pour utiliser une fonction main, une d'entre elle est d'éviter les variables globales
def main():
    pygame.init()

    SCREEN = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))
    clock = pygame.time.Clock()
    #current_scene = GameScene(SCREEN)

    #this should go in the settings file (?)
    images_folder_path = "images"
    sprite_image = pygame.image.load("images/un_centime.png")

    running = True
    while running :
        
            
            #mettre le jeu ici
        SCREEN.fill((255,255,255))
                
        pygame.display.update()
        clock.tick(60) #this method limits the game to 60 FPS (the game with run at the same speed regardless computer power)
        pygame.display.flip() #pygame built in function that turns to the next frame (like changing the page of a book)
    pygame.quit()

if __name__ == "__main__":
    main()