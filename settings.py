# settings, contants

import pygame
from random import randint

# Initialize pygame
pygame.init()

SCREEN_HEIGHT = 600
SCREEN_WIDTH = 1000

# Paths to your coin images
COIN_IMAGE_PATHS = {
    "1c": "assets/images/1c.png",
    "2c": "assets/images/2c.png",
    "5c": "assets/images/5c.png",
    "10c": "assets/images/10c.png",
    "20c": "assets/images/20c.png",
    "50c": "assets/images/50c.png",
    "1e": "assets/images/1e.png",
    "2e": "assets/images/2e.png"
}

# Load images into dictionary
coin_images = {denom: pygame.image.load(path) for denom, path in COIN_IMAGE_PATHS.items()}

class Coin:
    def __init__(self, denomination, x, y): #denomination c'est le 1c, 2c etc
        self.denomination = denomination
        self.x = x
        self.y = y
        self.image = coin_images[denomination]

    def draw(self, screen):
        screen.blit(self.image, (self.x, self.y))
    
    # Additional methods for drag-and-drop, collision detection, etc