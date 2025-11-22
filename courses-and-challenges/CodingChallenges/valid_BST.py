#This code when given the root of a binary tree, will determine if the tree is a valid BST.
#A valid BST is defined as a tree where for each node, all values in the left subtree are less than the node's value and all values in the right subtree are greater than the node's value.

def is_valid_BST(node, min_value=float('-inf'), max_value=float('inf')):
    # Base case: if the node is None, return True
    if not node:
        return True
    
    # Check if the current node's value is within the valid range
    if not (min_value < node.val < max_value):
        return False
    
    # Recursively check the left and right subtrees with updated ranges
    return (is_valid_BST(node.left, min_value, node.val) and
            is_valid_BST(node.right, node.val, max_value))

# Example usage:
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

# Constructing a valid BST
root = TreeNode(2)
root.left = TreeNode(1)
root.right = TreeNode(3)

# Check if the constructed tree is a valid BST
print(is_valid_BST(root))  # Output: True

# Constructing an invalid BST
invalid_root = TreeNode(5)
invalid_root.left = TreeNode(1)
invalid_root.right = TreeNode(4)
invalid_root.right.left = TreeNode(3)
invalid_root.right.right = TreeNode(6)

# Check if the constructed tree is a valid BST
print(is_valid_BST(invalid_root))  # Output: False


