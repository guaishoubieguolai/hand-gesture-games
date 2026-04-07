import pygame
from cell import Cell

class Maze:
    def __init__(self, level):
        self.level = level
        self.maze_grid = []
        self.load_maze()
        
        self.cell_width = 1000 // len(self.maze_grid[0])
        self.cell_height = 800 // len(self.maze_grid)
    
    def load_maze(self):
        filename = f"maze{self.level}.txt"
        with open(filename, 'r') as f:
            for line in f:
                row = []
                for char in line.strip():
                    row.append(char)
                self.maze_grid.append(row)
        
    def draw(self):
        for row in range(len(self.maze_grid)):
            for col in range(len(self.maze_grid[0])):
                cell_type = self.maze_grid[row][col]
                x = col * self.cell_width
                y = row * self.cell_height
                
                cell = Cell(x, y, self.cell_width, self.cell_height, cell_type)
                cell.draw()
                
                if cell.is_start_cell:
                    self.start_cell = cell
                if cell.is_end_cell:
                    self.end_cell = cell
    
    def return_start_cell(self):
        return self.start_cell
    
    def return_end_cell(self):
        return self.end_cell
