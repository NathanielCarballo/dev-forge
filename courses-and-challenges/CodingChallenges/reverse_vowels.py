def reverse_vowels(string):
    vowels = "aeiouAEIOU"
    string_list = list(string)
    i, j = 0, len(string) - 1
    while i < j:
        if string_list[i] not in vowels:
            i += 1
        elif string_list[j] not in vowels:
            j -= 1
        else:
            string_list[i], string_list[j] = string_list[j], string_list[i]
            i += 1
            j -= 1
    return "".join(string_list)
    
string = input("Enter a word: ")
print(reverse_vowels(string))