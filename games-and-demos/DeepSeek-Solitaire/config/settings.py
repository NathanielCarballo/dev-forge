"""
Game configuration constants
"""
from pathlib import Path
from enum import Enum
from typing import ClassVar, Dict, Tuple

class SuitColor(Enum):
    RED = "red"
    BLACK = "black"

class GameConfig:
    # Window settings
    WINDOW_WIDTH: ClassVar[int] = 1200
    WINDOW_HEIGHT: ClassVar[int] = 800
    FPS: ClassVar[int] = 60

    # Card dimensions
    CARD_WIDTH: ClassVar[int] = 80
    CARD_HEIGHT: ClassVar[int] = 112
    CARD_SPACING: ClassVar[int] = 25
    CARD_FAN_DISTANCE: ClassVar[int] = 25

    # Path handling with validation
    @classmethod
    def assets_path(cls) -> Path:
        """Get validated assets path"""
        path = (Path(__file__).parent.parent / "resources" / "cards")
        if not path.exists():
            raise FileNotFoundError(f"Missing assets directory: {path}")
        return path
    
    # Color definitions with documentation
    COLORS: ClassVar[Dict[str, Tuple[int, int, int]]] = {
        'background': (0, 128, 0),  # Green
        'card_back': (25,25, 112),  # Midnight Blue
        'highlight': (255, 215, 0), # Gold
        'text': (255, 255, 255)     # White
    }

    # Scoring rules with type safety
    SCORING_RULES: ClassVar[Dict[str, int]] = {
        'waste_to_tableau': 5,
        'tableau_to_foundation': 10,
        'waste_to_foundation': 10,
        'redeal_stock': -100
    }

    @classmethod
    def card_size(cls) -> Tuple[int, int]:
        """Get standardized card dimensions"""
        return (cls.CARD_WIDTH, cls.CARD_HEIGHT)