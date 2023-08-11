# split the menus (start, game, end)
# je peux creer des functions update et draw, comme dans pygame zero (sauf qu'elle ne sont pas built in)

for event in pygame.event.get():
    if event.type == pygame.QUIT: #quand on clique sur quit, le jeu s'arrete
        running = False