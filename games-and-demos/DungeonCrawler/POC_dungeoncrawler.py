import pygame
import random
from pygame.locals import *

# Game Constants
WIDTH = 800
HEIGHT = 600
TILE_SIZE = 32
GRID_WIDTH = WIDTH // TILE_SIZE
GRID_HEIGHT = HEIGHT // TILE_SIZE
FPS = 30

class Room:
    def __init__(self, x, y, w, h):
        self.x1 = x
        self.y1 = y
        self.x2 = x + w
        self.y2 = y + h

    def center(self):
        return ((self.x1 + self.x2) // 2, (self.y1 + self.y2) // 2)

    def intersects(self, other):
        return (self.x1 <= other.x2 and self.x2 >= other.x1 and
                self.y1 <= other.y2 and self.y2 >= other.y1)

class Dungeon:
    def __init__(self):
        self.grid = [[1 for _ in range(GRID_WIDTH)] for _ in range(GRID_HEIGHT)]
        self.rooms = []
        self.generate()
        
    def generate(self):
        # Generate rooms
        num_rooms = 15
        for _ in range(num_rooms):
            w = random.randint(4, 8)
            h = random.randint(4, 6)
            x = random.randint(1, GRID_WIDTH - w - 1)
            y = random.randint(1, GRID_HEIGHT - h - 1)
            new_room = Room(x, y, w, h)
            
            if not any(new_room.intersects(other) for other in self.rooms):
                self.rooms.append(new_room)
                self.create_room(new_room)
        
        # Connect rooms with corridors
        for i in range(1, len(self.rooms)):
            prev = self.rooms[i-1].center()
            curr = self.rooms[i].center()
            
            if random.random() > 0.5:  # Horizontal then vertical
                self.create_h_tunnel(prev[0], curr[0], prev[1])
                self.create_v_tunnel(prev[1], curr[1], curr[0])
            else:  # Vertical then horizontal
                self.create_v_tunnel(prev[1], curr[1], prev[0])
                self.create_h_tunnel(prev[0], curr[0], curr[1])

    def create_room(self, room):
        for x in range(room.x1, room.x2):
            for y in range(room.y1, room.y2):
                self.grid[y][x] = 0

    def create_h_tunnel(self, x1, x2, y):
        for x in range(min(x1, x2), max(x1, x2) + 1):
            self.grid[y][x] = 0

    def create_v_tunnel(self, y1, y2, x):
        for y in range(min(y1, y2), max(y1, y2) + 1):
            self.grid[y][x] = 0

class Player(pygame.sprite.Sprite):
    def __init__(self, x, y):
        super().__init__()
        self.image = pygame.Surface((TILE_SIZE, TILE_SIZE))
        self.image.fill((0, 255, 0))
        self.rect = self.image.get_rect()
        self.x = x
        self.y = y
        self.health = 100
        self.score = 0
        self.update_rect()

    def update_rect(self):
        self.rect.x = self.x * TILE_SIZE
        self.rect.y = self.y * TILE_SIZE

    def move(self, dx, dy, dungeon):
        new_x = self.x + dx
        new_y = self.y + dy
        if 0 <= new_x < GRID_WIDTH and 0 <= new_y < GRID_HEIGHT:
            if dungeon.grid[new_y][new_x] == 0:
                self.x = new_x
                self.y = new_y
                self.update_rect()

    def attack(self, enemies):
        for enemy in enemies:
            if abs(enemy.x - self.x) <= 1 and abs(enemy.y - self.y) <= 1:
                enemy.health -= 20
                if enemy.health <= 0:
                    enemy.kill()
                    self.score += 10

class Enemy(pygame.sprite.Sprite):
    def __init__(self, x, y):
        super().__init__()
        self.image = pygame.Surface((TILE_SIZE, TILE_SIZE))
        self.image.fill((255, 0, 0))
        self.rect = self.image.get_rect()
        self.x = x
        self.y = y
        self.health = 50
        self.update_rect()

    def update_rect(self):
        self.rect.x = self.x * TILE_SIZE
        self.rect.y = self.y * TILE_SIZE

    def update(self, player, dungeon):
        dx = 0
        dy = 0
        if random.random() < 0.5:
            if player.x < self.x and dungeon.grid[self.y][self.x-1] == 0:
                dx = -1
            elif player.x > self.x and dungeon.grid[self.y][self.x+1] == 0:
                dx = 1
        else:
            if player.y < self.y and dungeon.grid[self.y-1][self.x] == 0:
                dy = -1
            elif player.y > self.y and dungeon.grid[self.y+1][self.x] == 0:
                dy = 1

        new_x = self.x + dx
        new_y = self.y + dy
        if 0 <= new_x < GRID_WIDTH and 0 <= new_y < GRID_HEIGHT:
            if dungeon.grid[new_y][new_x] == 0:
                self.x = new_x
                self.y = new_y
                self.update_rect()

        if self.rect.colliderect(player.rect):
            player.health -= 5

class Item(pygame.sprite.Sprite):
    def __init__(self, x, y, item_type):
        super().__init__()
        self.type = item_type
        color = (0, 0, 255) if item_type == "health" else (255, 255, 0)
        self.image = pygame.Surface((TILE_SIZE, TILE_SIZE))
        self.image.fill(color)
        self.rect = self.image.get_rect()
        self.rect.topleft = (x * TILE_SIZE, y * TILE_SIZE)
        self.x = x
        self.y = y

def game_intro(screen):
    font = pygame.font.Font(None, 48)
    text = [
        "The Lost Artifact of Zorath",
        "",
        "Legends speak of a powerful artifact hidden deep",
        "within these ancient ruins. Many have tried,",
        "none have succeeded. Will you be the one to",
        "claim this ancient power?",
        "",
        "Press any key to begin your quest..."
    ]
    
    screen.fill((0, 0, 0))
    y = HEIGHT // 4
    for line in text:
        text_surf = font.render(line, True, (255, 255, 255))
        text_rect = text_surf.get_rect(center=(WIDTH//2, y))
        screen.blit(text_surf, text_rect)
        y += 40
    
    pygame.display.flip()
    waiting = True
    while waiting:
        for event in pygame.event.get():
            if event.type == QUIT:
                pygame.quit()
                quit()
            if event.type == KEYDOWN:
                waiting = False

def main():
    pygame.init()
    screen = pygame.display.set_mode((WIDTH, HEIGHT))
    pygame.display.set_caption("Dungeon Crawler")
    clock = pygame.time.Clock()
    
    game_intro(screen)
    
    dungeon = Dungeon()
    all_sprites = pygame.sprite.Group()
    enemies = pygame.sprite.Group()
    items = pygame.sprite.Group()

    # Spawn player in first room
    start_room = dungeon.rooms[0]
    player = Player(*start_room.center())
    all_sprites.add(player)

    # Spawn artifact in last room
    exit_room = dungeon.rooms[-1]
    artifact = Item(*exit_room.center(), "artifact")
    items.add(artifact)
    all_sprites.add(artifact)

    # Populate enemies and items
    for room in dungeon.rooms[1:-1]:
        # Enemies
        for _ in range(random.randint(1, 3)):
            x = random.randint(room.x1, room.x2-1)
            y = random.randint(room.y1, room.y2-1)
            enemy = Enemy(x, y)
            enemies.add(enemy)
            all_sprites.add(enemy)
        
        # Health potions
        if random.random() < 0.4:
            x = random.randint(room.x1, room.x2-1)
            y = random.randint(room.y1, room.y2-1)
            item = Item(x, y, "health")
            items.add(item)
            all_sprites.add(item)

    running = True
    game_over = False
    victory = False

    while running:
        for event in pygame.event.get():
            if event.type == QUIT:
                running = False
            if event.type == KEYDOWN:
                if game_over or victory:
                    if event.key == K_r:
                        main()
                    elif event.key == K_q:
                        running = False
                else:
                    if event.key == K_UP:
                        player.move(0, -1, dungeon)
                    elif event.key == K_DOWN:
                        player.move(0, 1, dungeon)
                    elif event.key == K_LEFT:
                        player.move(-1, 0, dungeon)
                    elif event.key == K_RIGHT:
                        player.move(1, 0, dungeon)
                    elif event.key == K_SPACE:
                        player.attack(enemies)

        if not game_over and not victory:
            # Update enemies
            for enemy in enemies:
                enemy.update(player, dungeon)

            # Check item collisions
            for item in items:
                if player.rect.colliderect(item.rect):
                    if item.type == "health":
                        player.health = min(100, player.health + 30)
                        item.kill()
                    elif item.type == "artifact":
                        victory = True

            # Check game over
            if player.health <= 0:
                game_over = True

        # Drawing
        screen.fill((0, 0, 0))
        
        # Draw dungeon
        for y in range(GRID_HEIGHT):
            for x in range(GRID_WIDTH):
                if dungeon.grid[y][x] == 1:
                    pygame.draw.rect(screen, (70, 70, 70), 
                                   (x*TILE_SIZE, y*TILE_SIZE, TILE_SIZE, TILE_SIZE))
                else:
                    pygame.draw.rect(screen, (30, 30, 30), 
                                   (x*TILE_SIZE, y*TILE_SIZE, TILE_SIZE, TILE_SIZE))
        
        all_sprites.draw(screen)

        # UI
        font = pygame.font.Font(None, 36)
        health_text = font.render(f"Health: {player.health}", True, (255, 255, 255))
        screen.blit(health_text, (10, 10))
        score_text = font.render(f"Score: {player.score}", True, (255, 255, 255))
        screen.blit(score_text, (10, 50))

        if game_over:
            text = font.render("Game Over! Press R to restart or Q to quit", True, (255, 0, 0))
            screen.blit(text, (WIDTH//2 - text.get_width()//2, HEIGHT//2))
        elif victory:
            text = font.render("Victory! You found the Artifact! Press R to play again", True, (0, 255, 0))
            screen.blit(text, (WIDTH//2 - text.get_width()//2, HEIGHT//2))

        pygame.display.flip()
        clock.tick(FPS)

    pygame.quit()

if __name__ == "__main__":
    main()