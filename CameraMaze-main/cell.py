import pygame

class Cell:
    def __init__(self, x, y, width, height, cell_type):
        self.x = x
        self.y = y
        self.width = width
        self.height = height
        self.cell_type = cell_type
        
        self.is_wall = cell_type == 'W'
        self.is_path = cell_type == 'P'
        self.is_start_cell = cell_type == 'S'
        self.is_end_cell = cell_type == 'E'
        
    def draw(self):
        if self.is_wall:
            pygame.draw.rect(pygame.display.get_surface(), (0, 0, 255), (self.x, self.y, self.width, self.height))
        elif self.is_start_cell:
            pygame.draw.rect(pygame.display.get_surface(), (0, 255, 0), (self.x, self.y, self.width, self.height))
        elif self.is_end_cell:
            pygame.draw.rect(pygame.display.get_surface(), (255, 0, 255), (self.x, self.y, self.width, self.height))
        else:
            pygame.draw.rect(pygame.display.get_surface(), (255, 255, 255), (self.x, self.y, self.width, self.height))
