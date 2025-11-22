import random

def quicksort(numberlist):

    #defining 3 arrays for the quicksort

    less = []
    equal = []
    greater = []

    #if the length of the array is greater than 1 then a sort is preformed
    if len(numberlist) > 1:

        
        #selecting a pivot point, doesnt have to be the first element.
        pivot = numberlist[0]

        #loops through the elements in the array and sorts accordingly
        for x in numberlist:
            if x < pivot:
                less.append(x)
            if x == pivot:
                equal.append(x)
            if x > pivot:
                greater.append(x)
        #continues to call the quicksort until the list is sorted completely
        return quicksort(less)+equal+quicksort(greater)

    else:

        return numberlist
#determines what to return based on whether element if found
#binary search only works on sorted list
def binarySearch(numberlist, l, r, searchedvalue):

    #set to check on base case
    if r >= l:

        #sets how to split array based on amount of elements
        mid = l + (r - l) // 2

        #compares searchedvalue with middle element of array and returns
        #middle element if value is found
        if numberlist[mid] == searchedvalue:
            return mid
        
        #checks to see if searchedvalue is smaller than middle element
        #if so, ignore the righ half and check left subarray
        elif numberlist[mid] > searchedvalue:
            return binarySearch(numberlist, l, mid-1, searchedvalue)

        #if element isn't smaller then check right subarray
        else:
            return binarySearch(numberlist, mid+1, r, searchedvalue)
        
    #is returned when element can not be found in array.
    else:
        return -1


    
#generates 1000 random numbers and adds them to an array
numberlist = random.sample(range(0,1000),1000)

#generates random integer between 0 and 1000 to be called searchvalue
searchedvalue = random.randint(0,1000)


print('Unsorted Random number Array:',numberlist)

print('\nLength of Random number Array:',len(numberlist))

print('\nQuick Sorted number Array:',quicksort(numberlist))

print('\nRandom Search value:',searchedvalue)

#calling the binarySearch function and running the numberlist
#and ordering the array with quicksort so binary search can work properly
result = binarySearch(quicksort(numberlist), 0, len(numberlist)-1,searchedvalue)

if result != -1:
    print('Element found!')

else:
    print('Not found')
   

