#COUPER LE MAMOUTHE:
#loader et placer des pieces sur le coté gauche de l'ecran de jeu, dans une grille
# rendre la position aléatoire au saint de la grille (pour un effet de pieces tombées)
#trouver un cochon le placer du coté droite
#faire le drag and drop dans le cochon
#faire 

import pygame
pygame.init()

SCREEN = pygame.display.set_mode((1000,600))

sprite_image = pygame.image.load("images/un_centime.png")

running = True
while running :
    for event in pygame.event.get():
        if event.type == pygame.QUIT: #quand on clique sur quit, le jeu s'arrete
            running = False
        
        #mettre le jeu ici
    SCREEN.fill((255,255,255))
            
    pygame.display.update()
pygame.quit()