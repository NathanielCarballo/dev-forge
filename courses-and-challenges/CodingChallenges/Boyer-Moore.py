sample_list = [1,2]

def moore_voting_algorithm(arr):
    #Initialize
    candidate = None
    count = 0

    #Voting Phase
    for num in arr:
        if count == 0:
            candidate = num
            count = 1
        elif num == candidate:
            count +=1
        else:
            count -= 1
    
    #Verify the candidate
    count = sum(1 for num in arr if num == candidate)
    
    #Check if candidate is majority element
    if count > len(arr) // 2:
        return candidate
    return None

print("Sample List:", sample_list)
print("Majority Element:", moore_voting_algorithm(sample_list))