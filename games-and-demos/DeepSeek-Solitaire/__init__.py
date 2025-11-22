"""
Solitaire package root initialization
"""
__version__ = "1.0.0"
__all__ = ['main']

# Lazy import to prevent circular dependencies
try:
    from .main import main
except ImportError as err:
    raise RuntimeError("Failed to import main module") from err