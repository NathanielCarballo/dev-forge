# This code returns the length of the longest concescutive sequence of numbers in a unsorted array of integers, using O(n) time solution.

# This function finds the length of the longest consecutive elements sequence in an unsorted array using O(n) time complexity. It only counts duplicates once and returns 0 if the array is empty and 1 if the array has only one element.
def longest_consecutive(nums):
    if not nums:
        return 0
    num_set = set(nums)
    longest_streak = 1

    for num in num_set:
        if num - 1 not in num_set:
            current_num = num
            current_streak = 1

            while current_num + 1 in num_set:
                current_num += 1
                current_streak += 1

            longest_streak = max(longest_streak, current_streak)

    return longest_streak

nums = input("Enter a list of integers separated by spaces: ").split()
nums = list(map(int, nums))
print("The length of the longest consecutive elements sequence is:", longest_consecutive(nums))