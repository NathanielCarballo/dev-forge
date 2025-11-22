"""
Deck and pile models with validation
"""
import random
from typing import List, Set
from .card import Card

class Deck:
    def __init__(self):
        self.cards: List[Card] = []
        self.create_full_deck()

    def create_full_deck(self):
        """Generate 52 unique cards with validation"""
        cards = []
        unique_ids: Set[str] = set()

        for suit in Card.SUITS:
            for rank in Card.RANKS:
                card = Card(rank=rank, suit=suit)
                card_id = f"{rank}{suit}"

                if card_id in unique_ids:
                    raise ValueError(f"Duplicate card detected: {card_id}")
                
                unique_ids.add(card_id)
                cards.append(card)

        self.cards = cards

    def shuffle(self):
        """Randomize card order safely"""
        if len(self.cards) != 52:
            raise ValueError("Invalid deck size before shuffling")
        random.shuffle(self.cards)

class FoundationPile:
    def __init__(self):
        self.cards: List[Card] = []

class TableauPile:
    def __init__(self, cards: List[Card]):
        self.cards = cards
    
    def get_moveable_cards(self) -> List[Card]:
        """Get face-up cards available for moving"""
        for i, card in enumerate(self.cards):
            if card.face_up:
                return self.cards[i:]
        return []
    
    def remove_cards(self, cards: List[Card]):
        """Safely remove cards from pile"""
        self.cards = [c for c in self.cards if c not in cards]