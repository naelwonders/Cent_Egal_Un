#COUPER LE MAMOUTHE:
#loader et placer des pieces sur le coté gauche de l'ecran de jeu
# rendre la position aléatoire au saint de la grille (pour un effet de pieces tombées)
#faire le drag and drop


import pygame
from settings import SCREEN_HEIGHT, SCREEN_WIDTH
import states # il faut aller construire les scenes start, game, end

# MAIN = ENTRY POINT into the game
#il y a plusieurs raison pour utiliser une fonction main, une d'entre elle est d'éviter les variables globales
def main():
    pygame.init()

    SCREEN = pygame.display.set_mode((SCREEN_WIDTH, SCREEN_HEIGHT))
    clock = pygame.time.Clock()

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