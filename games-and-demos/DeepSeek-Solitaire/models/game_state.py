"""
Game state management with validation
"""
from typing import List
from .deck import Deck, FoundationPile, TableauPile
from .card import Card

class GameState:
    def __init__(self):
        self.stock: List[Card] = []
        self.waste: List[Card] = []
        self.foundations: List[FoundationPile] = [FoundationPile() for _ in range(4)]
        self.tableau: List[TableauPile] = []
        self.score: int = 0
        self.game_won: bool = False
        self.reset()

    def reset(self):
        """Initialize new game with validation"""
        deck = Deck()
        deck.shuffle()

        # Validate deck integrity
        if len(deck.cards) != 52:
            raise RuntimeError("Invalid deck after shuffling")
        
        # Deal tableau piles
        self.tableau
