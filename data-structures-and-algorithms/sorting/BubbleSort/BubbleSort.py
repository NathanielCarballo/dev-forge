from time import time

#sets start time for calculation the execution time of sort
start_transaction = time()

#defines the bubblesort algorithm
def bubbleSort(array):

    #sets the default swapped variable to true to prep loop
    swapped = True

    #initiates the sorting loop
    while swapped:

        #sets swapped to false so algorithm breaks if no swap occures
        swapped = False

        #for loop examines the elements in the array and determines a condition
        for i in range(len(array)-1):

            #if this element is greater than the next element swap the values
            if array[i] > array[i+1]:

                array[i], array[i+1], = array[i+1], array[i]

                #print out the values that were swapped with the value they were swapped with
                print("Swapped: {} with {}".format(array[i], array[i+1]))

                #sets swapped back to true
                swapped = True

    #returns the swapped array
    return array

def insertionSort(array):
    #for loop examines elements in the array
    for index in range (1, len(array)):

        #sets current to array index
        current = array[index]
        #sets position to index
        position = index

        #while we have an element larger in array the one we are trying to insert,
        #move that element to the right.
        while position > 0 and array[position-1] > current:
            print("Swapped {} for {}".format(array[position], array[position-1]))
            array[position] = array[position-1]
            position -= 1
        #either reached the beginning or found an element smaller than the one trying to insert,
        #then insert element into current index position
        array[position] = current

    return array


array = [100, 45, 33, 55, 356, 11, 1000, 999, 987]

print('Unsorted Array:',array)

#prints the swapped array with bubble sort and the execution time.
print('\nBubble Sorted Array:\n',bubbleSort(array), "\nExecution time: ", time()-start_transaction)

#clears the bubblesorted array
array.clear()


array = [100, 45, 33, 55, 356, 11, 1000, 999, 987]

print('Unsorted Array:\n',array)
#prints the swapped insertion sort array and the execution time.
print('\nInsertion Sorted Array:',insertionSort(array), "\nExecution time: ", time()-start_transaction)


                
