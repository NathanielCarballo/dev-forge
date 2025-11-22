import random
import logging
from typing import List

logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

def binary_search(numberlist: List[int], l: int, r: int, searchedvalue: int, debug: bool = False) -> int:
    """
    Performs a binary search on a sorted list of integers.

    Args:
        numberlist (List[int]): The sorted list of integers to search.
        l (int): Left index (start of the current search window).
        r (int): Right index (end of the current search window).
        searchedvalue (value): The value to search for.
        debug (bool): If True, logs each step of the search.

    Returns:
        int: The index of the searchedvalue in numberlist if found, else -1.
    """
    while l <= r:
        mid = l + (r - l) // 2

        if debug:
            logger.info(f"Searching in range[{l}, {r}], mid={mid}, value={numberlist[mid]}")
            
        if numberlist[mid] == searchedvalue:
            return mid
        
        elif numberlist[mid] < searchedvalue:
            l = mid +1
        else:
            r = mid - 1
            
    return -1

numberlist = sorted(random.sample(range(0, 1000), 1000))
searchedvalue = random.randint(0, 999)

result = binary_search(numberlist, 0, len(numberlist)-1,searchedvalue, debug=True)

if result != -1:
    print('Element found!')

else:
    print('Not found')