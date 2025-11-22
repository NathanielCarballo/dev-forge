productlst = []                                    #initializing empty list

print('Empty stack size: ', len(productlst))

    
productlst.append('Laptop')                        #push
productlst.append('Keyboard')                      #push
productlst.append('Mouse')                         #push
productlst.append('Speaker')                       #push
productlst.append('Charger')                       #push
productlst.append('Mobile')                        #push
productlst.append('LED')                           #push
productlst.append('LCD')                           #push

print('\nNew stack size : ' , len(productlst))
print('\nElements in new stack:')                 
for x in productlst:                               #used to loop through elements
    print(x)

productlst.reverse()
print('\n')
print(productlst.pop(), 'removed from stack.')      #pop
print(productlst.pop(), 'removed from stack.')      #pop
print(productlst.pop(), 'removed from stack.')      #pop

print('\nNew stack size: ', len(productlst))        

productlst.reverse()
print('\nElements in new stack:')                 
for x in productlst:                               #used to loop through elements
    print(x)
