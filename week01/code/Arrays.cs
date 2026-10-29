public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Create a new array of doubles with 'length' slots to hold the results.
        // 2. Loop with an index i from 0 up to (but not including) 'length'.
        // 3. At each index i, the multiple is number * (i + 1). The +1 is needed because
        //    the first multiple (index 0) is the number itself (number * 1), the second is number * 2, etc.
        // 4. Store that value in the array at index i.
        // 5. After the loop finishes, return the filled array.

        // Step 1: Create the array to hold the multiples
        var multiples = new double[length];

        // Steps 2-4: Fill each slot with the next multiple of 'number'
        for (var i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 5: Return the result
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Rotating right by 'amount' means the last 'amount' items move to the front,
        //    and everything else shifts over to make room.
        //    Example: {1, 2, 3, 4, 5, 6, 7, 8, 9} rotated by 3 -> the last 3 items {7, 8, 9} go to the front.
        // 2. Find where the tail section starts: startIndex = data.Count - amount.
        // 3. Copy the tail section into a new list using GetRange(startIndex, amount).
        // 4. Remove that tail section from the end of the original list using RemoveRange(startIndex, amount).
        // 5. Insert the copied tail at the front of the original list using InsertRange(0, tail).
        // 6. If amount equals data.Count, the tail is the whole list, so the list ends up unchanged (which is correct).

        // Step 2: Find the index where the items to move begin
        var startIndex = data.Count - amount;

        // Step 3: Copy the last 'amount' items
        var tail = data.GetRange(startIndex, amount);

        // Step 4: Remove those items from the end of the list
        data.RemoveRange(startIndex, amount);

        // Step 5: Put them at the front of the list
        data.InsertRange(0, tail);
    }
}
