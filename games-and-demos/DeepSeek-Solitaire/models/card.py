"""
Card model with validation
"""
from dataclasses import dataclass
from config.settings import SuitColor, GameConfig
from typing import ClassVar, List

@dataclass
class Card:
    RANKS: ClassVar[List[str]] = [
        'A', '2', '3', '4', '5', '6', '7',
        '8', '9', '10', 'J', 'Q', 'K'
    ]
    SUITS: ClassVar[List[str]] = ['♠', '♥', '♦', '♣']

    rank: str
    suit: str
    face_up: bool = False
    x: float = 0.0
    y: float = 0.0
    angle: float = 0.0

    def __post_init__(self):
        """Validate card properties"""
        if self.rank not in self.RANKS:
            raise ValueError(f"Invalid rank: {self.rank}")
        if self.suit not in self.SUITS:
            raise ValueError(f"Invalid suit: {self.suit}")
    
    @property
    def color(self) -> SuitColor:
        """Get card color based on suit"""
        return SuitColor.RED if self.suit in ('♥', '♦') else SuitColor.BLACK
    
    @property
    def rank_index(self) -> int:
        """Get numerical position in rank sequence"""
        return self.RANKS.index(self.rank)