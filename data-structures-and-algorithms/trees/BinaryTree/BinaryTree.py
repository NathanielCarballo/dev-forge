class Node:                                             #creates node class to implement binary tree
    def __init__(self,value):                           #sets the right and left pointers to null by default
        self.left = None
        self.right = None
        self.val = value



                                                        #define how to print the Postorder Traversal
def printPostorder(root):

    if root:

        printPostorder(root.left)                       #print farthest leaf node then travel up left side

        printPostorder(root.right)                      #after travel up right side from furthest leaf node

        print(root.val)                                 #finally print root

        


                                                        #defining how to print the Preorder Traversal        
def printPreorder(root):

    if root:

        print(root.val),                                #print root first

        printPreorder(root.left)                        #after travel down left side of tree first

        printPreorder(root.right)                       #then travel down right side of tree

        

                                                        #defining how to print Inorder Traversal
def printInorder(root):

    if root:

        printInorder(root.left)                         #print the left side of binary tree

        print(root.val),                                #then the root

        printInorder(root.right)                        #and then the right side of binary tree



root = Node(8)
root.right = Node(4)
root.left = Node(5)
root.right.right = Node(11)
root.right.right.left = Node(3)
root.left.left = Node(9)
root.left.right = Node(7)
root.left.right.left = Node(1)
root.left.right.right = Node(12)
root.left.right.right.left = Node(2)

print('Preorder Traversal:')
printPreorder(root)

print('\nPostorder Traversal:')
printPostorder(root)

print('\nInorder Traversal:')
printInorder(root)
