# utilities (collision detection, asset loading functions)

import pygame
from settings import IMAGE_PATH

def load_images():
    return {
        'main_image': pygame.image.load(IMAGE_PATH)
    }