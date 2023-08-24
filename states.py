# split the menus (start, game, end)
# je peux creer des functions update et draw, comme dans pygame zero (sauf qu'elle ne sont pas built in)

import pygame 

#event handler
for event in pygame.event.get():
    if event.type == pygame.QUIT: #quand on clique sur quit, le jeu s'arrete
        running = False
    
    #ajouter du drag and drop (onmousedown ou qqch ainsi)